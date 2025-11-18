using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VIMS.Model.Home;
using VIMS.Model.Usermanagement;
using VIMS.Web.GeneralClasses;

namespace VIMS.Web.Controllers
{   
    public class HomeController : LoginGeneralClass
    {
        #region==> Login / Logout
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel lm)
        {
            try
            {

                var apiResponse = ApiCall.PostApi("LoginCheckGet", JsonConvert.SerializeObject(lm));
                var loginCheck = JsonConvert.DeserializeObject<ApiResponse<int>>(apiResponse); 

                if (loginCheck != null && loginCheck.result && loginCheck.data == 1)
                {
                    FormsAuthentication.SetAuthCookie(lm.SocietyCode, false);
                    FormsAuthentication.RedirectFromLoginPage(lm.SocietyCode, true);

                    var staffResponse = ApiCall.PostApi("LoginUserRtr", JsonConvert.SerializeObject(lm));
                    var staffData = JsonConvert.DeserializeObject<ApiResponse<List<LoginViewModel>>>(staffResponse);

                    if (staffData != null && staffData.result && staffData.data.Count > 0)
                    {
                        var user = staffData.data.First();

                        HttpCookie LoginMaster = new HttpCookie("LoginMaster");
                        LoginMaster["SocietyCode"] = user.SocietyCode;
                        LoginMaster["SocietyName"] = user.SocietyName;
                        LoginMaster["RoleId"] = user.RoleId.ToString();
                        LoginMaster["RoleName"] = user.RoleName;
                        LoginMaster["Lang"] = lm.Language;
                        LoginMaster["IsLogin"] = "True";

                        Response.Cookies.Add(LoginMaster);
                    }

                    Log.LogMessage("Home", "Login", "Login Successful.", Logger.LogType.Information);
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ModelState.AddModelError("", loginCheck?.message ?? "Invalid SocietyCode or Password");
                    return View("Login");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Invalid SocietyCode or Password");
                return View("Login");
            }
        }



        public ActionResult Logout()
        {
            Session.Abandon();

            if (Request.Cookies["LoginMaster"] != null)
            {
                Response.Cookies["LoginMaster"].Expires = DateTime.Now.AddDays(-1);
            }
            Log.LogMessage("Home", "Logout", "User Logout.", Logger.LogType.Information);
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
        #endregion

        #region==> Change Password
        public ActionResult ChangePassword()
        {
            Language();
            ChangePasswordViewModel cp = new ChangePasswordViewModel();
            cp.UserCode = LoggedUserDetails.SocietyCode;
            return View(cp);
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel cpvm)
        {
            Language();
            try
            {
                cpvm.CreateDate = generalFunctions.getTimeZoneDatetimedb();

                var emplog = ApiCall.PostApi("ChangePassword", JsonConvert.SerializeObject(cpvm));

                var apiResult = JsonConvert.DeserializeObject<ApiResponse<string>>(emplog);

                string msg = apiResult.message;

                if (msg.Contains("successfully"))
                {
                    Success(msg, "Home", "ChangePassword");
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    Danger(msg, "Home", "ChangePassword");
                    return View(cpvm);
                }
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Home", "ChangePassword");
                return RedirectToAction("Dashboard", "Home");
            }
        }

        #endregion

        #region==> Dashboard
        public ActionResult Dashboard()
        {
            Language();
            DashboardViewModel dvm = new DashboardViewModel();

            dvm.SocietyCode = LoggedUserDetails.SocietyCode;
            dvm.IpAddress = GetClientIpAddress();
            dvm.Controller = this.ControllerContext.RouteData.Values["controller"].ToString();
            dvm.Action = this.ControllerContext.RouteData.Values["action"].ToString();
            dvm.SessionGuid = Guid.NewGuid().ToString();

            //var emplog = ApiCall.PostApi("AccessLogIns", Newtonsoft.Json.JsonConvert.SerializeObject(dvm));
            //dvm = JsonConvert.DeserializeObject<DashboardViewModel>(emplog);

            //AdvertisementViewModel pv = new AdvertisementViewModel();
            //pv.Action = "All";
            //var emplog1 = ApiCall.PostApi("AdvertisementRtr", Newtonsoft.Json.JsonConvert.SerializeObject(pv));
            //pv = JsonConvert.DeserializeObject<AdvertisementViewModel>(emplog1);

            //foreach (var page in pv.AdvertismentList)
            //{
            //    if (page.type == 1)
            //    {
            //        dvm.ImageFilePath = string.Format("{0}{1}", System.Configuration.ConfigurationManager.AppSettings["FileRtr"], page.url);
            //    }
            //    else
            //    {
            //        dvm.VideoFilePath = string.Format("{0}{1}", System.Configuration.ConfigurationManager.AppSettings["FileRtr"], page.url);
            //    }
            //}

            return View();
        }
        #endregion

        #region => Menu
        public ActionResult Menu()
        {
            try
            {
                //MenuViewModel mv = new MenuViewModel();
                //HttpCookie reqCookies = Request.Cookies["LoginMaster"];
                //if (reqCookies != null)
                //{
                //    mv.RoleId = Convert.ToInt32(reqCookies["RoleId"]);
                //    mv.Language = LoggedUserDetails.Language;
                //    var emplog = ApiCall.PostApi("MenuRtr", Newtonsoft.Json.JsonConvert.SerializeObject(mv));
                //    mv = JsonConvert.DeserializeObject<MenuViewModel>(emplog);
                //}
                return View(/*"Menu", mv.MenuList*/);
            }
            catch (Exception ex)
            {
                Danger(ex.Message.ToString(), "Home", "Menu");
                return RedirectToAction("Dashboard", "Home");
            }
        }
        #endregion

        #region==> Page Value Get
        public JsonResult SetPageValue(string PageName, string PageId)
        {
            if (PageName != null)
            {
                CurrentClickPageViewModel cpvm = new CurrentClickPageViewModel();
                cpvm.PageId = PageId;
                cpvm.PageName = PageName;
                cpvm.Action = "insert";
                var emplog = ApiCall.PostApi("CurrentClickPageIns", Newtonsoft.Json.JsonConvert.SerializeObject(cpvm));
                cpvm = JsonConvert.DeserializeObject<CurrentClickPageViewModel>(emplog);

                string msg = cpvm.result;
                if (msg.Contains("successfully"))
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            else
            {
                return Json(new { success = false });
            }
        }
        #endregion
    }
}