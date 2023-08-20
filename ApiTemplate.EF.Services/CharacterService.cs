using ApiTemplate.API.Contracts;
using ApiTemplate.DAL.Data;
using ApiTemplate.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTemplate.EF.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly DataContext context;
        public CharacterService(DataContext context)
        {
            this.context = context;
        }

        public async Task<Character> AddCharacterAsync(Character characterToAdd)
        {
            await context.Characters.AddAsync(characterToAdd);
            await context.SaveChangesAsync();
            return characterToAdd;
        }

        public async Task<List<Character>> GetAllCharactersAsync()
        {
            return new List<Character>(await context.Characters.ToListAsync());
        }

        public async Task<Character?> GetCharacterByIdAsync(int id)
        {
            return await context.Characters.FindAsync(id);
        }

        public async Task<Character?> LevelUpCharacterAsync(int id, int levels)
        {
            var dbCharacter = await GetCharacterByIdAsync(id);

            if (dbCharacter is null)
            {
                return null;
            }

            dbCharacter.LevelUpCharacter(id, levels);

            await context.SaveChangesAsync();

            return dbCharacter;
        }

        public async Task<Character?> RemoveCharacterAsync(int id)
        {
            var dbCharacter = await GetCharacterByIdAsync(id);

            if(dbCharacter is null)
            {
                return null;
            }

            context.Characters.Remove(dbCharacter);
            await context.SaveChangesAsync();
            return dbCharacter;
        }

        public async Task<Character?> UpdateCharacterAsync(int id, Character characterToUpdate)
        {
            Character? dbCharacter = await context.Characters.FindAsync(id);

            if (dbCharacter is null)
            {
                return null;
            }

            dbCharacter.UpdateCharacter(characterToUpdate.Name, characterToUpdate.Level, characterToUpdate.ClassName);

            await context.SaveChangesAsync();

            return dbCharacter;
        }
    }
}
