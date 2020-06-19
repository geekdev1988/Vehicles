using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Vehicle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<VehicleController> _logger;

        public VehicleController(ILogger<VehicleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Vehicle.Models.Vehicle> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Vehicle.Models.Vehicle
            {
                Id = index,
                Doors = rng.Next(-20, 55),
                Make = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
