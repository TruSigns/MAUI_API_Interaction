using RSVP_App.DataAccess;
using RSVP_App.Models;

namespace RSVP_App;

public partial class EventsPage : ContentPage
{
    private readonly AppDatabase database;

    private readonly string eventType;

    public EventsPage(string eventType)
    {
        InitializeComponent();

        database = new AppDatabase();

        this.eventType = eventType;

        lblPageTitle.Text = eventType;

        LoadEvents();
    }

    private async void LoadEvents()
    {
        List<Event> events;

        if (eventType == "Hosting" &&
            SessionState.CurrentUser is not null)
        {
            events =
                await database.GetHostedEventsAsync(
                    SessionState.CurrentUser.ID);
        }
        else if (
            eventType == "Attending" &&
            SessionState.CurrentUser is not null)
        {
            events =
                await database.GetAttendingEventsAsync(
                    SessionState.CurrentUser.ID);
        }
        else
        {
            events =
                await database.GetEventsAsync();
        }

        cvEvents.ItemsSource = events;
    }

    private async void OnEventSelected(
        object sender,
        SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault()
            is Event eventItem)
        {
            await Navigation.PushAsync(
                new EventDetailsPage(eventItem));

            cvEvents.SelectedItem = null;
        }
    }

    private async void OnGoBackClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PopAsync();
    }
}