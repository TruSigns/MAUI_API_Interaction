namespace RSVP_App;

public static class SessionState
{
    public static bool IsGuest { get; set; }

    public static string UserName { get; set; } = string.Empty;

    public static string Name { get; set; } = string.Empty;

    public static string Email { get; set; } = string.Empty;

    public static void Clear()
    {
        IsGuest = false;
        UserName = string.Empty;
        Name = string.Empty;
        Email = string.Empty;
    }
}