using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIMS.Model.Home
{
    public class LoginViewModel
    {
        public string Usercode { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
        public string IsLogin { get; set; }
        public string SocietyCode { get; set; }
        public string SocietyName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string PageName { get; set; }
        public string PageId { get; set; }
        public string message { get; set; }
        public string result { get; set; }
        public string success { get; set; }
    }
}
