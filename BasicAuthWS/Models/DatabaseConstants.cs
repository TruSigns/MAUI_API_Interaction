using SQLite;

namespace BasicAuthWS.Models
{
    public static class DatabaseConstants
    {
        public const string DatabaseFilename = "Items.db3";

        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(
                AppContext.BaseDirectory,
                DatabaseFilename);
    }
}