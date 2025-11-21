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
    public class MedicineGroupViewModel
    {
        public int MedicineGroupId { get; set; }

        [Required(ErrorMessageResourceType = typeof(MedicineGroup), ErrorMessageResourceName = "RMedicineGroupCode")]
        [StringLength(50, ErrorMessageResourceType = typeof(MedicineGroup), ErrorMessageResourceName = "RMedicineGroupCodeLength")]
        public string MedicineGroupCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(MedicineGroup), ErrorMessageResourceName = "RMedicineGroupName")]
        public string MedicineGroupName { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }

        public List<VIMS_MedicineGroupMasterRtr_Result> MedicineGroupList { get; set; }

        public string Action { get; set; }
    }
}
