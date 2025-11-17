using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMS.DB;
using VIMS.Model.Resources;

namespace VIMS.Model.Master
{
    public class AilmentViewModel
    {
        public int AilmentId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Ailment), ErrorMessageResourceName = "RAilmentName")]
        public string AilmentName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Ailment), ErrorMessageResourceName = "RAilmentCode")]
        [StringLength(10, ErrorMessageResourceType = typeof(Ailment), ErrorMessageResourceName = "RAilmentCodeLength")]
        public string AilmentCode { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        // List from SP result
        public List<VIMS_AilmentMasterRtr_Result> AilmentList { get; set; }

        // Common response fields
        public string success { get; set; }
        public string message { get; set; }
        public string result { get; set; }
        public string Action { get; set; }
    }
}
