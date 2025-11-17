using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIMS.Model.Usermanagement
{
    public class MenuViewModel
    {
        public string success { get; set; }
        public string message { get; set; }
        public string result { get; set; }
        public int RoleId { get; set; }
        public string Language { get; set; }
        //public List<DCS_MenuRtr_Result> MenuList { get; set; }
    }
}
