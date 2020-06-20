using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicle.DBModels;

namespace Vehicle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakeMastersController : ControllerBase
    {
        private readonly VehicleManagementContext _context;

        public VehicleMakeMastersController(VehicleManagementContext context)
        {
            _context = context;
        }

        // GET: api/VehicleMakeMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleMakeMaster>>> GetVehicleMakeMaster()
        {
            return await _context.VehicleMakeMaster.ToListAsync();
        }

        // GET: api/VehicleMakeMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleMakeMaster>> GetVehicleMakeMaster(int id)
        {
            var vehicleMakeMaster = await _context.VehicleMakeMaster.FindAsync(id);

            if (vehicleMakeMaster == null)
            {
                return NotFound();
            }

            return vehicleMakeMaster;
        }

        // PUT: api/VehicleMakeMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleMakeMaster(int id, VehicleMakeMaster vehicleMakeMaster)
        {
            if (id != vehicleMakeMaster.VehicleMakeId)
            {
                return BadRequest();
            }

            _context.Entry(vehicleMakeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleMakeMasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VehicleMakeMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VehicleMakeMaster>> PostVehicleMakeMaster(VehicleMakeMaster vehicleMakeMaster)
        {
            _context.VehicleMakeMaster.Add(vehicleMakeMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleMakeMaster", new { id = vehicleMakeMaster.VehicleMakeId }, vehicleMakeMaster);
        }

        // DELETE: api/VehicleMakeMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleMakeMaster>> DeleteVehicleMakeMaster(int id)
        {
            var vehicleMakeMaster = await _context.VehicleMakeMaster.FindAsync(id);
            if (vehicleMakeMaster == null)
            {
                return NotFound();
            }

            _context.VehicleMakeMaster.Remove(vehicleMakeMaster);
            await _context.SaveChangesAsync();

            return vehicleMakeMaster;
        }

        private bool VehicleMakeMasterExists(int id)
        {
            return _context.VehicleMakeMaster.Any(e => e.VehicleMakeId == id);
        }
    }
}
