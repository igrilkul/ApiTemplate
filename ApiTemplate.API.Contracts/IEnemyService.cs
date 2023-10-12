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
    }
}
