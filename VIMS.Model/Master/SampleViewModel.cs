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
    public class SampleViewModel
    {
        public int SampleId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Sample), ErrorMessageResourceName = "RSampleName")]
        public string SampleName { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_SampleMasterRtr_Result> SampleList { get; set; }

        public string Action { get; set; }
    }
}
