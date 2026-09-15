using RSVP_App.DataAccess;

namespace RSVP_App;

public partial class LoginPage : ContentPage
{
    private readonly AppDatabase database;

    public LoginPage()
    {
        InitializeComponent();

        database = new AppDatabase();
    }

    private async void OnLoginClicked(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
            string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            lblMessage.Text =
                "Enter your user name and password.";

            return;
        }

        var user = await database.LoginAsync(
            txtUserName.Text,
            txtPassword.Text);

        if (user is null)
        {
            lblMessage.Text =
                "Invalid user name or password.";

            return;
        }

        SessionState.CurrentUser = user;
        SessionState.IsGuest = false;

        lblMessage.Text = string.Empty;

        await Navigation.PushAsync(new HomePage());
    }

    private async void OnGuestClicked(
        object sender,
        EventArgs e)
    {
        SessionState.CurrentUser = null;
        SessionState.IsGuest = true;

        await Navigation.PushAsync(new HomePage());
    }

    private async void OnAddUserClicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PushAsync(
            new AddUserPage());
    }
}