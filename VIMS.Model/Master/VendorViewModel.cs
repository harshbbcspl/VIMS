using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VIMS.DB;
using VIMS.Model.Resources;

namespace VIMS.Model.Master
{
    public class VendorViewModel
    {
        public int VendorId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vendor), ErrorMessageResourceName = "RPlantCode")]
        public string PlantCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vendor), ErrorMessageResourceName = "RVendorCode")]
        public string VendorCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vendor), ErrorMessageResourceName = "RVendorName")]
        public string VendorName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Vendor), ErrorMessageResourceName = "RAddress")]
        public string Address { get; set; }

        public string MobileNumber1 { get; set; }
        public string MobileNumber2 { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_VendorMasterRtr_Result> VendorList { get; set; }
        public List<VIMS_PlantMasterRtr_Result> PlantList { get; set; }

        public string Action { get; set; }
    }
}
