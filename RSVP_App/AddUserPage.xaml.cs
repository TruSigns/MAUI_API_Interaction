using RSVP_App.DataAccess;
using RSVP_App.Models;

namespace RSVP_App;

public partial class AddUserPage : ContentPage
{
    private readonly AppDatabase database;

    public AddUserPage()
    {
        InitializeComponent();

        database = new AppDatabase();
    }

    private async void OnAddUserClicked(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
            string.IsNullOrWhiteSpace(txtLastName.Text) ||
            string.IsNullOrWhiteSpace(txtEmail.Text) ||
            string.IsNullOrWhiteSpace(txtUserName.Text) ||
            string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            lblMessage.Text =
                "Please complete all fields.";

            return;
        }

        var user = new User
        {
            FirstName = txtFirstName.Text,
            LastName = txtLastName.Text,
            Email = txtEmail.Text,
            UserName = txtUserName.Text,
            Password = txtPassword.Text
        };

        try
        {
            await database.AddUserAsync(user);

            await DisplayAlert(
                "Success",
                "User account created.",
                "OK");

            await Navigation.PopAsync();
        }
        catch
        {
            lblMessage.Text =
                "Unable to create user. The user name may already exist.";
        }
    }

    private async void OnCancelClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PopAsync();
    }
}