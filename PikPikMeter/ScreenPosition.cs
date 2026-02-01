using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikPikMeter
{
    /// <summary>
    /// Default screen position calculator and validator for the main window of the program.
    /// </summary>
    class ScreenPosition
    {
        /// <summary>Default size of main window.</summary>
        public static readonly Size DefaultSize = new Size(300, 128);
        /// <summary>Minimal size of main window.</summary>
        public static readonly Size MinSize = new Size(260, 60);
        private static readonly Size Margin = new Size(100, 160);

        /// <summary>
        /// Checks if main window is placed in a visible screen location
        /// and not outside the borders of the screen.
        /// </summary>
        public static bool IsValidLocation(Point location, Size size)
        {
            if (location == null || !IsValidSize(size))
                return false;
            Screen locationScreen = Screen.FromPoint(location);
            if (locationScreen == null)
                return false;
            Point endCorner = location;
            endCorner.Offset(size.Width, size.Height);
            return locationScreen.Bounds.Contains(location)
                || locationScreen.Bounds.Contains(endCorner);
        }

        /// <summary>
        /// Normalizes one or both dimensions of the size if they breach <see cref="MinSize"/>.
        /// </summary>
        public static Size NormalizedSize(Size size)
        {
            Size normalized = size;
            if (size.Width < MinSize.Width)
                normalized.Width = MinSize.Width;
            if (size.Height < MinSize.Height)
                normalized.Height = MinSize.Height;
            return normalized;
        }

        /// <summary>Checks if both size dimensions are within <see cref="MinSize"/>.</summary>
        public static bool IsValidSize(Size size)
        {
            return size != null && size.Width >= MinSize.Width && size.Height >= MinSize.Height;
        }

        /// <summary>
        /// Calculates default screen position for the main window, basing on where
        /// the mouse cursor is and using internal, predefined values for default
        /// size and screen edge distance.
        /// </summary>
        public static Point DefaultLocation()
        {
            Screen locationScreen = Screen.FromPoint(Cursor.Position);
            Point location = new Point(
                locationScreen.Bounds.Right - Margin.Width - DefaultSize.Width,
                locationScreen.Bounds.Bottom - Margin.Height - DefaultSize.Height);
            if (location.X < locationScreen.Bounds.Left)
                location.X = locationScreen.Bounds.Left;
            if (location.Y < locationScreen.Bounds.Top)
                location.Y = locationScreen.Bounds.Top;
            return location;
        }
    }
}
