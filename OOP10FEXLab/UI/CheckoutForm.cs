using System.Windows.Forms;
using OOP10FEXLab.Models;
using OOP10FEXLab.Services;

namespace OOP10FEXLab.UI
{
    /// <summary>
    /// Review screen: shows the order and total before it is placed.
    /// The layout is in CheckoutForm.Designer.cs; this code fills in the order.
    /// PLACE ORDER returns OK, and the Kiosk then saves the order (transactions.txt + database).
    /// </summary>
    public partial class CheckoutForm : Form
    {
        public CheckoutForm(Cart cart, DiningOption dining)
        {
            InitializeComponent();

            lblTitle.Text = "REVIEW YOUR ORDER  -  " + (dining == DiningOption.DineIn ? "DINE IN" : "TAKE OUT");

            foreach (OrderItem item in cart.Items)
                listOrder.Items.Add(new ListViewItem(new[] { item.Name, item.Quantity.ToString(), item.Price.ToString("N2"), item.Subtotal.ToString("N2") }));

            lblTotal.Text = "TOTAL:  ₱" + cart.Total.ToString("N2");
        }
    }
}
