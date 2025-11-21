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
    public class DiseaseViewModel
    {
        public int DiseaseId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Disease), ErrorMessageResourceName = "RDiseaseCode")]
        [StringLength(50, ErrorMessageResourceType = typeof(Disease), ErrorMessageResourceName = "RDiseaseCodeLength")]
        public string DiseaseCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Disease), ErrorMessageResourceName = "RDiseaseName")]
        public string DiseaseName { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_DiseaseMasterRtr_Result> DiseaseList { get; set; }

        public string Action { get; set; }
    }
}
