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
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Customer), ErrorMessageResourceName = "RSocietyCode")]
        public string SocietyCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Customer), ErrorMessageResourceName = "RCustomerCode")]
        public string CustomerCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Customer), ErrorMessageResourceName = "RName")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Customer), ErrorMessageResourceName = "RAddress")]
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(Customer), ErrorMessageResourceName = "RContactNumber1")]
        public string ContactNumber1 { get; set; }

        public string ContactNumber2 { get; set; }

        [Required(ErrorMessageResourceType = typeof(Customer), ErrorMessageResourceName = "RRoleId")]
        public int RoleId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Customer), ErrorMessageResourceName = "RPassword")]
        public string Password { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public string Action { get; set; }

        public List<VIMS_CustomerMasterRtr_Result> CustomerList { get; set; }
        public List<VIMS_RoleMasterRtr_Result> RoleList { get; set; }
    }
}
