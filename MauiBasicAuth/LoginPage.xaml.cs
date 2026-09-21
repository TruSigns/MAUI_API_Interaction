using MauiBasicAuth.ViewModels;

namespace MauiBasicAuth;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

        BindingContext = new LoginViewModel();
    }
}