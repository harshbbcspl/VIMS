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
    public class CenterViewModel
    {
        public int CenterId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Center), ErrorMessageResourceName = "RCenterCode")]
        [StringLength(50, ErrorMessageResourceType = typeof(Center), ErrorMessageResourceName = "RCenterCodeLength")]
        public string CenterCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Center), ErrorMessageResourceName = "RCenterName")]
        public string CenterName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Center), ErrorMessageResourceName = "RPlantCode")]
        public string PlantCode { get; set; }

        public string PlantName { get; set; }

        public bool AutoAllocation { get; set; } = false;

        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(Center), ErrorMessageResourceName = "RNoOfVisit")]
        public int NoOfVisit { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_CenterMasterRtr_Result> CenterList { get; set; }
        public List<VIMS_PlantMasterRtr_Result> PlantList { get; set; }

        public string Action { get; set; }
    }
}
