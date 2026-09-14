namespace RSVP_App;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string userName = txtUserName.Text ?? string.Empty;
        string password = txtPassword.Text ?? string.Empty;

        if (userName == "Ruffin" && password == "Password1")
        {
            SessionState.IsGuest = false;
            SessionState.UserName = userName;
            SessionState.Name = "Maurice Ruffin";
            SessionState.Email = "maurice@example.com";

            lblMessage.Text = string.Empty;

            await Navigation.PushAsync(new HomePage());
        }
        else
        {
            lblMessage.Text = "Invalid user name or password.";
        }
    }

    private async void OnGuestClicked(object sender, EventArgs e)
    {
        SessionState.IsGuest = true;
        SessionState.UserName = "Guest";
        SessionState.Name = string.Empty;
        SessionState.Email = string.Empty;

        await Navigation.PushAsync(new HomePage());
    }

    private async void OnAddUserClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddUserPage());
    }
}