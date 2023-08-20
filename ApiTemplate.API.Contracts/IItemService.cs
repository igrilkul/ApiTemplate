using ApiTemplate.DAL.Models;

namespace ApiTemplate.API.Contracts
{
    public interface IItemService
    {
        public Task<List<Item>> GetAllItemsAsync();
        public Task<Item?> GetItemByIdAsync(int id);
        public Task<Item> AddItemAsync(Item request);
        public Task<Item?> UpdateItemAsync(int id, Item request);
        public Task<Item?> RemoveItemAsync(int id);
    }
}