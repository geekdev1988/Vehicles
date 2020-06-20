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
    public class VehicleDetailsController : ControllerBase
    {
        private readonly VehicleManagementContext _context;

        public VehicleDetailsController(VehicleManagementContext context)
        {
            _context = context;
        }

        // GET: api/VehicleDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDetail>>> GetVehicleDetail()
        {
            return await _context.VehicleDetail.ToListAsync();
        }

        // GET: api/VehicleDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDetail>> GetVehicleDetail(long id)
        {
            var vehicleDetail = await _context.VehicleDetail.FindAsync(id);

            if (vehicleDetail == null)
            {
                return NotFound();
            }

            return vehicleDetail;
        }

        // PUT: api/VehicleDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleDetail(long id, VehicleDetail vehicleDetail)
        {
            if (id != vehicleDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehicleDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleDetailExists(id))
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

        // POST: api/VehicleDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VehicleDetail>> PostVehicleDetail(VehicleDetail vehicleDetail)
        {
            _context.VehicleDetail.Add(vehicleDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleDetail", new { id = vehicleDetail.Id }, vehicleDetail);
        }

        // DELETE: api/VehicleDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleDetail>> DeleteVehicleDetail(long id)
        {
            var vehicleDetail = await _context.VehicleDetail.FindAsync(id);
            if (vehicleDetail == null)
            {
                return NotFound();
            }

            _context.VehicleDetail.Remove(vehicleDetail);
            await _context.SaveChangesAsync();

            return vehicleDetail;
        }

        private bool VehicleDetailExists(long id)
        {
            return _context.VehicleDetail.Any(e => e.Id == id);
        }
    }
}
