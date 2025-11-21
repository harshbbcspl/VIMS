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
    public class RouteViewModel
    {
        public int RouteId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Route), ErrorMessageResourceName = "RRouteCode")]
        [StringLength(50, ErrorMessageResourceType = typeof(Route), ErrorMessageResourceName = "RRouteCodeLength")]
        public string RouteCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Route), ErrorMessageResourceName = "RRouteName")]
        public string RouteName { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_RouteMasterRtr_Result> RouteList { get; set; }

        public string Action { get; set; }
    }
}
