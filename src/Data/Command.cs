namespace ShortcutSidebar.Data
{
    using System.Collections.Generic;

    public class Command
    {
        public string Name { get; set; }
        public IEnumerable<KeyStroke> KeyStrokes { get; set; }
    }
}