using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OOP10FEXLab.Data;
using OOP10FEXLab.Models;
using OOP10FEXLab.Services;

namespace OOP10FEXLab.UI
{
    /// <summary>
    /// Self-order kiosk: Dine In / Take Out -> pick meals -> Review &amp; Pay -> order number.
    /// The fixed layout (header, footer, panels, buttons, welcome screen) is in KioskForm.Designer.cs,
    /// so it can be edited in the Visual Studio Designer. The meal cards, category buttons and
    /// order rows come from the data, so they are created in code below.
    /// </summary>
    public partial class KioskForm : Form
    {
        private const string AllMeals = "All Meals";

        private readonly MealRepository mealRepository = new MealRepository();
        private readonly TransactionRepository transactionRepository = new TransactionRepository();
        private readonly Cart cart = new Cart();
        private readonly Image placeholder = Theme.ImagePlaceholder();

        private List<Meal> meals = new List<Meal>();
        private DiningOption dining = DiningOption.DineIn;

        public KioskForm()
        {
            InitializeComponent();

            Text = "Kiosk - " + Theme.StoreName;
            welcomePanel.BringToFront();   // start on the Dine In / Take Out screen

            cart.Changed += (s, e) => ShowOrder();
        }

        // ---------------------------------------------------------------- designer events

        private void KioskForm_Load(object sender, EventArgs e)
        {
            LoadMeals();
        }

        private void btnDineIn_Click(object sender, EventArgs e)
        {
            StartOrder(DiningOption.DineIn);
        }

        private void btnTakeOut_Click(object sender, EventArgs e)
        {
            StartOrder(DiningOption.TakeOut);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelOrder();
        }

        // REVIEW & PAY: opens the review screen; PLACE ORDER there saves the order (file + database).
        private void payButton_Click(object sender, EventArgs e)
        {
            ReviewAndPay();
        }

        // ---------------------------------------------------------------- menu

        private void LoadMeals()
        {
            try
            {
                meals = mealRepository.GetAll();
                // Shows in the title bar whether the menu came from the instructor's database or from meals.txt.
                Text = "Kiosk - " + Theme.StoreName + "  (menu: " + mealRepository.Source + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the meals.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            categoryPanel.Controls.Clear();
            foreach (string category in new[] { AllMeals }.Concat(meals.Select(m => m.Category).Distinct()))
            {
                Button button = Theme.MakeButton(category, Color.White, Theme.Text, 10.5f);
                button.Size = new Size(160, 56);
                button.Margin = new Padding(0, 0, 0, 8);
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.Padding = new Padding(8, 0, 0, 0);
                string selected = category;
                button.Click += (s, e) => ShowMeals(selected);
                categoryPanel.Controls.Add(button);
            }

            ShowMeals(AllMeals);
            ShowOrder();
        }

        private void ShowMeals(string category)
        {
            foreach (Button button in categoryPanel.Controls.OfType<Button>())
            {
                // Selected category: red with white text (like the highlighted tile in the design).
                bool active = button.Text == category;
                button.BackColor = active ? Theme.Red : Color.White;
                button.ForeColor = active ? Color.White : Theme.Text;
                button.FlatAppearance.BorderColor = active ? Theme.Red : Theme.Border;
                button.FlatAppearance.MouseOverBackColor = active ? Theme.Darken(Theme.Red) : Theme.Hover;
            }

            mealPanel.Controls.Clear();
            foreach (Meal meal in meals.Where(m => category == AllMeals || m.Category == category))
            {
                MealCard card = new MealCard(meal, placeholder);
                card.AddClicked += (s, e) => cart.Add(((MealCard)s).Meal);
                mealPanel.Controls.Add(card);
            }
        }

        // ---------------------------------------------------------------- order

        private void ShowOrder()
        {
            orderPanel.Controls.Clear();

            foreach (OrderItem item in cart.Items)
            {
                RoundedPanel row = new RoundedPanel { Size = new Size(286, 66), Margin = new Padding(0, 0, 0, 8), BackColor = Theme.Cream, Radius = 10 };
                row.Controls.Add(new Label { Text = item.Name, Location = new Point(10, 7), Size = new Size(180, 22), Font = Theme.Font(9.5f, FontStyle.Bold), UseMnemonic = false, AutoEllipsis = true });
                row.Controls.Add(new Label { Text = "₱" + item.Subtotal.ToString("N2"), Location = new Point(192, 7), Size = new Size(86, 22), TextAlign = ContentAlignment.TopRight, Font = Theme.Font(9.5f, FontStyle.Bold), ForeColor = Theme.Red });

                Label minus = SmallButton("-", 10);
                string code = item.Code;
                minus.Click += (s, e) => cart.Decrease(code);

                Label quantity = new Label { Text = item.Quantity.ToString(), Location = new Point(42, 33), Size = new Size(34, 26), TextAlign = ContentAlignment.MiddleCenter, Font = Theme.Font(11f, FontStyle.Bold) };

                Label plus = SmallButton("+", 78);
                Meal meal = meals.First(m => m.Code == code);
                plus.Click += (s, e) => cart.Add(meal);

                row.Controls.Add(minus);
                row.Controls.Add(quantity);
                row.Controls.Add(plus);
                orderPanel.Controls.Add(row);
            }

            totalLabel.Text = "Order Total:  ₱" + cart.Total.ToString("N2");
            payButton.Enabled = !cart.IsEmpty;
            payButton.BackColor = cart.IsEmpty ? Theme.Disabled : Theme.Red; // grey until something is in the order
        }

        // Small square "-" / "+" control (a Label draws the sign reliably at this size).
        private static Label SmallButton(string text, int x)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, 33),
                Size = new Size(30, 26),
                BackColor = Theme.Red,
                ForeColor = Color.White,
                Font = Theme.Font(12f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
        }

        private void StartOrder(DiningOption option)
        {
            dining = option;
            diningLabel.Text = option == DiningOption.DineIn ? "DINE IN" : "TAKE OUT";
            welcomePanel.Visible = false;
        }

        private void CancelOrder()
        {
            if (!cart.IsEmpty && MessageBox.Show("Cancel this order?", "Cancel Order", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            ResetKiosk();
        }

        private void ReviewAndPay()
        {
            using (CheckoutForm checkout = new CheckoutForm(cart, dining))
            {
                if (checkout.ShowDialog(this) != DialogResult.OK) return;
            }

            Order order = new Order
            {
                OrderNumber = transactionRepository.GetNextOrderNumber(),
                OrderDate = DateTime.Now,
                DiningOption = dining,
                Status = OrderStatus.Preparing
            };
            order.Items.AddRange(cart.Items);

            try
            {
                transactionRepository.Save(order);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The order could not be saved.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                transactionRepository.SaveToDatabase(order);   // instructor's database (transactions_tbl)
            }
            catch (Exception ex)
            {
                // The order is still placed and shows on the Queue Monitor; only the database copy failed.
                MessageBox.Show("Order saved, but not to the database.\n\n" + ex.Message, "Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            using (ReceiptForm receipt = new ReceiptForm(order))
                receipt.ShowDialog(this);

            ResetKiosk();
        }

        private void ResetKiosk()
        {
            cart.Clear();
            welcomePanel.Visible = true;
            welcomePanel.BringToFront();
        }
    }
}
