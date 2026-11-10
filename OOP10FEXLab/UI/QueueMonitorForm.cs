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
    /// The layout and the 2-second timer are in QueueMonitorForm.Designer.cs.
    /// Reads today's orders from the transaction record every 2 seconds.
    /// Crew clicks a number to move it: Preparing -> Now Serving -> Claimed.
    /// </summary>
    public partial class QueueMonitorForm : Form
    {
        private readonly TransactionRepository transactionRepository = new TransactionRepository();

        public QueueMonitorForm()
        {
            InitializeComponent();
            Text = "Queue Monitor - " + Theme.StoreName;
        }

        private void QueueMonitorForm_Load(object sender, EventArgs e)
        {
            RefreshQueue();
            refreshTimer.Start();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshQueue();
        }

        private void RefreshQueue()
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm tt");

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

        // The order numbers change with the data, so they are created here, not in the designer.
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

            try
            {
                transactionRepository.UpdateStatus(order.OrderNumber, next);
            }
            catch (Exception ex)
            {
                // The file can be busy or missing for a moment; show it instead of crashing the monitor.
                MessageBox.Show("Could not update order " + order.OrderNumber + ".\n\n" + ex.Message, "Queue Monitor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Refresh after this click finishes, because the refresh disposes the label that was clicked.
            BeginInvoke((Action)RefreshQueue);
        }
    }
}
