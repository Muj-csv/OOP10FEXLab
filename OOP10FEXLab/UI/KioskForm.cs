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
    /// </summary>
    public class KioskForm : Form
    {
        private const string AllMeals = "All Meals";

        private readonly MealRepository mealRepository = new MealRepository();
        private readonly TransactionRepository transactionRepository = new TransactionRepository();
        private readonly Cart cart = new Cart();
        private readonly Image placeholder = Theme.ImagePlaceholder();

        private List<Meal> meals = new List<Meal>();
        private DiningOption dining = DiningOption.DineIn;

        private Panel welcomePanel;
        private FlowLayoutPanel categoryPanel;
        private FlowLayoutPanel mealPanel;
        private FlowLayoutPanel orderPanel;
        private Label diningLabel;
        private Label totalLabel;
        private Button payButton;

        public KioskForm()
        {
            Text = "Kiosk - " + Theme.StoreName;
            Size = new Size(1280, 800);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Theme.Cream;
            ForeColor = Theme.Text;
            Font = Theme.Font(10f);

            BuildLayout();
            BuildWelcomeScreen();

            cart.Changed += (s, e) => ShowOrder();
            Load += (s, e) => LoadMeals();
        }

        // ---------------------------------------------------------------- layout

        private void BuildLayout()
        {
            // Header: red band with the store name in yellow, and a thin yellow stripe under it
            Panel header = new Panel { Dock = DockStyle.Top, Height = 76, BackColor = Theme.Red };
            header.Controls.Add(new Label { Text = Theme.StoreName, Font = Theme.BrandFont(26f), ForeColor = Theme.Yellow, AutoSize = true, Location = new Point(22, 12), UseMnemonic = false });
            diningLabel = new Label { Dock = DockStyle.Right, Width = 220, Font = Theme.Font(14f, FontStyle.Bold), ForeColor = Color.White, TextAlign = ContentAlignment.MiddleCenter };
            header.Controls.Add(diningLabel);
            Panel headerStripe = new Panel { Dock = DockStyle.Top, Height = 6, BackColor = Theme.Yellow };

            // Footer: Cancel Order | Order Total | Review & Pay
            Panel footer = new Panel { Dock = DockStyle.Bottom, Height = 78, BackColor = Color.White, Padding = new Padding(14, 12, 14, 12) };
            Button cancelButton = Theme.MakeButton("CANCEL ORDER", Color.White, Theme.Red);
            cancelButton.Dock = DockStyle.Left;
            cancelButton.Width = 190;
            cancelButton.Click += (s, e) => CancelOrder();

            payButton = Theme.MakeButton("REVIEW & PAY  ›", Theme.Red, Color.White, 14f);
            payButton.Dock = DockStyle.Right;
            payButton.Width = 260;
            payButton.Click += (s, e) => ReviewAndPay();

            totalLabel = new Label { Dock = DockStyle.Fill, Font = Theme.Font(17f, FontStyle.Bold), ForeColor = Theme.Text, TextAlign = ContentAlignment.MiddleRight, Padding = new Padding(0, 0, 22, 0) };
            footer.Controls.Add(totalLabel);
            footer.Controls.Add(cancelButton);
            footer.Controls.Add(payButton);
            Panel footerStripe = new Panel { Dock = DockStyle.Bottom, Height = 4, BackColor = Theme.Yellow };

            // Left: categories
            categoryPanel = new FlowLayoutPanel { Dock = DockStyle.Left, Width = 190, BackColor = Color.White, FlowDirection = FlowDirection.TopDown, WrapContents = false, Padding = new Padding(12) };

            // Right: My Order
            Panel orderBox = new Panel { Dock = DockStyle.Right, Width = 330, BackColor = Color.White, Padding = new Padding(14) };
            orderPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoScroll = true };
            orderBox.Controls.Add(orderPanel);
            orderBox.Controls.Add(new Label { Text = "MY ORDER", Dock = DockStyle.Top, Height = 40, Font = Theme.Font(15f, FontStyle.Bold), ForeColor = Theme.Red });

            // Center: meal tiles on the cream background
            mealPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(12), BackColor = Theme.Cream };

            // Docking lays out the last-added control first, so header/footer go in last.
            Controls.Add(mealPanel);
            Controls.Add(orderBox);
            Controls.Add(categoryPanel);
            Controls.Add(footerStripe);
            Controls.Add(footer);
            Controls.Add(headerStripe);
            Controls.Add(header);
        }

        private void BuildWelcomeScreen()
        {
            welcomePanel = new Panel
            {
                Location = Point.Empty,
                Size = ClientSize,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Theme.Red
            };

            // 4 rows: store name, greeting, question, the two buttons (centered)
            TableLayoutPanel layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 4 };
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 60));

            Label title = new Label { Text = Theme.StoreName, Font = Theme.BrandFont(60f), ForeColor = Theme.Yellow, TextAlign = ContentAlignment.BottomCenter, Dock = DockStyle.Fill, UseMnemonic = false };
            Label hello = new Label { Text = "Hello! What would you like to order?", Font = Theme.Font(22f, FontStyle.Bold), ForeColor = Color.White, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill };
            Label prompt = new Label { Text = "Where will you be eating today?", Font = Theme.Font(15f), ForeColor = Theme.YellowLight, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill };

            FlowLayoutPanel choices = new FlowLayoutPanel { Anchor = AnchorStyles.Top, AutoSize = true, WrapContents = false, Margin = new Padding(0, 20, 0, 0) };
            Button dineIn = Theme.MakeButton("DINE IN", Color.White, Theme.Red, 22f);
            Button takeOut = Theme.MakeButton("TAKE OUT", Theme.Yellow, Theme.Red, 22f);
            dineIn.FlatAppearance.BorderColor = Color.White; // no red outline on the red screen
            dineIn.Size = takeOut.Size = new Size(280, 130);
            dineIn.Margin = takeOut.Margin = new Padding(20, 0, 20, 0);
            dineIn.Click += (s, e) => StartOrder(DiningOption.DineIn);
            takeOut.Click += (s, e) => StartOrder(DiningOption.TakeOut);
            choices.Controls.Add(dineIn);
            choices.Controls.Add(takeOut);

            layout.Controls.Add(title, 0, 0);
            layout.Controls.Add(hello, 0, 1);
            layout.Controls.Add(prompt, 0, 2);
            layout.Controls.Add(choices, 0, 3);
            welcomePanel.Controls.Add(layout);

            Controls.Add(welcomePanel);
            welcomePanel.BringToFront();
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
