using SQLite;

namespace RSVP_API.Models
{
    public static class DatabaseConstants
    {
        public const string DatabaseFilename = "RSVPApp.db3";

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