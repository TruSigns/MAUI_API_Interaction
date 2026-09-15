namespace RSVP_App;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();

        if (SessionState.IsGuest)
        {
            lblWelcome.Text = "Welcome, Guest";

            btnAttending.IsVisible = false;
            btnHosting.IsVisible = false;
        }
        else if (SessionState.CurrentUser is not null)
        {
            lblWelcome.Text =
                $"Welcome, {SessionState.CurrentUser.FirstName}";
        }
    }

    private async void OnAllEventsClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new EventsPage("All Events"));
    }

    private async void OnAttendingClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new EventsPage("Attending"));
    }

    private async void OnHostingClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new EventsPage("Hosting"));
    }

    private async void OnAddEventClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new AddEventPage());
    }

    private async void OnAddUserClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new AddUserPage());
    }

    private async void OnLogoutClicked(
        object sender,
        EventArgs e)
    {
        SessionState.Clear();

        await Navigation.PopToRootAsync();
    }
}