using SQLite;
using MAUI_Item_Storage.Models;

namespace MAUI_Item_Storage.DataAccess
{
    public class ItemData
    {
        private SQLiteAsyncConnection? database;

        private async Task Init()
        {
            if (database is not null)
            {
                return;
            }

            database = new SQLiteAsyncConnection(
                DatabaseConstants.DatabasePath,
                DatabaseConstants.Flags);

            await database.CreateTableAsync<Item>();
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            await Init();

            return await database!
                .Table<Item>()
                .ToListAsync();
        }

        public async Task<int> SaveItemAsync(Item item)
        {
            await Init();

            return await database!.InsertAsync(item);
        }
    }
}