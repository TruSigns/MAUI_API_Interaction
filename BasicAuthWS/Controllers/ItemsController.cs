using BasicAuthWS.DataAccess;
using BasicAuthWS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuthWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemData itemData;

        public ItemsController(ItemData itemData)
        {
            this.itemData = itemData;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> Get()
        {
            var items = await itemData.GetItemsAsync();

            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Item item)
        {
            if (item.ItemID <= 0 ||
                string.IsNullOrWhiteSpace(item.ItemName) ||
                string.IsNullOrWhiteSpace(item.ItemDescription))
            {
                return BadRequest("All fields are required.");
            }

            try
            {
                await itemData.SaveItemAsync(item);

                return Ok(item);
            }
            catch
            {
                return BadRequest("Unable to save item.");
            }
        }
    }
}