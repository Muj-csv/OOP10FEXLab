using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OOP10FEXLab.UI
{
    /// <summary>A Panel with rounded corners. Used for meal cards, order rows and the queue monitor columns.</summary>
    internal class RoundedPanel : Panel
    {
        public int Radius { get; set; }
        public Color BorderColor { get; set; }

        public RoundedPanel()
        {
            Radius = 14;
            BorderColor = Color.Empty;
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Paint the corners in the parent's color, then the rounded card on top.
            e.Graphics.Clear(Parent != null ? Parent.BackColor : SystemColors.Control);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = Theme.RoundedRect(new Rectangle(0, 0, Width - 1, Height - 1), Radius))
            using (SolidBrush fill = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(fill, path);
                if (BorderColor != Color.Empty)
                {
                    using (Pen pen = new Pen(BorderColor))
                        e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}
