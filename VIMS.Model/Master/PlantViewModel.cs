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
    public class PlantViewModel
    {
        public int PlantId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Plants), ErrorMessageResourceName = "RPlantName")]
        public string PlantName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Plants), ErrorMessageResourceName = "RPlantCode")]
        [StringLength(10, ErrorMessageResourceType = typeof(Plants), ErrorMessageResourceName = "RPlantCodeLength")]
        public string PlantCode { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_PlantMasterRtr_Result> PlantList { get; set; }

        public string Action { get; set; }
    }
}
