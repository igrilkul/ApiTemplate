using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextualRPG.DAL.Models;

namespace TextualRPG.API.Contracts
{
    public interface IZoneService
    {
        public Task<List<Zone>> GetAllZonesAsync();
        public Task<Zone?> GetZoneByIdAsync(int id);
        public Task<Zone> AddZoneAsync(Zone zoneToAdd);
        public Task<Zone?> UpdateZoneAsync(int id, Zone zone);
        public Task<Zone?> RemoveZoneAsync(int id);
    }
}
