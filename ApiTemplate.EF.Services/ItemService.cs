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

     
    }
}