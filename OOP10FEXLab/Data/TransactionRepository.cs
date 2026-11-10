using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using OOP10FEXLab.Models;

namespace OOP10FEXLab.Data
{
    /// <summary>
    /// Saves every order to Data\transactions.txt (the transaction record).
    /// Line format: OrderNo|DateTime|DiningOption|Status|Total|Items
    /// Items      : CODE^NAME^PRICE^QTY, separated by '~'
    /// </summary>
    public class TransactionRepository
    {
        private const string Header = "OrderNo|DateTime|DiningOption|Status|Total|Items";
        private const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "transactions.txt");

        public void Save(Order order)
        {
            if (!File.Exists(filePath))
                File.WriteAllText(filePath, Header + Environment.NewLine);

            File.AppendAllText(filePath, ToLine(order) + Environment.NewLine);
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
            if (f.Length < 6 || !int.TryParse(f[0], out number)) return null; // header or blank line

            Order order = new Order
            {
                OrderNumber = number,
                OrderDate = DateTime.ParseExact(f[1], DateFormat, CultureInfo.InvariantCulture),
                DiningOption = (DiningOption)Enum.Parse(typeof(DiningOption), f[2]),
                Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), f[3])
            };

            foreach (string part in f[5].Split(new[] { '~' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] p = part.Split('^');
                order.Items.Add(new OrderItem
                {
                    Code = p[0],
                    Name = p[1],
                    Price = decimal.Parse(p[2], CultureInfo.InvariantCulture),
                    Quantity = int.Parse(p[3])
                });
            }

            return order;
        }
    }
}
