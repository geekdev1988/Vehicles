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
    [Route("[controller]")]
    [ApiController]
    public class VehicleCategoryMastersController : ControllerBase
    {
        private readonly VehicleManagementContext _context;

        public VehicleCategoryMastersController(VehicleManagementContext context)
        {
            _context = context;
        }

        // GET: api/VehicleCategoryMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleCategoryMaster>>> GetVehicleCategoryMaster()
        {
            return await _context.VehicleCategoryMaster.ToListAsync();
        }

        // GET: api/VehicleCategoryMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleCategoryMaster>> GetVehicleCategoryMaster(int id)
        {
            var vehicleCategoryMaster = await _context.VehicleCategoryMaster.FindAsync(id);

            if (vehicleCategoryMaster == null)
            {
                return NotFound();
            }

            return vehicleCategoryMaster;
        }

        // PUT: api/VehicleCategoryMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleCategoryMaster(int id, VehicleCategoryMaster vehicleCategoryMaster)
        {
            if (id != vehicleCategoryMaster.VehicleTypeId)
            {
                return BadRequest();
            }

            _context.Entry(vehicleCategoryMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleCategoryMasterExists(id))
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

        // POST: api/VehicleCategoryMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VehicleCategoryMaster>> PostVehicleCategoryMaster(VehicleCategoryMaster vehicleCategoryMaster)
        {
            _context.VehicleCategoryMaster.Add(vehicleCategoryMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleCategoryMaster", new { id = vehicleCategoryMaster.VehicleTypeId }, vehicleCategoryMaster);
        }

        // DELETE: api/VehicleCategoryMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleCategoryMaster>> DeleteVehicleCategoryMaster(int id)
        {
            var vehicleCategoryMaster = await _context.VehicleCategoryMaster.FindAsync(id);
            if (vehicleCategoryMaster == null)
            {
                return NotFound();
            }

            _context.VehicleCategoryMaster.Remove(vehicleCategoryMaster);
            await _context.SaveChangesAsync();

            return vehicleCategoryMaster;
        }

        private bool VehicleCategoryMasterExists(int id)
        {
            return _context.VehicleCategoryMaster.Any(e => e.VehicleTypeId == id);
        }
    }
}
