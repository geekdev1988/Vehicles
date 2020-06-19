using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public int Doors { get; set; }
        public int Wheels { get; set; }
        public BodyType BodyType { get; set; }
        public int BodyTypeId { get; set; }
    }
    public enum BodyType
    {
        hatchback,
        sedan
    }
    public enum VehicleType
    {
        car,
        boat,
        bike
    }
}