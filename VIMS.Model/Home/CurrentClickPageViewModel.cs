using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIMS.Model.Home
{
    public class CurrentClickPageViewModel
    {
        public string CurrentClickPageId { get; set; }
        public string PageId { get; set; }
        public string PageName { get; set; }
        public string Action { get; set; }
        //public List<DCS_CurrentClickPageRtr_Result> CurrentClickPageList { get; set; }
        public string success { get; set; }
        public string message { get; set; }
        public string result { get; set; }
    }
}
