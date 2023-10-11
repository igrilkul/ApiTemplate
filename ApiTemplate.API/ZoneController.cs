using Microsoft.AspNetCore.Mvc;
using TextualRPG.API.Contracts;
using TextualRPG.DAL.Models;
using TextualRPG.EF.Services;

namespace TextualRPG.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZoneController : ControllerBase
    {
        private readonly ZoneService service;
        public ZoneController(IZoneService service)
        {
            this.service = (ZoneService)service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zone>>> Get()
        {
            return Ok(await service.GetAllZonesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Zone>>> Get(int id)
        {
            var zone = await service.GetZoneByIdAsync(id);

            if(zone is null)
            {
                return NotFound("Zone not found.");
            }

            return Ok(zone);
        }

        [HttpPost]
        public async Task<ActionResult<Zone>> AddZone(Zone zone)
        {
            return Ok(await service.AddZoneAsync(zone));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Zone>> UpdateZone(int id, Zone zoneRequest)
        {
            var zone = await service.UpdateZoneAsync(id, zoneRequest);
            if(zone is null)
            {
                return NotFound("Zone not found.");
            }

            return Ok(zone);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var zone = await service.RemoveZoneAsync(id);

            if(zone is null)
            {
                return NotFound("Zone not found.");
            }

            return NoContent();
        }
    }
}
