using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiBasicAuth.DataAccess;

namespace MauiBasicAuth.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly ApiService apiService;

        [ObservableProperty]
        private string userName = string.Empty;

        [ObservableProperty]
        private string password = string.Empty;

        [ObservableProperty]
        private string message = string.Empty;

        public LoginViewModel()
        {
            apiService = new ApiService();
        }

        [RelayCommand]
        private async Task Login()
        {
            if (string.IsNullOrWhiteSpace(UserName) ||
                string.IsNullOrWhiteSpace(Password))
            {
                Message = "Enter a user name and password.";
                return;
            }

            try
            {
                bool authenticated =
                    await apiService.AuthenticateUserAsync(
                        UserName,
                        Password);

                if (!authenticated)
                {
                    Message = "Login failed.";
                    return;
                }

                Message = string.Empty;

                await Shell.Current.GoToAsync(
                    nameof(DataEntryPage));
            }
            catch
            {
                Message =
                    "Unable to connect to the authentication service.";
            }
        }

        [RelayCommand]
        private void Cancel()
        {
            UserName = string.Empty;
            Password = string.Empty;
            Message = string.Empty;
        }
    }
}