using System.Text;
using System.Windows.Forms;
using OOP10FEXLab.Models;

namespace OOP10FEXLab.UI
{
    /// <summary>
    /// Shows the customer's order number and order slip.
    /// The layout is in ReceiptForm.Designer.cs; this code fills in the order.
    /// </summary>
    public partial class ReceiptForm : Form
    {
        public ReceiptForm(Order order)
        {
            InitializeComponent();

            lblNumber.Text = order.OrderNumber.ToString();
            txtSlip.Text = BuildSlip(order);
            ActiveControl = btnDone;
        }

        private static string BuildSlip(Order order)
        {
            StringBuilder sb = new StringBuilder();
            string line = new string('-', 38);

            sb.AppendLine(Theme.StoreName);
            sb.AppendLine("Order No: " + order.OrderNumber);
            sb.AppendLine("Date    : " + order.OrderDate.ToString("MMM dd, yyyy hh:mm tt"));
            sb.AppendLine("Type    : " + (order.DiningOption == DiningOption.DineIn ? "Dine In" : "Take Out"));
            sb.AppendLine(line);
            foreach (OrderItem item in order.Items)
                sb.AppendLine((item.Quantity + " x " + item.Name).PadRight(28) + item.Subtotal.ToString("N2").PadLeft(10));
            sb.AppendLine(line);
            sb.AppendLine("TOTAL".PadRight(28) + order.Total.ToString("N2").PadLeft(10));
            sb.AppendLine();
            sb.AppendLine("Please pay at the counter and watch");
            sb.AppendLine("the Queue Monitor for your number.");
            sb.AppendLine();
            sb.AppendLine(Theme.ThankYou);
            return sb.ToString();
        }
    }
}
