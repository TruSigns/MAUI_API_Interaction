namespace RSVP_App;

public partial class AddEventPage : ContentPage
{
    public AddEventPage()
    {
        InitializeComponent();
    }

    private async void OnAddEventClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtEventName.Text) ||
            string.IsNullOrWhiteSpace(txtDate.Text) ||
            string.IsNullOrWhiteSpace(txtTime.Text) ||
            string.IsNullOrWhiteSpace(txtLocation.Text) ||
            string.IsNullOrWhiteSpace(txtDescription.Text))
        {
            lblMessage.Text = "Please complete all fields.";
            return;
        }

        lblMessage.Text = "Event information validated.";

        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}