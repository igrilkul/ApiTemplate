using TextualRPG.API.Contracts;
using TextualRPG.DAL.Data;
using TextualRPG.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextualRPG.EF.Services
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
            Character? dbCharacter = await GetCharacterByIdAsync(id);

            if (dbCharacter is null)
            {
                return null;
            }

            dbCharacter.UpdateCharacter(characterToUpdate.Name, characterToUpdate.Level, characterToUpdate.ClassName);

            await context.SaveChangesAsync();

            return dbCharacter;
        }

        public async Task<Character?> RepairItemAsync(int characterId, int itemId)
        {
            //ToDo: check item type, figure out a way to await charItem and if it is necessary or not to await it
            var character = await this.context.Characters
            .Include(c => c.CharacterItems)
            .ThenInclude(ci => ci.Item)
            .FirstOrDefaultAsync(c => c.Id == characterId);

            var charItem = character?.CharacterItems.FirstOrDefault(c => c.Item?.Id == itemId);

            charItem?.RepairItem(charItem);
            this.context.SaveChanges();

            if(character is null)
            {
                return null;
            }

            return character;

        }

        public async Task<Character?> EnhanceItemAsync(int characterId, int itemId)
        {
            //ToDo: check item type, figure out a way to await charItem and if it is necessary or not to await it
            var character = await this.context.Characters
            .Include(c => c.CharacterItems)
            .ThenInclude(ci => ci.Item)
            .FirstOrDefaultAsync(c => c.Id == characterId);

            var charItem = character?.CharacterItems.FirstOrDefault(c => c.Item?.Id == itemId);

            charItem?.EnhanceItem(charItem);
            this.context.SaveChanges();

            if (character is null)
            {
                return null;
            }

            return character;
        }
    }
}
