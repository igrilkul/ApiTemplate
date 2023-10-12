using TextualRPG.DAL.Models;

namespace TextualRPG.API.Contracts
{
    public interface IItemService
    {
        public Task<List<Item>> GetAllItemsAsync();
        public Task<Item?> GetItemByIdAsync(int id);
 
    }
}