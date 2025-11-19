using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIMS.DB;
using VIMS.Model.Home;
using VIMS.Model.Usermanagement;

namespace VIMS.Web.Controllers
{
    public class UsermanagementController : Controller
    {
        #region==> Role Master
        public ActionResult RoleMaster()
        {

            //try
            //{
            //    string url = generalFunctions.getCommon(Request.Url.AbsoluteUri);
            //    MenuRightsViewModel mv1 = new MenuRightsViewModel
            //    {
            //        Usercode = LoggedUserDetails.SocietyCode,
            //        PageName = url
            //    };

            //    var menuRtr = ApiCall.PostApi("MenuRightsRtr", JsonConvert.SerializeObject(mv1));
            //    mv1 = JsonConvert.DeserializeObject<MenuRightsViewModel>(menuRtr);

            //    if (mv1.MenuRightsList.Count > 0)
            //    {
            //        TempData["ViewRight"] = mv1.MenuRightsList.FirstOrDefault().ViewRight;
            //        TempData["InsertRight"] = mv1.MenuRightsList.FirstOrDefault().InsertRight;
            //        TempData["UpdateRight"] = mv1.MenuRightsList.FirstOrDefault().UpdateRight;
            //        TempData["DeleteRight"] = mv1.MenuRightsList.FirstOrDefault().DeleteRight;
            //    }
            //    else
            //    {
            //        Danger("Sorry,You have no rights to access this page", "RoleMaster", "Master", true);
            //        return RedirectToAction("Dashboard", "Home");
            //    }

            //    if (Convert.ToInt32(TempData["ViewRight"]) == 1)
            //    {
                 RoleMasterViewModel rvm = new RoleMasterViewModel
                            {
                                Action = "All"
                            };

                            var apiResponse = ApiCall.PostApi("RoleMasterRtr", JsonConvert.SerializeObject(rvm));

                            var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_RoleMasterRtr_Result>>>(apiResponse);

                            if (response != null && response.result == true)
                            {
                                return View(response.data);
                            }

                            return View(new List<VIMS_RoleMasterRtr_Result>());
            //    }
            //    else
            //    {
            //        return RedirectToAction("Dashboard", "Home");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Danger(ex.Message, "Master", "RoleMaster", true);
            //    return RedirectToAction("Dashboard", "Home");
            //}
        }


        //public ActionResult AddRoleMaster()
        //{
        //    try
        //    {
        //        var list = new List<string>() { "Male", "Female", "Other" };
        //        ViewBag.list = list;

        //        RoleMasterViewModel model = new RoleMasterViewModel();
        //        model.Action = "Save";

        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        Danger(ex.Message, "Usermanagement", "AddRoleMaster", true);
        //        return RedirectToAction("Dashboard", "Home");
        //    }
        //}

        //[HttpPost]
        //public ActionResult AddRoleMaster(RoleMasterViewModel sm)
        //{
        //    try
        //    {
        //        if (sm.RoleId == null)
        //        {
        //            sm.CreateDate = generalFunctions.getTimeZoneDatetimedb();
        //            sm.Action = "insert";
        //            sm.CreateUser = User.Identity.Name;
        //            sm.UpdateUser = User.Identity.Name;

        //            var rolelog = ApiCall.PostApi("RoleMasterInsUpd", Newtonsoft.Json.JsonConvert.SerializeObject(sm));
        //            sm = JsonConvert.DeserializeObject<RoleMasterViewModel>(rolelog);
        //            string msg = sm.result;
        //            if (msg.Contains("successfully"))
        //            {
        //                Success(msg, "Usermanagement", "AddRoleMaster", true);
        //                return RedirectToAction("AddRoleMaster", "Usermanagement");
        //            }
        //            else
        //            {
        //                Danger(msg, "Usermanagement", "AddRoleMaster", true);
        //                return RedirectToAction("AddRoleMaster", "Usermanagement");
        //            }
        //        }
        //        else
        //        {
        //            sm.Action = "Update";
        //            sm.UpdateDate = generalFunctions.getTimeZoneDatetimedb();
        //            sm.UpdateUser = User.Identity.Name;
        //            var rolelog = ApiCall.PostApi("RoleMasterInsUpd", Newtonsoft.Json.JsonConvert.SerializeObject(sm));
        //            sm = JsonConvert.DeserializeObject<RoleMasterViewModel>(rolelog);
        //            string msg = sm.result;
        //            if (msg.Contains("successfully"))
        //            {
        //                Success(msg, "Usermanagement", "AddRoleMaster", true);
        //                return RedirectToAction("AddRoleMaster", "Usermanagement");
        //            }
        //            else
        //            {
        //                Danger(msg, "Usermanagement", "AddRoleMaster", true);
        //                return RedirectToAction("AddRoleMaster", "Usermanagement");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Danger(ex.Message, "Usermanagement", "AddRoleMaster", true);
        //        return RedirectToAction("AddRoleMaster", "Usermanagement");
        //    }
        //}


        //public ActionResult EditRoleMaster(int id)
        //{
        //    try
        //    {
        //        var list = new List<string>() { "Male", "Female", "Other" };
        //        ViewBag.list = list;
        //        RoleMasterViewModel sb = new RoleMasterViewModel();
        //        sb.RoleList = sb.RoleList;
        //        sb.Action = "details";
        //        sb.RoleId = id.ToString();
        //        var rolelog = ApiCall.PostApi("RoleMasterRetrieve", Newtonsoft.Json.JsonConvert.SerializeObject(sb));
        //        sb = JsonConvert.DeserializeObject<RoleMasterViewModel>(rolelog);
        //        sb.RoleId = sb.RoleList.FirstOrDefault().RoleId.ToString();
        //        sb.rolename = sb.RoleList.FirstOrDefault().RoleName.ToString();
        //        sb.CreateDate = sb.RoleList.FirstOrDefault().CreateDate.ToString();
        //        sb.CreateUser = sb.RoleList.FirstOrDefault().CreateUser;
        //        sb.IsActive = sb.RoleList.FirstOrDefault().IsActive.ToString();
        //        ViewBag.action = "Update";
        //        sb.Action = "Update";
        //        return View("AddRoleMaster", sb);
        //    }
        //    catch (Exception ex)
        //    {
        //        Danger(ex.Message, "Usermanagement", "AddRoleMaster", true);
        //        return RedirectToAction("ViewRoleMaster", "Master");
        //    }
        //}
        #endregion
    }
}