using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextualRPG.API.Contracts;
using TextualRPG.DAL.Models;
using TextualRPG.EF.Services;

namespace TextualRPG.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnemyController : ControllerBase
    {
        private readonly IEnemyService service;
        public EnemyController(IEnemyService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enemy>>> Get()
            => Ok(await service.GetAllEnemiesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Enemy>>> Get(int id)
        {
            var Enemy = await service.GetEnemyByIdAsync(id);

            if (Enemy == null)
            {
                return BadRequest("Enemy not found.");
            }

            return Ok(Enemy);
        }

        [HttpPost]
        public async Task<ActionResult<Enemy>> AddEnemy(Enemy Enemy)
            => Ok(await service.AddEnemyAsync(Enemy));

        [HttpPut("{id}")]
        public async Task<ActionResult<Enemy>> UpdateEnemy(int id, Enemy EnemyRequest)
        {
            var Enemy = await service.UpdateEnemyAsync(id, EnemyRequest);

            if (Enemy == null)
            {
                return BadRequest("Enemy not found.");
            }

            return Ok(Enemy);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Enemy = await service.RemoveEnemyAsync(id);

            if (Enemy == null)
            {
                return BadRequest("Enemy not found.");
            }

            return NoContent();
        }
    }
}
