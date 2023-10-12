using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextualRPG.DAL.Models;

namespace TextualRPG.API.Contracts
{
    public interface IEnemyService
    {
        public Task<List<Enemy>> GetAllEnemiesAsync();
        public Task<Enemy?> GetEnemyByIdAsync(int id);
        public Task<Enemy> AddEnemyAsync(Enemy request);
        public Task<Enemy?> UpdateEnemyAsync(int id, Enemy request);
        public Task<Enemy?> RemoveEnemyAsync(int id);
    }
}
