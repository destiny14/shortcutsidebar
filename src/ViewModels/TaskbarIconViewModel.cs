namespace ShortcutSidebar.ViewModels
{
    using System.Windows;
    using Commands;
    using Sidebar;
    using UI.Windows;

    public class TaskbarIconViewModel : ViewModelBase
    {
        public RelayCommand ExitCommand { get; }

        public TaskbarIconViewModel(SidebarViewModel sidebarViewModel)
        {
            var sidebarWindow = new SidebarWindow
            {
                DataContext = sidebarViewModel
            };

            sidebarWindow.Show();

            ExitCommand = new RelayCommand(o => Application.Current.Shutdown());
        }
    }
}