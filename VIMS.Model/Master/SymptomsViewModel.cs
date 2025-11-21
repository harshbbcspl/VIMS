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
    public class SymptomsViewModel
    {
        public int SymptomsId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Symptoms), ErrorMessageResourceName = "RSymptomsCode")]
        [StringLength(50, ErrorMessageResourceType = typeof(Symptoms), ErrorMessageResourceName = "RSymptomsCodeLength")]
        public string SymptomsCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Symptoms), ErrorMessageResourceName = "RSymptomsName")]
        public string SymptomsName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Symptoms), ErrorMessageResourceName = "RDiseaseCode")]
        public string DiseaseCode { get; set; }

        public string DiseaseName { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_SymptomsMasterRtr_Result> SymptomsList { get; set; }

        public string Action { get; set; }
    }
}
