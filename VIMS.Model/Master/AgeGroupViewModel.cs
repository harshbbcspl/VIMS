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
    public class AgeGroupViewModel
    {
        public int AgeGroupId { get; set; }

        [Required(ErrorMessageResourceType = typeof(AgeGroups), ErrorMessageResourceName = "RAgeGroupName")]
        public string AgeGroupName { get; set; }

        [Required(ErrorMessageResourceType = typeof(AgeGroups), ErrorMessageResourceName = "RAgeGroupCode")]
        [StringLength(10, ErrorMessageResourceType = typeof(AgeGroups), ErrorMessageResourceName = "RAgeGroupCodeLength")]
        public string AgeGroupCode { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_AgeGroupMasterRtr_Result> AgeGroupList { get; set; }

        public string Action { get; set; }
    }
}
