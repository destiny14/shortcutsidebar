namespace ShortcutSidebar.ViewModels.Sidebar
{
    using WindowsInput;
    using Commands;
    using Data;

    public class SidebarCommandViewModel : ViewModelBase
    {
        private readonly Command _command;
        private readonly IInputSimulator _inputSimulator;
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand Execute { get; }

        public SidebarCommandViewModel(Command command, IInputSimulator inputSimulator)
        {
            _command = command;
            _inputSimulator = inputSimulator;
            Name = _command.Name;
            Execute = new RelayCommand(OnExecute);
        }

        private void OnExecute(object obj)
        {
            foreach (var keyStroke in _command.KeyStrokes)
            {
                _inputSimulator.Keyboard.ModifiedKeyStroke(keyStroke.ModifierKeys, keyStroke.KeyStrokes);
            }
        }
    }
}