namespace RSVP_App;

public partial class RSVPPage : ContentPage
{
    public RSVPPage(string eventName)
    {
        InitializeComponent();

        lblEventName.Text = eventName;

        if (!SessionState.IsGuest)
        {
            txtName.Text = SessionState.Name;
            txtEmail.Text = SessionState.Email;
        }
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text) ||
            string.IsNullOrWhiteSpace(txtEmail.Text) ||
            string.IsNullOrWhiteSpace(txtGuests.Text) ||
            pickerResponse.SelectedItem == null)
        {
            lblMessage.Text = "Please complete all fields.";
            return;
        }

        lblMessage.Text = "RSVP information validated.";

        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}