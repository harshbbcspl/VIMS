using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMS.Model.Resources;

namespace VIMS.Model.Home
{
    public class ChangePasswordViewModel
    {
        public string UserCode { get; set; }

        //[Required(ErrorMessageResourceType = typeof(ChangePassword), ErrorMessageResourceName = "CurrPReq")]
        public string OldPassword { get; set; }

        //[Required(ErrorMessageResourceType = typeof(ChangePassword), ErrorMessageResourceName = "NewPReq")]
        public string NewPassword { get; set; }
        //[Required(ErrorMessageResourceType = typeof(ChangePassword), ErrorMessageResourceName = "ReENewP")]
        //[Compare("NewPassword", ErrorMessageResourceType = typeof(ChangePassword), ErrorMessageResourceName = "CompP")]
        public string ConfirmPassword { get; set; }
        public string CreateDate { get; set; }
        public string message { get; set; }
        public string result { get; set; }
        public string success { get; set; }
    }
}
