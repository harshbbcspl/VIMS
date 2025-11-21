using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VIMS.DB;
using VIMS.Model.Resources;

namespace VIMS.Model.Usermanagement
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Role), ErrorMessageResourceName = "RRoleName")]
        [StringLength(100, ErrorMessageResourceType = typeof(Role), ErrorMessageResourceName = "RRoleNameLength")]
        public string RoleName { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_RoleMasterRtr_Result> RoleList { get; set; }

        public string Action { get; set; }
    }
}
