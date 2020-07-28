namespace ShortcutSidebar.Data
{
    using System.Collections.Generic;

    public class CommandScheme
    {
        public string ProcessName { get; set; }
        public IEnumerable<Command> Commands { get; set; }

        // TODO
        // prop SidebarLayout SidebarLayout
    }
}