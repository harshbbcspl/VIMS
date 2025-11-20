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
    public class CityViewModel
    {
        public int CityId { get; set; }

        [Required(ErrorMessageResourceType = typeof(City), ErrorMessageResourceName = "RCityName")]
        public string CityName { get; set; }

        [Required(ErrorMessageResourceType = typeof(City), ErrorMessageResourceName = "RCityCode")]
        [StringLength(10, ErrorMessageResourceType = typeof(City), ErrorMessageResourceName = "RCityCodeLength")]
        public string CityCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(City), ErrorMessageResourceName = "RStateId")]
        public int StateId { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_CityMasterRtr_Result> CityList { get; set; }

        public List<VIMS_StatesMasterRtr_Result> StatesList { get; set; }

        public string Action { get; set; }
    }
}
