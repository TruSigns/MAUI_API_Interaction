using SQLite;

namespace RSVP_API.Models
{
    public class RSVP
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int EventID { get; set; }

        public int UserID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int NumberOfGuests { get; set; }

        public string Response { get; set; } = string.Empty;
    }
}