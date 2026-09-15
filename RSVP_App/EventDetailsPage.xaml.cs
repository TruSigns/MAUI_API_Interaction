using RSVP_App.Models;

namespace RSVP_App;

public partial class EventDetailsPage : ContentPage
{
    private readonly Event eventItem;

    public EventDetailsPage(Event eventItem)
    {
        InitializeComponent();

        this.eventItem = eventItem;

        lblEventName.Text =
            eventItem.Name;

        lblDate.Text =
            $"Date: {eventItem.Date:MM/dd/yyyy}";

        lblTime.Text =
            $"Time: {eventItem.Time}";

        lblLocation.Text =
            $"Location: {eventItem.Location}";

        lblHost.Text =
            $"Description: {eventItem.Description}";
    }

    private async void OnRSVPClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new RSVPPage(eventItem));
    }

    private async void OnGoBackClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PopAsync();
    }
}