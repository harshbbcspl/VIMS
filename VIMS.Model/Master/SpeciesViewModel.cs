using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VIMS.DB;
using VIMS.Model.Resources;

namespace VIMS.Model.Master
{
    public class SpeciesViewModel
    {
        public int SpeciesId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Species), ErrorMessageResourceName = "RSpeciesName")]
        public string SpeciesName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Species), ErrorMessageResourceName = "RSpeciesCode")]
        [StringLength(10, ErrorMessageResourceType = typeof(Species), ErrorMessageResourceName = "RSpeciesCodeLength")]
        public string SpeciesCode { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_SpeciesMasterRtr_Result> SpeciesList { get; set; }

        //public string success { get; set; }
        //public string message { get; set; }
        //public string result { get; set; }
        public string Action { get; set; }
    }
}
