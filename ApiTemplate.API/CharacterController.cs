using TextualRPG.API.Contracts;
using TextualRPG.DAL.Models;
using TextualRPG.EF.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextualRPG.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService service;

        public CharacterController(ICharacterService service)
        {
            this.service = (CharacterService)service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> Get()
        {
            return Ok(await service.GetAllCharactersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Character>>> Get(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);

            if(character == null)
            {
                return BadRequest("Character not found.");
            }

            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<Character>> AddCharacter(Character character)
        {
            return Ok(await service.AddCharacterAsync(character));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Character>> UpdateCharacter(int id, Character characterRequest)
        {
            var character = await service.UpdateCharacterAsync(id, characterRequest);

            if(character == null)
            {
                return BadRequest("Character not found.");
            }

            return Ok(character);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Character>> LevelUpCharacter(int id, int levels)
        {
            var character = await service.LevelUpCharacterAsync(id, levels);

            if (character == null)
            {
                return BadRequest("Character not found.");
            }

            return Ok(character);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var character = await service.RemoveCharacterAsync(id);

            if (character == null)
            {
                return BadRequest("Character not found.");
            }
             
            return NoContent();
        }
    }
}
