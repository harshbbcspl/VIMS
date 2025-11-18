using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VIMS.DB;


namespace VIMS.Model.Home
{
    public class LoginViewModel
    {
   

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
        public List<VIMS_LoginRtr_Result> LoginUserList { get; set; }


    }
    public class LoginUserDto
    {
        public string SocietyCode { get; set; }
        public string SocietyName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        // Other fields from LoginUserRtr
    }
}
