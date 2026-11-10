using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP10FEXLab.UI
{
    /// <summary>Store name, colors and fonts used by every screen. Edit this file to rebrand.</summary>
    internal static class Theme
    {
        public const string StoreName = "[STORE NAME]";

        public static readonly Color Dark = Color.FromArgb(85, 85, 85);        // header, main buttons
        public static readonly Color Silver = Color.FromArgb(205, 205, 205);   // secondary buttons
        public static readonly Color Background = Color.FromArgb(240, 240, 240);
        public static readonly Color Text = Color.FromArgb(30, 30, 30);
        public static readonly Color SubText = Color.FromArgb(110, 110, 110);
        public static readonly Color Border = Color.FromArgb(190, 190, 190);
        public static readonly Color Screen = Color.FromArgb(232, 232, 232);  // queue monitor screen
        public static readonly Color Hover = Color.FromArgb(228, 228, 228);   // meal card under the mouse

        // Fonts are created once and reused. The order list and the queue monitor are rebuilt often,
        // and creating a new Font every time wastes memory and system handles.
        private static readonly Dictionary<string, Font> fonts = new Dictionary<string, Font>();

        public static Font Font(float size, FontStyle style = FontStyle.Regular)
        {
            string key = size + "|" + style;
            Font font;
            if (!fonts.TryGetValue(key, out font))
            {
                font = new Font("Segoe UI", size, style);
                fonts[key] = font;
            }
            return font;
        }

        public static Button MakeButton(string text, Color back, Color fore, float size = 11f)
        {
            Button button = new Button
            {
                Text = text,
                BackColor = back,
                ForeColor = fore,
                FlatStyle = FlatStyle.Flat,
                Font = Font(size, FontStyle.Bold),
                Cursor = Cursors.Hand,
                UseMnemonic = false
            };
            button.FlatAppearance.BorderColor = Border;
            return button;
        }

        /// <summary>Grey "IMAGE" box shown where a meal picture would go.</summary>
        public static Image ImagePlaceholder()
        {
            Bitmap bmp = new Bitmap(170, 100);
            using (Graphics g = Graphics.FromImage(bmp))
            using (Pen pen = new Pen(Border))
            using (SolidBrush brush = new SolidBrush(SubText))
            using (StringFormat center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.Clear(Color.FromArgb(225, 225, 225));
                g.DrawRectangle(pen, 0, 0, 169, 99);
                // The font is shared (see Font above), so it is not disposed here.
                g.DrawString("IMAGE", Font(11f, FontStyle.Bold), brush, new RectangleF(0, 0, 170, 100), center);
            }
            return bmp;
        }
    }
}
