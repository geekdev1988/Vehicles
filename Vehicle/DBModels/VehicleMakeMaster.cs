using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual ICollection<VehicleDetail> VehicleDetail { get; set; }
    }
}
