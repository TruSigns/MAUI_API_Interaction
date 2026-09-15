using SQLite;

namespace RSVP_App.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [Unique]
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}