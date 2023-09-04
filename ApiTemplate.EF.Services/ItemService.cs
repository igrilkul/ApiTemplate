using TextualRPG.API.Contracts;
using TextualRPG.DAL.Data;
using TextualRPG.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace TextualRPG.EF.Services
{
    public class ItemService : IItemService
    {
        private readonly DataContext context;

        public ItemService(DataContext context)
        {
            this.context = context;
        }


        public async Task<List<Item>> GetAllItemsAsync()
            => new List<Item>(await context.Items.ToListAsync());

        public async Task<Item?> GetItemByIdAsync(int id)
            => await context.Items.FindAsync(id);

        public async Task<Item> AddItemAsync(Item itemToAdd)
        {
            await context.Items.AddAsync(itemToAdd);
            await context.SaveChangesAsync();
            return itemToAdd;
        }

        public async Task<Item?> UpdateItemAsync(int id, Item itemToUpdate)
        {
            Item? dbItem = await context.Items.FindAsync(id);

            if (dbItem is null)
                return null;

            dbItem.UpdateItem(itemToUpdate.Title, itemToUpdate.Description, itemToUpdate.Price, itemToUpdate.Type);

            await context.SaveChangesAsync();

            return dbItem;
        }

        public async Task<Item?> RemoveItemAsync(int id)
        {
            var dbItem = await GetItemByIdAsync(id);

            if (dbItem is null)
                return null;

            context.Items.Remove(dbItem);
            await context.SaveChangesAsync();
            return dbItem;
        }
    }
}