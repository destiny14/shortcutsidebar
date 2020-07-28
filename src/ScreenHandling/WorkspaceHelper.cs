namespace ShortcutSidebar.ScreenHandling
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public static class WorkspaceHelper
    {
        [DllImport("shell32.dll")]
        private static extern IntPtr SHAppBarMessage(uint dwMessage,
            ref Appbardata pData);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern uint RegisterWindowMessage(string lpString);
        
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Appbardata
        {
            public uint cbSize;
            public IntPtr hWnd;
            public uint uCallbackMessage;
            public uint uEdge;
            public Rect rc;
            public int lParam;
        }

        private const int AbmNew = 0x00000000;
        private const int AbmRemove = 0x00000001;
        private const int AbmSetpos = 0x00000003;
        private const int AbmQuerypos = 0x00000002;

        private const int AbeLeft = 0;

        public static void CreateAppBarArea(IntPtr hWnd)
        {
            var abd = new Appbardata
            {
                cbSize = (uint) Marshal.SizeOf(typeof(Appbardata)),
                hWnd = hWnd,
                uCallbackMessage = RegisterWindowMessage(Guid.NewGuid().ToString())
            };

            SHAppBarMessage(AbmNew, ref abd);

            abd.rc = new Rect();
            abd.uEdge = AbeLeft;
            abd.rc.Top = 0;
            abd.rc.Left = 0;
            abd.rc.Bottom = SystemInformation.PrimaryMonitorSize.Height;
            abd.rc.Right = 120;

            SHAppBarMessage(AbmQuerypos, ref abd);

            SHAppBarMessage(AbmSetpos, ref abd);
        }

        public static void ResetAppBarArea(IntPtr hWnd)
        {
            var abd = new Appbardata {cbSize = (uint) Marshal.SizeOf(typeof(Appbardata)), hWnd = hWnd};

            SHAppBarMessage(AbmRemove, ref abd);
        }
    }
}