using System;
using System.Drawing;
using System.Windows.Forms;
using OOP10FEXLab.Models;

namespace OOP10FEXLab.UI
{
    /// <summary>One meal tile on the kiosk menu.</summary>
    internal class MealCard : Panel
    {
        public Meal Meal { get; private set; }

        public event EventHandler AddClicked;

        public MealCard(Meal meal, Image image)
        {
            Meal = meal;
            Size = new Size(190, 250);
            Margin = new Padding(8);
            Padding = new Padding(8);
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;

            PictureBox picture = new PictureBox { Dock = DockStyle.Top, Height = 100, Image = image, SizeMode = PictureBoxSizeMode.Zoom };
            Label name = new Label { Text = meal.Name, Dock = DockStyle.Top, Height = 44, Font = Theme.Font(10f, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, UseMnemonic = false };
            Label inclusions = new Label { Text = meal.Inclusions, Dock = DockStyle.Top, Height = 32, Font = Theme.Font(8f), ForeColor = Theme.SubText, TextAlign = ContentAlignment.TopCenter };
            Label price = new Label { Text = "₱" + meal.Price.ToString("N2"), Dock = DockStyle.Top, Height = 24, Font = Theme.Font(11f, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };

            Button add = Theme.MakeButton("+ ADD", Theme.Dark, Color.White, 10f);
            add.Dock = DockStyle.Bottom;
            add.Height = 32;
            add.Click += (s, e) => { if (AddClicked != null) AddClicked(this, EventArgs.Empty); };

            // Dock = Top stacks the LAST added control on top, so add bottom-up.
            Controls.Add(add);
            Controls.Add(price);
            Controls.Add(inclusions);
            Controls.Add(name);
            Controls.Add(picture);
        }
    }
}
