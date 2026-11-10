using System;
using System.Drawing;
using System.Windows.Forms;
using OOP10FEXLab.Models;

namespace OOP10FEXLab.UI
{
    /// <summary>One meal tile on the kiosk menu (a rounded white card).</summary>
    internal class MealCard : RoundedPanel
    {
        public Meal Meal { get; private set; }

        public event EventHandler AddClicked;

        public MealCard(Meal meal, Image image)
        {
            Meal = meal;
            Size = new Size(190, 262);
            Margin = new Padding(9);
            Padding = new Padding(10);
            Radius = 16;
            BorderColor = Theme.Border;
            BackColor = Color.White;

            PictureBox picture = new PictureBox { Dock = DockStyle.Top, Height = 100, Image = image, SizeMode = PictureBoxSizeMode.Zoom };
            // AutoEllipsis ends a name or inclusion list that is too long with "..." instead of cutting it off.
            Label name = new Label { Text = meal.Name, Dock = DockStyle.Top, Height = 44, Font = Theme.Font(10.5f, FontStyle.Bold), ForeColor = Theme.Text, TextAlign = ContentAlignment.MiddleCenter, UseMnemonic = false, AutoEllipsis = true };
            Label inclusions = new Label { Text = meal.Inclusions, Dock = DockStyle.Top, Height = 32, Font = Theme.Font(8f), ForeColor = Theme.SubText, TextAlign = ContentAlignment.TopCenter, UseMnemonic = false, AutoEllipsis = true };
            Label price = new Label { Text = "₱" + meal.Price.ToString("N2"), Dock = DockStyle.Top, Height = 28, Font = Theme.Font(13f, FontStyle.Bold), ForeColor = Theme.Red, TextAlign = ContentAlignment.MiddleCenter };

            Button add = Theme.MakeButton("+ ADD", Theme.Red, Color.White, 10.5f);
            add.Dock = DockStyle.Bottom;
            add.Height = 34;
            add.Click += (s, e) => { if (AddClicked != null) AddClicked(this, EventArgs.Empty); };

            // Dock = Top stacks the LAST added control on top, so add bottom-up.
            Controls.Add(add);
            Controls.Add(price);
            Controls.Add(inclusions);
            Controls.Add(name);
            Controls.Add(picture);

            // Highlight the card while the mouse is over it (including over its picture, labels and button).
            HookHover(this);
            foreach (Control child in Controls) HookHover(child);
        }

        private void HookHover(Control control)
        {
            control.MouseEnter += (s, e) => SetHover(true);
            // Moving from the card onto one of its own labels also fires MouseLeave, so check where the mouse really is.
            control.MouseLeave += (s, e) => SetHover(ClientRectangle.Contains(PointToClient(Cursor.Position)));
        }

        private void SetHover(bool hover)
        {
            BackColor = hover ? Theme.Hover : Color.White;
            BorderColor = hover ? Theme.Yellow : Theme.Border;
            Invalidate();
        }
    }
}
