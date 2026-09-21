namespace MauiBasicAuth
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(
            object sender,
            EventArgs e)
        {
            string username =
                txtUserId.Text ?? string.Empty;

            string password =
                txtPassword.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert(
                    "Error",
                    "Enter a username and password.",
                    "OK");

                return;
            }

            try
            {
                var userAuth =
                    new DataAccess.UserAuthentication();

                bool isAuthenticated =
                    await userAuth.AuthenticateUserAsync(
                        username,
                        password);

                if (isAuthenticated)
                {
                    await DisplayAlert(
                        "Success",
                        "User authenticated successfully!",
                        "OK");
                }
                else
                {
                    await DisplayAlert(
                        "Error",
                        "Invalid username or password.",
                        "OK");
                }
            }
            catch
            {
                await DisplayAlert(
                    "Error",
                    "Unable to connect to the authentication service.",
                    "OK");
            }
        }
    }
}