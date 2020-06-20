using System;
using System.Collections.Generic;

namespace Vehicle.DBModels
{
    public partial class VehicleDetail
    {
        public long Id { get; set; }
        public int VehicleType { get; set; }
        public int Make { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Doors { get; set; }
        public string Wheels { get; set; }
        public string BodyType { get; set; }

        public virtual VehicleMakeMaster MakeNavigation { get; set; }
        public virtual VehicleCategoryMaster VehicleTypeNavigation { get; set; }
    }
}
