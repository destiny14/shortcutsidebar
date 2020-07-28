namespace ShortcutSidebar.ViewModels.Sidebar
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Interop;
    using Data;
    using Data.Persistence;
    using ScreenHandling;
    using UI.Windows;

    public class SidebarViewModel : ViewModelBase
    {
        private readonly SidebarWindow _window;
        private double _left;
        private double _top;
        private WorkspaceHelper.Rect _rect;
        public double Top
        {
            get => _top;
            set
            {
                if (Math.Abs(value - _top) < double.Epsilon) return;
                _top = value;
                OnPropertyChanged();
            }
        }

        public double Left
        {
            get => _left;
            set
            {
                if (Math.Abs(value - _left) < double.Epsilon) return;
                _left = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SidebarCommandViewModel> SidebarCommandViewModels { get; } = new ObservableCollection<SidebarCommandViewModel>();

        public SidebarViewModel(IPersistenceProvider persistenceProvider,
            Func<Command, SidebarCommandViewModel> commandViewModelCreator,
            SidebarWindow window)
        {
            _window = window;


            var primaryScreen = WpfScreen.Primary;

            Left = primaryScreen.DeviceBounds.Left;
            Top = primaryScreen.DeviceBounds.Height / 2f - 450f / 2f;

            WorkspaceHelper.CreateAppBarArea(new WindowInteropHelper(_window).EnsureHandle());

            foreach (var command in persistenceProvider.CurrentCommandScheme.Commands)
            {
                SidebarCommandViewModels.Add(commandViewModelCreator(command));
            }
        }
    }
}