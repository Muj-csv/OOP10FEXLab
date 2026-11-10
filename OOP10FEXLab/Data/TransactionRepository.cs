using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MySql.Data.MySqlClient;
using OOP10FEXLab.Models;

namespace OOP10FEXLab.Data
{
    /// <summary>
    /// Saves every order to the transaction record:
    /// - Data\transactions.txt: order number, status, items. The Queue Monitor reads this file.
    ///   Line format: OrderNo|DateTime|DiningOption|Status|Total|Items
    ///   Items      : CODE^NAME^PRICE^QTY, separated by '~'
    /// - The instructor's database (transactions_tbl), using the provided sample insert.
    /// </summary>
    public class TransactionRepository
    {
        private const string Header = "OrderNo|DateTime|DiningOption|Status|Total|Items";
        private const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "transactions.txt");
        private readonly DatabaseConnection database = DatabaseConnection.CreateDefault();

        public void Save(Order order)
        {
            if (!File.Exists(filePath))
                File.WriteAllText(filePath, Header + Environment.NewLine);

            File.AppendAllText(filePath, ToLine(order) + Environment.NewLine);
        }

        /// <summary>
        /// Instructor's sample insert: one row in transactions_tbl per meal ordered
        /// (2 x 1pc Chicken Meal = 2 rows). All rows are saved, or none.
        /// </summary>
        public void SaveToDatabase(Order order)
        {
            using (MySqlConnection conn = database.CreateConnection())
            {
                conn.Open();
                using (MySqlTransaction tran = conn.BeginTransaction())
                {
                    string sql = "INSERT INTO transactions_tbl " +
                                 "(package_name, transaction_date) " +
                                 "VALUES (@pkg, @date)";

                    foreach (OrderItem item in order.Items)
                    {
                        for (int i = 0; i < item.Quantity; i++)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@pkg", item.Name);
                                cmd.Parameters.AddWithValue("@date", order.OrderDate);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    tran.Commit();   // all rows saved, or none
                }
            }
        }

        public void UpdateStatus(int orderNumber, OrderStatus status)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                Order order = FromLine(lines[i]);
                if (order != null && order.OrderNumber == orderNumber && order.OrderDate.Date == DateTime.Today)
                {
                    order.Status = status;
                    lines[i] = ToLine(order);
                }
            }

            File.WriteAllLines(filePath, lines);
        }

        public List<Order> GetToday()
        {
            if (!File.Exists(filePath)) return new List<Order>();

            return File.ReadAllLines(filePath)
                .Select(FromLine)
                .Where(o => o != null && o.OrderDate.Date == DateTime.Today)
                .ToList();
        }

        /// <summary>Order numbers start at 1001 every day.</summary>
        public int GetNextOrderNumber()
        {
            List<Order> today = GetToday();
            return today.Count == 0 ? 1001 : today.Max(o => o.OrderNumber) + 1;
        }

        private static string ToLine(Order o)
        {
            string items = string.Join("~", o.Items.Select(i =>
                i.Code + "^" + i.Name + "^" + i.Price.ToString(CultureInfo.InvariantCulture) + "^" + i.Quantity));

            return o.OrderNumber + "|" + o.OrderDate.ToString(DateFormat, CultureInfo.InvariantCulture) + "|" +
                   o.DiningOption + "|" + o.Status + "|" + o.Total.ToString("0.00", CultureInfo.InvariantCulture) + "|" + items;
        }

        private static Order FromLine(string line)
        {
            string[] f = line.Split('|');
            int number;
            DateTime date;
            DiningOption dining;
            OrderStatus status;

            if (f.Length < 6 || !int.TryParse(f[0], out number)) return null; // header or blank line

            // A damaged line is skipped instead of crashing the Kiosk and the Queue Monitor.
            if (!DateTime.TryParseExact(f[1], DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ||
                !Enum.TryParse(f[2], out dining) ||
                !Enum.TryParse(f[3], out status))
                return null;

            Order order = new Order
            {
                OrderNumber = number,
                OrderDate = date,
                DiningOption = dining,
                Status = status
            };

            foreach (string part in f[5].Split(new[] { '~' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] p = part.Split('^');
                decimal price;
                int quantity;

                if (p.Length < 4 ||
                    !decimal.TryParse(p[2], NumberStyles.Number, CultureInfo.InvariantCulture, out price) ||
                    !int.TryParse(p[3], out quantity))
                    return null;

                order.Items.Add(new OrderItem
                {
                    Code = p[0],
                    Name = p[1],
                    Price = price,
                    Quantity = quantity
                });
            }

            return order;
        }
    }
}
