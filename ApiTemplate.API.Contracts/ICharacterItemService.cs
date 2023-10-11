using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextualRPG.DAL.Models;

namespace TextualRPG.API.Contracts
{
    public interface ICharacterItemService
    {
        public Task<List<CharacterItem>> GetAllCharacterItemsAsync();
        public Task<CharacterItem?> GetCharacterItemByIdAsync(int id);
        public Task<CharacterItem> AddCharacterItemAsync(CharacterItem request);
        public Task<CharacterItem?> UpdateCharacterItemAsync(int id, CharacterItem request);
        public Task<CharacterItem?> RemoveCharacterItemAsync(int id);
    }
}
