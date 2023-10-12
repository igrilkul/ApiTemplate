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
            await this.context.Characters.AddAsync(characterToAdd);
            await this.context.SaveChangesAsync();
            return characterToAdd;
        }

        public async Task<List<Character>> GetAllCharactersAsync()
        {
            var characters = await this.context.Characters.ToListAsync();
            return characters;
        }

        public async Task<Character?> GetCharacterByIdAsync(int id)
        {
            return await this.context.Characters.FindAsync(id);
        }

        public async Task<Character?> LevelUpCharacterAsync(int id, int levels)
        {
            var dbCharacter = await GetCharacterByIdAsync(id);

            if (dbCharacter is null)
            {
                return null;
            }

            dbCharacter.LevelUpCharacter(id, levels);

            await this.context.SaveChangesAsync();

            return dbCharacter;
        }

        public async Task<Character?> RemoveCharacterAsync(int id)
        {
            var dbCharacter = await GetCharacterByIdAsync(id);

            if(dbCharacter is null)
            {
                return null;
            }

            this.context.Characters.Remove(dbCharacter);
            await this.context.SaveChangesAsync();
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

            await this.context.SaveChangesAsync();

            return dbCharacter;
        }

        public async Task<Character?> RepairItemAsync(int characterId, int itemId)
        {
            //ToDo: check item type, figure out a way to await charItem and if it is necessary or not to await it
            var character = context.Characters
            .Include(c => c.CharacterItems)
            .FirstOrDefault(c => c.Id == characterId);

            if (character is null)
            {
                return null;
            }

            character.CharacterItems.First(ci => ci.Item?.Id == itemId).RepairItem();
            await context.SaveChangesAsync();

            return character;
        }

        public async Task<Character?> EnhanceItemAsync(int characterId, int itemId)
        {
            //ToDo: check item type, figure out a way to await charItem and if it is necessary or not to await it
            var character = context.Characters
            .Include(c => c.CharacterItems)
            .FirstOrDefault(c => c.Id == characterId);

            if (character is null)
            {
                return null;
            }

            character.CharacterItems.First(ci => ci.Item?.Id == itemId).EnhanceItem();
            await context.SaveChangesAsync();

            return character;
        }
    }
}
