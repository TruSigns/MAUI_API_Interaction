using RSVP_App.Models;

namespace RSVP_App
{
    public static class SessionState
    {
        public static User? CurrentUser { get; set; }

        public static bool IsGuest { get; set; }

        public static bool IsLoggedIn =>
            CurrentUser is not null;

        public static void Clear()
        {
            CurrentUser = null;
            IsGuest = false;
        }
    }
}