using RSVP_App.DataAccess;
using RSVP_App.Models;

namespace RSVP_App;

public partial class RSVPPage : ContentPage
{
    private readonly AppDatabase database;

    private readonly Event eventItem;

    public RSVPPage(Event eventItem)
    {
        InitializeComponent();

        database = new AppDatabase();

        this.eventItem = eventItem;

        lblEventName.Text =
            eventItem.Name;

        if (SessionState.CurrentUser is not null)
        {
            txtName.Text =
                $"{SessionState.CurrentUser.FirstName} {SessionState.CurrentUser.LastName}";

            txtEmail.Text =
                SessionState.CurrentUser.Email;
        }
    }

    private async void OnSubmitClicked(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text) ||
            string.IsNullOrWhiteSpace(txtEmail.Text) ||
            string.IsNullOrWhiteSpace(txtGuests.Text) ||
            pickerResponse.SelectedItem is null)
        {
            lblMessage.Text =
                "Please complete all fields.";

            return;
        }

        if (!int.TryParse(
            txtGuests.Text,
            out int numberOfGuests))
        {
            lblMessage.Text =
                "Enter a valid number of guests.";

            return;
        }

        var rsvp = new RSVP
        {
            EventID = eventItem.ID,

            UserID =
                SessionState.CurrentUser?.ID ?? 0,

            Name = txtName.Text,

            Email = txtEmail.Text,

            NumberOfGuests =
                numberOfGuests,

            Response =
                pickerResponse.SelectedItem.ToString()
                ?? string.Empty
        };

        await database.AddRSVPAsync(rsvp);

        await DisplayAlert(
            "Success",
            "RSVP saved.",
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