using System.Drawing;
using System.Windows.Forms;
using OOP10FEXLab.Models;
using OOP10FEXLab.Services;

namespace OOP10FEXLab.UI
{
    /// <summary>Review screen: shows the order and total before it is placed.</summary>
    public class CheckoutForm : Form
    {
        public CheckoutForm(Cart cart, DiningOption dining)
        {
            Text = "Review Your Order";
            Size = new Size(560, 520);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;
            Font = Theme.Font(10f);

            Label title = new Label
            {
                Text = "REVIEW YOUR ORDER  -  " + (dining == DiningOption.DineIn ? "DINE IN" : "TAKE OUT"),
                Dock = DockStyle.Top,
                Height = 52,
                Font = Theme.Font(14f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Theme.Dark,
                TextAlign = ContentAlignment.MiddleCenter
            };

            ListView list = new ListView { Dock = DockStyle.Fill, View = View.Details, FullRowSelect = true };
            list.Columns.Add("Meal", 260);
            list.Columns.Add("Qty", 50, HorizontalAlignment.Center);
            list.Columns.Add("Price", 90, HorizontalAlignment.Right);
            list.Columns.Add("Subtotal", 100, HorizontalAlignment.Right);
            foreach (OrderItem item in cart.Items)
                list.Items.Add(new ListViewItem(new[] { item.Name, item.Quantity.ToString(), item.Price.ToString("N2"), item.Subtotal.ToString("N2") }));

            Label total = new Label
            {
                Text = "TOTAL:  ₱" + cart.Total.ToString("N2"),
                Dock = DockStyle.Bottom,
                Height = 48,
                Font = Theme.Font(16f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight,
                Padding = new Padding(0, 0, 16, 0)
            };

            Panel buttons = new Panel { Dock = DockStyle.Bottom, Height = 64, Padding = new Padding(16, 8, 16, 12) };
            Button back = Theme.MakeButton("BACK", Color.White, Theme.Text);
            back.Dock = DockStyle.Left;
            back.Width = 160;
            back.DialogResult = DialogResult.Cancel;

            Button place = Theme.MakeButton("PLACE ORDER", Theme.Dark, Color.White, 12f);
            place.Dock = DockStyle.Right;
            place.Width = 220;
            place.DialogResult = DialogResult.OK;

            buttons.Controls.Add(back);
            buttons.Controls.Add(place);

            Controls.Add(list);
            Controls.Add(total);
            Controls.Add(buttons);
            Controls.Add(title);

            AcceptButton = place;
            CancelButton = back;
        }
    }
}
