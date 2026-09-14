namespace RSVP_App;

public partial class EventDetailsPage : ContentPage
{
    private readonly string eventName;

    public EventDetailsPage(
        string eventName,
        string date,
        string time,
        string location,
        string host)
    {
        InitializeComponent();

        this.eventName = eventName;

        lblEventName.Text = eventName;
        lblDate.Text = $"Date: {date}";
        lblTime.Text = $"Time: {time}";
        lblLocation.Text = $"Location: {location}";
        lblHost.Text = $"Hosted by: {host}";
    }

    private async void OnRSVPClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RSVPPage(eventName));
    }

    private async void OnGoBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}