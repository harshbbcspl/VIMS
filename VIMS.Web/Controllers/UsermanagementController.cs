using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIMS.DB;
using VIMS.Model.Home;
using VIMS.Model.Usermanagement;
using VIMS.Web.GeneralClasses;

namespace VIMS.Web.Controllers
{
    public class UsermanagementController : GeneralClass
    {
        #region==> Change Status 
        public ActionResult ChangeStatus(string Code, string status, string Type)
        {
            string msg = "";
            try
            {
                if (Type == "RoleMaster")
                {
                    RoleViewModel sm = new RoleViewModel();
                    sm.Action = "Active";
                    sm.UpdatedDate = generalFunctions.getTimeZoneDatetimedb();
                    sm.UpdatedBy = User.Identity.Name;
                    sm.RoleId = Convert.ToInt32(Code);
                    sm.IsActive = status.Equals("true");
                    var apiResult = ApiCall.PostApi("RoleMasterInsUpd", JsonConvert.SerializeObject(sm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResult);
                    msg = response.message;
                }
                else
                {
                    msg = "Did not have method";
                }
            }
            catch (Exception ex)
            {
                Danger(ex.Message.ToString(), "Usermanagement", "ChangeStatus", true); ;
                return RedirectToAction("Dashboard", "Home");
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region==> Role Master

        public ActionResult RoleMaster()
        {
            try
            {
                RoleViewModel rvm = new RoleViewModel
                {
                    Action = "All"
                };

                var apiResponse = ApiCall.PostApi("RoleMasterRtr", JsonConvert.SerializeObject(rvm));
                var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_RoleMasterRtr_Result>>>(apiResponse);

                if (response != null && response.result)
                    return View(response.data);

                return View(new List<VIMS_RoleMasterRtr_Result>());
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Usermanagement", "RoleMaster", true);
                return RedirectToAction("Dashboard", "Home");
            }
        }

        public ActionResult AddRole(int? id)
        {
            try
            {
                RoleViewModel rvm = new RoleViewModel();

                if (id.HasValue)
                {
                    rvm.Action = "GetById";
                    rvm.RoleId = id.Value;

                    var apiResponse = ApiCall.PostApi("RoleMasterRtr", JsonConvert.SerializeObject(rvm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_RoleMasterRtr_Result>>>(apiResponse);

                    if (response != null && response.result && response.data.Count > 0)
                    {
                        var item = response.data.First();
                        rvm.RoleId = item.RoleId;
                        rvm.RoleName = item.RoleName;
                        rvm.IsActive = item.IsActive;
                    }

                    ViewBag.Action = "Update";
                    rvm.Action = "Update";
                }
                else
                {
                    ViewBag.Action = "Add";
                    rvm.Action = "Save";
                }

                return View(rvm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Usermanagement", "RoleMaster", true);
                return RedirectToAction("RoleMaster");
            }
        }

        [HttpPost]
        public ActionResult AddRole(RoleViewModel rvm)
        {
            try
            {
                string apiName = "RoleMasterInsUpd";

                if (rvm.Action == "Save")
                {
                    rvm.Action = "Insert";
                    rvm.CreatedBy = User.Identity.Name;
                    rvm.UpdatedBy = User.Identity.Name;
                }
                else
                {
                    rvm.Action = "Update";
                    rvm.UpdatedBy = User.Identity.Name;
                }

                var apiResponse = ApiCall.PostApi(apiName, JsonConvert.SerializeObject(rvm));
                var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResponse);

                if (response != null && response.result)
                {
                    Success(response.message, "Usermanagement", "RoleMaster", true);
                    return RedirectToAction("RoleMaster");
                }
                else
                {
                    Danger(response?.message ?? "Something went wrong", "Usermanagement", "RoleMaster", true);
                    return View(rvm);
                }
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Usermanagement", "RoleMaster", true);
                return View(rvm);
            }
        }

        public ActionResult EditRole(int id)
        {
            return RedirectToAction("AddRole", new { id = id });
        }

        #endregion
    }
}