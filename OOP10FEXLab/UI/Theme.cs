using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OOP10FEXLab.UI
{
    /// <summary>Store name, colors and fonts used by every screen. Edit this file to rebrand.</summary>
    internal static class Theme
    {
        public const string StoreName = "AnDokiDoks";
        public const string ThankYou = "Thank you for choosing AnDokiDoks!";

        // Red and yellow fast-food look.
        public static readonly Color Red = Color.FromArgb(200, 16, 46);           // header, main buttons, headings
        public static readonly Color Yellow = Color.FromArgb(255, 196, 37);       // store name on red, accents
        public static readonly Color YellowLight = Color.FromArgb(255, 236, 179); // queue monitor header, highlights
        public static readonly Color Cream = Color.FromArgb(255, 248, 235);       // screen background
        public static readonly Color Text = Color.FromArgb(45, 35, 30);
        public static readonly Color SubText = Color.FromArgb(120, 100, 90);
        public static readonly Color Border = Color.FromArgb(236, 214, 190);
        public static readonly Color Disabled = Color.FromArgb(215, 200, 190);    // button that cannot be pressed yet
        public static readonly Color Hover = Color.FromArgb(255, 243, 214);       // meal card under the mouse

        // Fonts are created once and reused. The order list and the queue monitor are rebuilt often,
        // and creating a new Font every time wastes memory and system handles.
        private static readonly Dictionary<string, Font> fonts = new Dictionary<string, Font>();

        public static Font Font(float size, FontStyle style = FontStyle.Regular)
        {
            return GetFont("Segoe UI", size, style);
        }

        /// <summary>Heavy italic font for the store name.</summary>
        public static Font BrandFont(float size)
        {
            return GetFont("Segoe UI Black", size, FontStyle.Italic);
        }

        private static Font GetFont(string family, float size, FontStyle style)
        {
            string key = family + "|" + size + "|" + style;
            Font font;
            if (!fonts.TryGetValue(key, out font))
            {
                font = new Font(family, size, style);
                fonts[key] = font;
            }
            return font;
        }

        /// <summary>Flat button. A white button gets a red outline; colored buttons get no outline.</summary>
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
            button.FlatAppearance.BorderSize = back == Color.White ? 2 : 0;
            button.FlatAppearance.BorderColor = back == Color.White ? Red : back;
            button.FlatAppearance.MouseOverBackColor = Darken(back);
            button.FlatAppearance.MouseDownBackColor = Darken(Darken(back));
            return button;
        }

        public static Color Darken(Color color)
        {
            return Color.FromArgb(color.A, (int)(color.R * 0.9), (int)(color.G * 0.9), (int)(color.B * 0.9));
        }

        /// <summary>Rectangle with rounded corners, used by RoundedPanel.</summary>
        public static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            int d = Math.Max(1, Math.Min(radius * 2, Math.Min(r.Width, r.Height)));
            GraphicsPath path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        /// <summary>Warm "IMAGE" box shown where a meal picture would go.</summary>
        public static Image ImagePlaceholder()
        {
            Bitmap bmp = new Bitmap(170, 100);
            using (Graphics g = Graphics.FromImage(bmp))
            using (SolidBrush fill = new SolidBrush(YellowLight))
            using (SolidBrush brush = new SolidBrush(SubText))
            using (GraphicsPath path = RoundedRect(new Rectangle(0, 0, 169, 99), 10))
            using (StringFormat center = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent); // corners show the card color behind the picture
                g.FillPath(fill, path);
                // The font is shared (see Font above), so it is not disposed here.
                g.DrawString("IMAGE", Font(11f, FontStyle.Bold), brush, new RectangleF(0, 0, 170, 100), center);
            }
            return bmp;
        }
    }
}
