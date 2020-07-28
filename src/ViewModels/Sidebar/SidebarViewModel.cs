namespace ShortcutSidebar.ViewModels.Sidebar
{
    using System;
    using System.Collections.ObjectModel;
    using Data;
    using Data.Persistence;

    public class SidebarViewModel : ViewModelBase
    {
        public ObservableCollection<SidebarCommandViewModel> SidebarCommandViewModels { get; } = new ObservableCollection<SidebarCommandViewModel>();

        public SidebarViewModel(IPersistenceProvider persistenceProvider,
            Func<Command, SidebarCommandViewModel> commandViewModelCreator)
        {
            foreach (var command in persistenceProvider.CurrentCommandScheme.Commands)
            {
                SidebarCommandViewModels.Add(commandViewModelCreator(command));
            }
        }
    }
}