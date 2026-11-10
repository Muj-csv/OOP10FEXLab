using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OOP10FEXLab.Models;

namespace OOP10FEXLab.UI
{
    /// <summary>Shows the customer's order number and order slip.</summary>
    public class ReceiptForm : Form
    {
        public ReceiptForm(Order order)
        {
            Text = "Thank You!";
            Size = new Size(460, 600);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;

            Label caption = new Label { Text = "YOUR ORDER NUMBER", Dock = DockStyle.Top, Height = 48, Font = Theme.Font(12f, FontStyle.Bold), ForeColor = Color.White, BackColor = Theme.Dark, TextAlign = ContentAlignment.BottomCenter };
            Label number = new Label { Text = order.OrderNumber.ToString(), Dock = DockStyle.Top, Height = 120, Font = Theme.Font(54f, FontStyle.Bold), ForeColor = Color.White, BackColor = Theme.Dark, TextAlign = ContentAlignment.MiddleCenter };

            TextBox slip = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                TabStop = false,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                BackColor = Theme.Background,
                Font = new Font("Consolas", 10f),
                Text = BuildSlip(order)
            };

            Button done = Theme.MakeButton("DONE", Theme.Dark, Color.White, 13f);
            done.Dock = DockStyle.Bottom;
            done.Height = 52;
            done.DialogResult = DialogResult.OK;

            Controls.Add(slip);
            Controls.Add(done);
            Controls.Add(number);
            Controls.Add(caption);

            AcceptButton = done;
            ActiveControl = done;
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
            sb.AppendLine("the Claim Monitor for your number.");
            return sb.ToString();
        }
    }
}
