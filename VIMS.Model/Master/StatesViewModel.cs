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
    public class StatesViewModel
    {
        public int StateId { get; set; }

        [Required(ErrorMessageResourceType = typeof(States), ErrorMessageResourceName = "RStateName")]
        public string StateName { get; set; }

        [Required(ErrorMessageResourceType = typeof(States), ErrorMessageResourceName = "RStateCode")]
        [StringLength(10, ErrorMessageResourceType = typeof(States), ErrorMessageResourceName = "RStateCodeLength")]
        public string StateCode { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_StatesMasterRtr_Result> StateList { get; set; }

        public string Action { get; set; }
    }
}
