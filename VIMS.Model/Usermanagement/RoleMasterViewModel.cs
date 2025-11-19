using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMS.DB;
using VIMS.Model.Resources;

namespace VIMS.Model.Usermanagement
{
    public class RoleMasterViewModel
    {
        public string InteId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string ModuleId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Action { get; set; }
        public string MPInteId { get; set; }
        public string PageId { get; set; }
        public bool ViewRight { get; set; }
        public bool InsertRight { get; set; }
        public bool UpdateRight { get; set; }
        public bool DeleteRight { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public List<VIMS_RoleMasterRtr_Result> RoleList { get; set; }
        public List<VIMS_ModuleMasterRtr_Result> ModuleList { get; set; }
        public List<VIMS_PageMasterRtr_Result> PageList { get; set; }
        public List<VIMS_InteRoleModuleRtr_Result> RoleModuleInteList { get; set; }
        public string success { get; set; }
        public string message { get; set; }
        public string result { get; set; }
        public string CompanyCode { get; set; }
        public string rolename { get; set; }
    }
}
