using ApiTemplate.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTemplate.API.Contracts
{
    public interface ICharacterService
    {
        public Task<List<Character>> GetAllCharactersAsync();
        public Task<Character?> GetCharacterByIdAsync(int id);
        public Task<Character> AddCharacterAsync(Character request);
        public Task<Character?> UpdateCharacterAsync(int id, Character request);
        public Task<Character?> RemoveCharacterAsync(int id);
        public Task<Character?> LevelUpCharacterAsync(int id, int levels);
    }
}
