namespace ShortcutSidebar.ScreenHandling
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Interop;
    using Point = System.Drawing.Point;
    using Size = System.Drawing.Size;

    public class WpfScreen
    {
        public static Size GetTotalWorkingArea()
        {
            int maxX = 0, maxY = 0;
            foreach (var allScreen in Screen.AllScreens)
            {
                maxX += allScreen.WorkingArea.Width;
                maxY += allScreen.WorkingArea.Height;
            }

            return new Size(maxX, maxY);
        }

        public static IEnumerable<WpfScreen> AllScreens()
        {
            foreach (var screen in Screen.AllScreens)
            {
                yield return new WpfScreen(screen);
            }
        }

        public static WpfScreen GetScreenFrom(Window window)
        {
            var windowInteropHelper = new WindowInteropHelper(window);
            var screen = Screen.FromHandle(windowInteropHelper.Handle);
            var wpfScreen = new WpfScreen(screen);
            return wpfScreen;
        }

        public static WpfScreen GetScreenFrom(Point point)
        {
            var x = (int)Math.Round((double)point.X);
            var y = (int)Math.Round((double)point.Y);

            // are x,y device-independent-pixels ??
            var drawingPoint = new System.Drawing.Point(x, y);
            var screen = Screen.FromPoint(drawingPoint);
            var wpfScreen = new WpfScreen(screen);

            return wpfScreen;
        }

        public static WpfScreen Primary => new WpfScreen(Screen.PrimaryScreen);

        private readonly Screen _screen;

        internal WpfScreen(Screen screen)
        {
            _screen = screen;
        }

        public Rect DeviceBounds => GetRect(_screen.Bounds);

        public Rect WorkingArea => GetRect(_screen.WorkingArea);

        private Rect GetRect(Rectangle value)
        {
            // should x, y, width, height be device-independent-pixels ??
            return new Rect
            {
                X = value.X,
                Y = value.Y,
                Width = value.Width,
                Height = value.Height
            };
        }

        public bool IsPrimary => _screen.Primary;

        public string DeviceName => _screen.DeviceName;
    }
}