using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Vehicle.DBModels
{
    public partial class VehicleCategoryMaster
    {
        public VehicleCategoryMaster()
        {
            VehicleDetail = new HashSet<VehicleDetail>();
        }

        public int VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
        [JsonIgnore]
        public virtual ICollection<VehicleDetail> VehicleDetail { get; set; }
    }
}
