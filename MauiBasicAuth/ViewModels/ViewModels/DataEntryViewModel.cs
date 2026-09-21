using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiBasicAuth.DataAccess;
using MauiBasicAuth.Models;
using System.Collections.ObjectModel;

namespace MauiBasicAuth.ViewModels
{
    public partial class DataEntryViewModel : ObservableObject
    {
        private readonly ApiService apiService;

        [ObservableProperty]
        private string itemID = string.Empty;

        [ObservableProperty]
        private string itemName = string.Empty;

        [ObservableProperty]
        private string itemDescription = string.Empty;

        [ObservableProperty]
        private string message = string.Empty;

        public ObservableCollection<Item> Items { get; }
            = new();

        public DataEntryViewModel()
        {
            apiService = new ApiService();
        }

        public async Task LoadItemsAsync()
        {
            try
            {
                var items =
                    await apiService.GetItemsAsync();

                Items.Clear();

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch
            {
                Message =
                    "Unable to retrieve items.";
            }
        }

        [RelayCommand]
        private async Task Save()
        {
            if (string.IsNullOrWhiteSpace(ItemID) ||
                string.IsNullOrWhiteSpace(ItemName) ||
                string.IsNullOrWhiteSpace(ItemDescription))
            {
                Message =
                    "Please enter information in all fields.";

                return;
            }

            if (!int.TryParse(ItemID, out int id))
            {
                Message =
                    "Item ID must be a number.";

                return;
            }

            var item = new Item
            {
                ItemID = id,
                ItemName = ItemName,
                ItemDescription = ItemDescription
            };

            bool saved =
                await apiService.SaveItemAsync(item);

            if (!saved)
            {
                Message =
                    "Unable to save item.";

                return;
            }

            ItemID = string.Empty;
            ItemName = string.Empty;
            ItemDescription = string.Empty;

            Message = "Item saved.";

            await LoadItemsAsync();
        }
    }
}