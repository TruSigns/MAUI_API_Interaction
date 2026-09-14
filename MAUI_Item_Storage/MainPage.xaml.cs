using System.Collections.ObjectModel;
using MAUI_Item_Storage.DataAccess;
using MAUI_Item_Storage.Models;

namespace MAUI_Item_Storage
{
    public partial class MainPage : ContentPage
    {
        private readonly ItemData itemData;

        public ObservableCollection<Item> Items { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();

            itemData = new ItemData();

            BindingContext = this;

            UpdateItemsList();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemID.Text) ||
                string.IsNullOrWhiteSpace(txtItemName.Text) ||
                string.IsNullOrWhiteSpace(txtItemDescription.Text))
            {
                await DisplayAlert(
                    "Error",
                    "Please complete all fields.",
                    "OK");

                return;
            }

            if (!int.TryParse(txtItemID.Text, out int itemId))
            {
                await DisplayAlert(
                    "Error",
                    "Item ID must be a number.",
                    "OK");

                return;
            }

            var item = new Item
            {
                ItemID = itemId,
                ItemName = txtItemName.Text,
                ItemDescription = txtItemDescription.Text
            };

            try
            {
                await itemData.SaveItemAsync(item);
            }
            catch
            {
                await DisplayAlert(
                    "Error",
                    "That Item ID already exists.",
                    "OK");

                return;
            }

            txtItemID.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtItemDescription.Text = string.Empty;

            await UpdateItemsList();
        }

        private async Task UpdateItemsList()
        {
            var items = await itemData.GetItemsAsync();

            Items.Clear();

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}