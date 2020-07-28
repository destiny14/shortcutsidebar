namespace ShortcutSidebar.Data.Persistence
{
    public interface IPersistenceProvider
    {
        void Save();
        void Load();
        CommandScheme CurrentCommandScheme { get; }
    }
}