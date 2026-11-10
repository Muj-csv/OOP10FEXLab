using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OOP10FEXLab.Data;
using OOP10FEXLab.Models;

namespace OOP10FEXLab.UI
{
    /// <summary>
    /// Queue monitor: store name and clock on top, NOW SERVING | PREPARING columns, thank-you band at the bottom.
    /// Reads today's orders from the transaction record every 2 seconds.
    /// Crew clicks a number to move it: Preparing -> Now Serving -> Claimed.
    /// </summary>
    public class QueueMonitorForm : Form
    {
        private readonly TransactionRepository transactionRepository = new TransactionRepository();
        private readonly Timer refreshTimer = new Timer { Interval = 2000 };

        private FlowLayoutPanel preparingPanel;
        private FlowLayoutPanel servingPanel;
        private Label clockLabel;

        public QueueMonitorForm()
        {
            Text = "Queue Monitor - " + Theme.StoreName;
            Size = new Size(1200, 680);
            StartPosition = FormStartPosition.Manual;
            Location = new Point(20, 20);
            BackColor = Theme.Cream;
            ForeColor = Theme.Text;

            BuildLayout();

            refreshTimer.Tick += (s, e) => RefreshQueue();
            Load += (s, e) => { RefreshQueue(); refreshTimer.Start(); };
            FormClosed += (s, e) => refreshTimer.Dispose();
        }

        private void BuildLayout()
        {
            // Header: store name on the left, clock on the right, on a light yellow band
            Panel header = new Panel { Dock = DockStyle.Top, Height = 100, BackColor = Theme.YellowLight, Padding = new Padding(24, 0, 24, 0) };
            clockLabel = new Label { Dock = DockStyle.Right, Width = 220, Font = Theme.Font(24f, FontStyle.Bold), ForeColor = Theme.Red, TextAlign = ContentAlignment.MiddleRight };
            Label brand = new Label { Text = Theme.StoreName, Dock = DockStyle.Fill, Font = Theme.BrandFont(40f), ForeColor = Theme.Red, TextAlign = ContentAlignment.MiddleLeft, UseMnemonic = false };
            header.Controls.Add(brand);
            header.Controls.Add(clockLabel);
            Panel headerStripe = new Panel { Dock = DockStyle.Top, Height = 8, BackColor = Theme.Yellow };

            // Footer: red thank-you band, with the crew hint below it
            Label thanks = new Label { Text = Theme.ThankYou, Dock = DockStyle.Bottom, Height = 56, BackColor = Theme.Red, ForeColor = Color.White, Font = Theme.Font(18f, FontStyle.Bold | FontStyle.Italic), TextAlign = ContentAlignment.MiddleCenter, UseMnemonic = false };
            Label hint = new Label
            {
                Text = "Crew: click a number to move it to the next step  (Preparing → Now Serving → Claimed)",
                Dock = DockStyle.Bottom,
                Height = 28,
                BackColor = Theme.Darken(Theme.Red),
                ForeColor = Theme.YellowLight,
                Font = Theme.Font(9f),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Two cards: NOW SERVING (big red numbers) and PREPARING
            TableLayoutPanel screen = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, Padding = new Padding(14) };
            screen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
            screen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
            screen.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            servingPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(8) };
            preparingPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(8) };
            screen.Controls.Add(Column("NOW SERVING", servingPanel), 0, 0);
            screen.Controls.Add(Column("PREPARING", preparingPanel), 1, 0);

            // Docking lays out the last-added control first, so header/footer go in last.
            Controls.Add(screen);
            Controls.Add(hint);
            Controls.Add(thanks);
            Controls.Add(headerStripe);
            Controls.Add(header);
        }

        /// <summary>A white rounded card with a red rounded heading, like the columns in the design.</summary>
        private static Panel Column(string heading, FlowLayoutPanel numbers)
        {
            RoundedPanel card = new RoundedPanel { Dock = DockStyle.Fill, BackColor = Color.White, BorderColor = Theme.Border, Radius = 18, Padding = new Padding(8), Margin = new Padding(10) };

            // Side padding keeps the label off the rounded corners so they stay visible.
            RoundedPanel title = new RoundedPanel { Dock = DockStyle.Top, Height = 64, BackColor = Theme.Red, Radius = 14, Padding = new Padding(14, 0, 14, 0) };
            title.Controls.Add(new Label { Text = heading, Dock = DockStyle.Fill, Font = Theme.Font(22f, FontStyle.Bold), ForeColor = Color.White, TextAlign = ContentAlignment.MiddleCenter });

            card.Controls.Add(numbers);
            card.Controls.Add(title);
            return card;
        }

        private void RefreshQueue()
        {
            clockLabel.Text = DateTime.Now.ToString("hh:mm tt");

            List<Order> orders;
            try
            {
                orders = transactionRepository.GetToday();
            }
            catch (Exception)
            {
                return; // file busy (kiosk is saving) - try again on the next tick
            }

            ShowNumbers(servingPanel, orders.Where(o => o.Status == OrderStatus.NowServing).OrderByDescending(o => o.OrderNumber), 44f, Theme.Red);
            ShowNumbers(preparingPanel, orders.Where(o => o.Status == OrderStatus.Preparing).OrderBy(o => o.OrderNumber), 28f, Theme.Text);
        }

        private void ShowNumbers(FlowLayoutPanel panel, IEnumerable<Order> orders, float fontSize, Color color)
        {
            panel.SuspendLayout();

            // Dispose the old labels: Controls.Clear() alone keeps them alive, and this runs every 2 seconds.
            List<Control> old = panel.Controls.Cast<Control>().ToList();
            panel.Controls.Clear();
            foreach (Control control in old) control.Dispose();

            foreach (Order order in orders)
            {
                Label number = new Label
                {
                    Text = order.OrderNumber.ToString(),
                    AutoSize = true,
                    Margin = new Padding(16, 8, 16, 8),
                    Font = Theme.Font(fontSize, FontStyle.Bold),
                    ForeColor = color,
                    Cursor = Cursors.Hand
                };
                Order clicked = order;
                number.Click += (s, e) => MoveToNextStep(clicked);
                panel.Controls.Add(number);
            }

            panel.ResumeLayout();
        }

        private void MoveToNextStep(Order order)
        {
            OrderStatus next = order.Status == OrderStatus.Preparing ? OrderStatus.NowServing : OrderStatus.Claimed;
            transactionRepository.UpdateStatus(order.OrderNumber, next);
            // Refresh after this click finishes, because the refresh disposes the label that was clicked.
            BeginInvoke((Action)RefreshQueue);
        }
    }
}
