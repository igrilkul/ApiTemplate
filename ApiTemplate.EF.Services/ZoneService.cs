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

        public async Task<Zone?> RemoveZoneAsync(int id)
        {
            var zoneToRemove = await GetZoneByIdAsync(id);

            if (zoneToRemove is null)
            {
                return null;
            }

            context.Zones.Remove(zoneToRemove);
            await this.context.SaveChangesAsync();

            return zoneToRemove;
        }

        public async Task<Zone?> UpdateZoneAsync(int id, Zone zoneToUpdate)
        {
            var dbZone = await GetZoneByIdAsync(id);

            if (dbZone is null)
            {
                return null;
            }


            dbZone.UpdateZone(zoneToUpdate.Name, zoneToUpdate.RequiredLevel, zoneToUpdate.Description);
            await this.context.SaveChangesAsync();

            return dbZone;
        }
    }
}
