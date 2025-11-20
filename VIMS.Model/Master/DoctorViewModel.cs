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
    public class DoctorViewModel
    {
        public int DoctorId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RDoctorName")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RDoctorCode")]
        public string DoctorCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RGender")]
        public string Gender { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RDateOfBirth")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RAddress")]
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RCityId")]
        public int CityId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RStateId")]
        public int StateId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RPinCode")]
        public string PinCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RContactNumber1")]
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RPassword")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RRoleId")]
        public int RoleId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RJoiningDate")]
        public string JoiningDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "REndingDate")]
        public string EndingDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RQualifications")]
        public string Qualifications { get; set; }

        [Required(ErrorMessageResourceType = typeof(Doctor), ErrorMessageResourceName = "RSignaturePath")]
        public string SignaturePath { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_DoctorMasterRtr_Result> DoctorList { get; set; }
        public List<VIMS_RoleMasterRtr_Result> RoleList { get; set; }
        public List<VIMS_CityMasterRtr_Result> CityList { get; set; }
        public List<VIMS_StatesMasterRtr_Result> StatesList { get; set; }

        public string Action { get; set; }
    }
}
