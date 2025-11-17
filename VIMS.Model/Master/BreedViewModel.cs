using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIMS.DB;
using VIMS.Model.Resources;

namespace VIMS.Model.Master
{
    public class BreedViewModel
    {
        public int BreedId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Breed), ErrorMessageResourceName = "RBreedName")]
        public string BreedName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Breed), ErrorMessageResourceName = "RBreedCode")]
        [StringLength(10, ErrorMessageResourceType = typeof(Breed), ErrorMessageResourceName = "RBreedCodeLength")]
        public string BreedCode { get; set; }

        public int SpeciesId { get; set; }

        public string SpeciesName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Breed), ErrorMessageResourceName = "RSpeciesCode")]
        public string SpeciesCode { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_BreedMasterRtr_Result> BreedList { get; set; }

        public string success { get; set; }
        public string message { get; set; }
        public string result { get; set; }
        public string Action { get; set; }
    }
}
