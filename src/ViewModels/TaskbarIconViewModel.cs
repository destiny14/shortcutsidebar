namespace ShortcutSidebar.ViewModels
{
    using System;
    using System.Windows;
    using Commands;
    using Sidebar;
    using UI.Windows;

    public class TaskbarIconViewModel : ViewModelBase
    {
        public RelayCommand ExitCommand { get; }

        public TaskbarIconViewModel(Func<SidebarWindow, SidebarViewModel> sidebarViewModelCreator)
        {
            var sidebarWindow = new SidebarWindow();
            sidebarWindow.DataContext = sidebarViewModelCreator(sidebarWindow);

            sidebarWindow.Show();

            ExitCommand = new RelayCommand(o => Application.Current.Shutdown());
        }
    }
}