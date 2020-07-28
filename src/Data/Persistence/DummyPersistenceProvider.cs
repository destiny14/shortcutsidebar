namespace ShortcutSidebar.Data.Persistence
{
    using System.Collections.Generic;
    using WindowsInput.Native;

    public class DummyPersistenceProvider : IPersistenceProvider
    {
        private CommandScheme _currentCommandScheme;

        public void Save()
        {
        }

        public void Load()
        {
            _currentCommandScheme = new CommandScheme();
            var commands = new List<Command>
            {
                new Command
                {
                    Name = "Undo",
                    KeyStrokes = new[]
                    {
                        new KeyStroke
                        {
                            ModifierKeys = new []{VirtualKeyCode.MENU,VirtualKeyCode.CONTROL},
                            KeyStrokes = new[] {VirtualKeyCode.VK_Z}
                        }
                    }
                },
                new Command
                {
                    Name = "Redo",
                    KeyStrokes = new[]
                    {
                        new KeyStroke
                        {
                            ModifierKeys = new []{VirtualKeyCode.SHIFT,VirtualKeyCode.CONTROL},
                            KeyStrokes = new[] {VirtualKeyCode.VK_Z}
                        }
                    }
                }
            };
            _currentCommandScheme.Commands = commands;
        }

        public CommandScheme CurrentCommandScheme
        {
            get
            {
                if (_currentCommandScheme == null) Load();
                return _currentCommandScheme;
            }
        }
    }
}