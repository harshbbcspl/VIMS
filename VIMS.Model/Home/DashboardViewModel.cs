using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIMS.Model.Home
{
    public class DashboardViewModel
    {
        public string SocietyCode { get; set; }
        public string IpAddress { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string SessionGuid { get; set; }
        public string VideoFilePath { get; set; }
        public string ImageFilePath { get; set; }
        public string success { get; set; }
        public string message { get; set; }
        public string result { get; set; }
    }
}
