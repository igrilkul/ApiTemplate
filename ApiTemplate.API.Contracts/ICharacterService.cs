using TextualRPG.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextualRPG.API.Contracts
{
    public interface ICharacterService
    {
        public Task<List<Character>> GetAllCharactersAsync();
        public Task<Character?> GetCharacterByIdAsync(int id);
        public Task<Character> AddCharacterAsync(Character request);
        public Task<Character?> UpdateCharacterAsync(int id, Character request);
        public Task<Character?> RemoveCharacterAsync(int id);
        public Task<Character?> LevelUpCharacterAsync(int id, int levels);
        public Task<Character?> RepairItemAsync(int characterId, int itemId);
        public Task<Character?> EnhanceItemAsync(int characterId, int itemId);
        public Task<Character?> ObtainItemAsync(int characterId, int itemId);
    }
}
