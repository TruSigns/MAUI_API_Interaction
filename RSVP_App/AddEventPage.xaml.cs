using RSVP_App.DataAccess;
using RSVP_App.Models;

namespace RSVP_App;

public partial class AddEventPage : ContentPage
{
    private readonly AppDatabase database;

    public AddEventPage()
    {
        InitializeComponent();

        database = new AppDatabase();
    }

    private async void OnAddEventClicked(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtEventName.Text) ||
            string.IsNullOrWhiteSpace(txtDate.Text) ||
            string.IsNullOrWhiteSpace(txtTime.Text) ||
            string.IsNullOrWhiteSpace(txtLocation.Text) ||
            string.IsNullOrWhiteSpace(txtDescription.Text))
        {
            lblMessage.Text =
                "Please complete all fields.";

            return;
        }

        if (!DateTime.TryParse(
            txtDate.Text,
            out DateTime eventDate))
        {
            lblMessage.Text =
                "Enter a valid date.";

            return;
        }

        var eventItem = new Event
        {
            Name = txtEventName.Text,
            Date = eventDate,
            Time = txtTime.Text,
            Location = txtLocation.Text,
            Description = txtDescription.Text,

            HostUserID =
                SessionState.CurrentUser?.ID ?? 0
        };

        await database.AddEventAsync(eventItem);

        await DisplayAlert(
            "Success",
            "Event saved.",
            "OK");

        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PopAsync();
    }
}