using System;
using System.Collections.Generic;

namespace Vehicle.DBModels
{
    public partial class VehicleMakeMaster
    {
        public VehicleMakeMaster()
        {
            VehicleDetail = new HashSet<VehicleDetail>();
        }

        public int VehicleMakeId { get; set; }
        public string VehicleMake { get; set; }

        public virtual ICollection<VehicleDetail> VehicleDetail { get; set; }
    }
}
