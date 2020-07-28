namespace ShortcutSidebar.UI.Windows
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows.Interop;
    using ScreenHandling;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SidebarWindow
    {
        public SidebarWindow()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            //Set the window style to noactivate.
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SetWindowLong(helper.Handle, GWL_EXSTYLE,
                GetWindowLong(helper.Handle, GWL_EXSTYLE) | WS_EX_NOACTIVATE);
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            WorkspaceHelper.ResetAppBarArea(new WindowInteropHelper(this).Handle);

            base.OnClosing(e);

        }

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_NOACTIVATE = 0x08000000;

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    }
}
