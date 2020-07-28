namespace ShortcutSidebar
{
    using System.Windows;
    using Hardcodet.Wpf.TaskbarNotification;
    using Infrastructure;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bootstrapper.Start();

            Current.Exit += (sender, args) => Bootstrapper.Stop();
            
            var taskbarIcon = (TaskbarIcon)FindResource("TaskbarIcon");
            if (taskbarIcon == null) return;
            taskbarIcon.DataContext = Bootstrapper.RootVisual;
        }
    }
}