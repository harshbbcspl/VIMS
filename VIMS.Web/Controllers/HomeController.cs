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
                var emplog = ApiCall.PostApi("LoginCheckGet", Newtonsoft.Json.JsonConvert.SerializeObject(lm));
                lm = JsonConvert.DeserializeObject<LoginViewModel>(emplog);
                if (lm.result.Equals("1"))
                {
                    FormsAuthentication.SetAuthCookie(lm.Usercode, false);
                    FormsAuthentication.RedirectFromLoginPage(lm.Usercode, true);

                    var Staff = ApiCall.PostApi("LoginUserRtr", Newtonsoft.Json.JsonConvert.SerializeObject(lm));
                    lm = JsonConvert.DeserializeObject<LoginViewModel>(Staff);

                    HttpCookie LoginMaster = new HttpCookie("LoginMaster");
                    if (lm.Usercode != null)
                    {
                        LoginMaster["SocietyCode"] = lm.LoginUserList.FirstOrDefault().sold_to_party;
                        LoginMaster["SocietyName"] = lm.LoginUserList.FirstOrDefault().customername;
                        LoginMaster["RoleId"] = lm.LoginUserList.FirstOrDefault().RoleId.ToString();
                        LoginMaster["RoleName"] = lm.LoginUserList.FirstOrDefault().RoleName.ToString();
                        LoginMaster["Lang"] = lm.Language;
                        LoginMaster["IsLogin"] = "True";
                    }
                    Response.Cookies.Add(LoginMaster);

                    Log.LogMessage("Home", "Login", "Login Successfull.", Logger.LogType.Information);
                    return RedirectToAction("Dashboard", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName or Password");
                    return View("Login");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Home");
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