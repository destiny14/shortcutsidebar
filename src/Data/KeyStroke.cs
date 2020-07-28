namespace ShortcutSidebar.Data
{
    using System.Collections.Generic;
    using WindowsInput.Native;

    public class KeyStroke
    {
        public IEnumerable<VirtualKeyCode> ModifierKeys { get; set; }
        public IEnumerable<VirtualKeyCode> KeyStrokes { get; set; }
    }
}