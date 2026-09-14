namespace RSVP_App;

public partial class EventsPage : ContentPage
{
    public EventsPage(string pageTitle)
    {
        InitializeComponent();

        lblPageTitle.Text = pageTitle;
    }

    private async void OnBirthdayClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            new EventDetailsPage(
                "Birthday Dinner",
                "September 25, 2026",
                "6:00 PM",
                "Raleigh, NC",
                "Maurice Ruffin"));
    }

    private async void OnMeetupClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            new EventDetailsPage(
                "Software Meetup",
                "October 10, 2026",
                "7:00 PM",
                "Durham, NC",
                "Maurice Ruffin"));
    }

    private async void OnCookoutClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            new EventDetailsPage(
                "Family Cookout",
                "October 17, 2026",
                "3:00 PM",
                "Raleigh, NC",
                "Maurice Ruffin"));
    }

    private async void OnGoBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}