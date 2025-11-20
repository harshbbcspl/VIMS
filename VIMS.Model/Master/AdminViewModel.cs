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
    public class AdminViewModel
    {
        public int AdminId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Admin), ErrorMessageResourceName = "RAdminCode")]
        public string AdminCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Admin), ErrorMessageResourceName = "RName")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Admin), ErrorMessageResourceName = "RGender")]
        public string Gender { get; set; }

        [Required(ErrorMessageResourceType = typeof(Admin), ErrorMessageResourceName = "RDateOfBirth")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessageResourceType = typeof(Admin), ErrorMessageResourceName = "RAddress")]
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(Admin), ErrorMessageResourceName = "RCityId")]
        public int CityId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Admin), ErrorMessageResourceName = "RStateId")]
        public int StateId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Admin), ErrorMessageResourceName = "RPinCode")]
        public string PinCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Admin), ErrorMessageResourceName = "RContact")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Admin), ErrorMessageResourceName = "RPassword")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Admin), ErrorMessageResourceName = "RRoleId")]
        public int RoleId { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_AdminMasterRtr_Result> AdminList { get; set; }
        public List<VIMS_RoleMasterRtr_Result> RoleList { get; set; }
        public List<VIMS_CityMasterRtr_Result> CityList { get; set; }
        public List<VIMS_StatesMasterRtr_Result> StatesList { get; set; }

        public string Action { get; set; }
    }
}
