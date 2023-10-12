using TextualRPG.API.Contracts;
using TextualRPG.DAL.Models;
using TextualRPG.EF.Services;
using Microsoft.AspNetCore.Mvc;

namespace TextualRPG.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {

        private readonly ItemService service;

        public ItemController(IItemService service)
        {
            this.service = (ItemService)service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> Get()
            => Ok(await service.GetAllItemsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Item>>> Get(int id)
        {
            var item = await service.GetItemByIdAsync(id);

            if (item == null)
            {
                return BadRequest("Item not found.");
            }

            return Ok(item);
        }

       
    }
}
