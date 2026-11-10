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
            BackColor = Theme.Background;
            Font = Theme.Font(10f);

            BuildLayout();
            BuildWelcomeScreen();

            cart.Changed += (s, e) => ShowOrder();
            Load += (s, e) => LoadMeals();
        }

        // ---------------------------------------------------------------- layout

        private void BuildLayout()
        {
            // Header
            Panel header = new Panel { Dock = DockStyle.Top, Height = 64, BackColor = Theme.Dark };
            header.Controls.Add(new Label { Text = Theme.StoreName, Font = Theme.Font(20f, FontStyle.Bold), ForeColor = Color.White, AutoSize = true, Location = new Point(20, 14) });
            diningLabel = new Label { Dock = DockStyle.Right, Width = 220, Font = Theme.Font(13f, FontStyle.Bold), ForeColor = Color.White, TextAlign = ContentAlignment.MiddleCenter };
            header.Controls.Add(diningLabel);

            // Footer: Cancel Order | Order Total | Review & Pay
            Panel footer = new Panel { Dock = DockStyle.Bottom, Height = 72, BackColor = Color.White, Padding = new Padding(12) };
            Button cancelButton = Theme.MakeButton("CANCEL ORDER", Color.White, Theme.Text);
            cancelButton.Dock = DockStyle.Left;
            cancelButton.Width = 180;
            cancelButton.Click += (s, e) => CancelOrder();

            payButton = Theme.MakeButton("REVIEW & PAY", Theme.Dark, Color.White, 13f);
            payButton.Dock = DockStyle.Right;
            payButton.Width = 240;
            payButton.Click += (s, e) => ReviewAndPay();

            totalLabel = new Label { Dock = DockStyle.Fill, Font = Theme.Font(16f, FontStyle.Bold), TextAlign = ContentAlignment.MiddleRight, Padding = new Padding(0, 0, 20, 0) };
            footer.Controls.Add(totalLabel);
            footer.Controls.Add(cancelButton);
            footer.Controls.Add(payButton);

            // Left: categories
            categoryPanel = new FlowLayoutPanel { Dock = DockStyle.Left, Width = 180, BackColor = Color.White, FlowDirection = FlowDirection.TopDown, WrapContents = false, Padding = new Padding(10) };

            // Right: My Order
            Panel orderBox = new Panel { Dock = DockStyle.Right, Width = 320, BackColor = Color.White, Padding = new Padding(12) };
            orderPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoScroll = true };
            orderBox.Controls.Add(orderPanel);
            orderBox.Controls.Add(new Label { Text = "MY ORDER", Dock = DockStyle.Top, Height = 36, Font = Theme.Font(14f, FontStyle.Bold) });

            // Center: meal tiles
            mealPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(10) };

            // Docking lays out the last-added control first, so header/footer go in last.
            Controls.Add(mealPanel);
            Controls.Add(orderBox);
            Controls.Add(categoryPanel);
            Controls.Add(footer);
            Controls.Add(header);
        }

        private void BuildWelcomeScreen()
        {
            welcomePanel = new Panel
            {
                Location = Point.Empty,
                Size = ClientSize,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Theme.Dark
            };

            // 3 rows: store name, question, the two buttons (centered)
            TableLayoutPanel layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3 };
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 45));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 55));

            Label title = new Label { Text = Theme.StoreName, Font = Theme.Font(40f, FontStyle.Bold), ForeColor = Color.White, TextAlign = ContentAlignment.BottomCenter, Dock = DockStyle.Fill };
            Label prompt = new Label { Text = "Where will you be eating today?", Font = Theme.Font(16f), ForeColor = Color.White, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill };

            FlowLayoutPanel choices = new FlowLayoutPanel { Anchor = AnchorStyles.Top, AutoSize = true, WrapContents = false };
            Button dineIn = Theme.MakeButton("DINE IN", Color.White, Theme.Text, 20f);
            Button takeOut = Theme.MakeButton("TAKE OUT", Theme.Silver, Theme.Text, 20f);
            dineIn.Size = takeOut.Size = new Size(280, 120);
            dineIn.Margin = takeOut.Margin = new Padding(20, 0, 20, 0);
            dineIn.Click += (s, e) => StartOrder(DiningOption.DineIn);
            takeOut.Click += (s, e) => StartOrder(DiningOption.TakeOut);
            choices.Controls.Add(dineIn);
            choices.Controls.Add(takeOut);

            layout.Controls.Add(title, 0, 0);
            layout.Controls.Add(prompt, 0, 1);
            layout.Controls.Add(choices, 0, 2);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load the meals.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            categoryPanel.Controls.Clear();
            foreach (string category in new[] { AllMeals }.Concat(meals.Select(m => m.Category).Distinct()))
            {
                Button button = Theme.MakeButton(category, Color.White, Theme.Text, 10.5f);
                button.Size = new Size(150, 52);
                button.TextAlign = ContentAlignment.MiddleLeft;
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
                bool active = button.Text == category;
                button.BackColor = active ? Theme.Dark : Color.White;
                button.ForeColor = active ? Color.White : Theme.Text;
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
                Panel row = new Panel { Size = new Size(280, 64), Margin = new Padding(0, 0, 0, 6), BackColor = Theme.Background };
                row.Controls.Add(new Label { Text = item.Name, Location = new Point(8, 6), Size = new Size(180, 22), Font = Theme.Font(9.5f, FontStyle.Bold), UseMnemonic = false });
                row.Controls.Add(new Label { Text = "₱" + item.Subtotal.ToString("N2"), Location = new Point(190, 6), Size = new Size(84, 22), TextAlign = ContentAlignment.TopRight, Font = Theme.Font(9.5f, FontStyle.Bold) });

                Label minus = SmallButton("-", 8);
                string code = item.Code;
                minus.Click += (s, e) => cart.Decrease(code);

                Label quantity = new Label { Text = item.Quantity.ToString(), Location = new Point(40, 32), Size = new Size(34, 26), TextAlign = ContentAlignment.MiddleCenter, Font = Theme.Font(11f, FontStyle.Bold) };

                Label plus = SmallButton("+", 76);
                Meal meal = meals.First(m => m.Code == code);
                plus.Click += (s, e) => cart.Add(meal);

                row.Controls.Add(minus);
                row.Controls.Add(quantity);
                row.Controls.Add(plus);
                orderPanel.Controls.Add(row);
            }

            totalLabel.Text = "Order Total:  ₱" + cart.Total.ToString("N2");
            payButton.Enabled = !cart.IsEmpty;
        }

        // Small square "-" / "+" control (a Label draws the sign reliably at this size).
        private static Label SmallButton(string text, int x)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, 32),
                Size = new Size(30, 26),
                BackColor = Theme.Dark,
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
