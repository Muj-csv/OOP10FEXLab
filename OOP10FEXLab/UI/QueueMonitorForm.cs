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
    /// Queue monitor: PREPARING | NOW SERVING | store name.
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
            BackColor = Theme.Dark;

            BuildLayout();

            refreshTimer.Tick += (s, e) => RefreshQueue();
            Load += (s, e) => { RefreshQueue(); refreshTimer.Start(); };
            FormClosed += (s, e) => refreshTimer.Dispose();
        }

        private void BuildLayout()
        {
            Label title = new Label
            {
                Text = "QUEUE MONITOR",
                Dock = DockStyle.Top,
                Height = 60,
                Font = Theme.Font(24f, FontStyle.Bold),
                BackColor = Theme.Screen,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };

            Label hint = new Label
            {
                Text = "Crew: click a number to move it to the next step  (Preparing → Now Serving → Claimed)",
                Dock = DockStyle.Bottom,
                Height = 32,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            };

            TableLayoutPanel screen = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                BackColor = Theme.Screen,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Margin = new Padding(12)
            };
            screen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            screen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));
            screen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22));

            preparingPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true };
            servingPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true };
            screen.Controls.Add(Column("PREPARING", preparingPanel), 0, 0);
            screen.Controls.Add(Column("NOW SERVING", servingPanel), 1, 0);

            Panel brand = new Panel { Dock = DockStyle.Fill };
            clockLabel = new Label { Dock = DockStyle.Bottom, Height = 60, Font = Theme.Font(18f, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
            brand.Controls.Add(new Label { Text = Theme.StoreName, Dock = DockStyle.Fill, Font = Theme.Font(22f, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter });
            brand.Controls.Add(clockLabel);
            screen.Controls.Add(brand, 2, 0);

            Panel bezel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12, 12, 12, 0) };
            bezel.Controls.Add(screen);

            Controls.Add(bezel);
            Controls.Add(hint);
            Controls.Add(title);
        }

        private static Panel Column(string heading, FlowLayoutPanel numbers)
        {
            Panel column = new Panel { Dock = DockStyle.Fill };
            column.Controls.Add(numbers);
            column.Controls.Add(new Label { Text = heading, Dock = DockStyle.Top, Height = 50, Font = Theme.Font(18f, FontStyle.Bold), Padding = new Padding(10, 0, 0, 0), TextAlign = ContentAlignment.MiddleLeft });
            return column;
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

            ShowNumbers(preparingPanel, orders.Where(o => o.Status == OrderStatus.Preparing).OrderBy(o => o.OrderNumber), 24f);
            ShowNumbers(servingPanel, orders.Where(o => o.Status == OrderStatus.NowServing).OrderByDescending(o => o.OrderNumber), 34f);
        }

        private void ShowNumbers(FlowLayoutPanel panel, IEnumerable<Order> orders, float fontSize)
        {
            panel.SuspendLayout();
            panel.Controls.Clear();

            foreach (Order order in orders)
            {
                Label number = new Label
                {
                    Text = order.OrderNumber.ToString(),
                    AutoSize = true,
                    Margin = new Padding(14, 6, 14, 6),
                    Font = Theme.Font(fontSize, FontStyle.Bold),
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
            RefreshQueue();
        }
    }
}
