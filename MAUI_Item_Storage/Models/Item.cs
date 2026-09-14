using SQLite;

namespace MAUI_Item_Storage.Models
{
    public class Item
    {
        [PrimaryKey]
        public int ItemID { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public string ItemDescription { get; set; } = string.Empty;
    }
}