using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextualRPG.API.Contracts;
using TextualRPG.DAL.Data;
using TextualRPG.DAL.Models;

namespace TextualRPG.EF.Services
{
    public class ZoneService : IZoneService
    {
        private readonly DataContext context;
        public ZoneService(DataContext context)
        {
            this.context = context;
        }

        public async Task<Zone> AddZoneAsync(Zone zoneToAdd)
        {
            await this.context.AddAsync(zoneToAdd);
            await this.context.SaveChangesAsync();

            return zoneToAdd;
        }

        public async Task<List<Zone>> GetAllZonesAsync()
        {
            var zones = await this.context.Zones.ToListAsync<Zone>();
            return zones;
        }

        public async Task<Zone?> GetZoneByIdAsync(int id)
        {
            var zone = await this.context.Zones.FirstOrDefaultAsync(z=>z.Id == id);
            //ToDo check if null
            return zone;
        }

 
    }
}
