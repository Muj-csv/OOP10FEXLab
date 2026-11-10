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

        public static Font Font(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font("Segoe UI", size, style);
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
            using (Font font = Font(11f, FontStyle.Bold))
            using (StringFormat center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.Clear(Color.FromArgb(225, 225, 225));
                g.DrawRectangle(pen, 0, 0, 169, 99);
                g.DrawString("IMAGE", font, new SolidBrush(SubText), new RectangleF(0, 0, 170, 100), center);
            }
            return bmp;
        }
    }
}
