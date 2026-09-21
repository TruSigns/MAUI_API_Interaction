using MauiBasicAuth.ViewModels;

namespace MauiBasicAuth;

public partial class DataEntryPage : ContentPage
{
    private readonly DataEntryViewModel viewModel;

    public DataEntryPage()
    {
        InitializeComponent();

        viewModel =
            new DataEntryViewModel();

        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await viewModel.LoadItemsAsync();
    }
}