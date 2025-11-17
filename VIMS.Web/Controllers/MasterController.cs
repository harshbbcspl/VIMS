using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIMS.Model.Master;
using VIMS.Web.GeneralClasses;
using static VIMS.Web.GeneralClasses.GeneralClass;

namespace VIMS.Web.Controllers
{
    public class MasterController : GeneralClass
    {
        #region ==> Species Master

        public ActionResult SpeciesMaster()
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
            //        Danger("Sorry,You have no rights to access this page", "SpeciesMaster", "Master", true);
            //        return RedirectToAction("Dashboard", "Home");
            //    }

            //    if (Convert.ToInt32(TempData["ViewRight"]) == 1)
            //    {
                    SpeciesViewModel svm = new SpeciesViewModel
                    {
                        Action = "All"
                    };

                    var apiResponse = ApiCall.PostApi("VIMSApi/SpeciesMasterRtr", JsonConvert.SerializeObject(svm));
                    svm = JsonConvert.DeserializeObject<SpeciesViewModel>(apiResponse);

                    return View(svm.SpeciesList);
            //    }
            //    else
            //    {
            //        return RedirectToAction("Dashboard", "Home");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Danger(ex.Message, "Master", "SpeciesMaster", true);
            //    return RedirectToAction("Dashboard", "Home");
            //}
        }

        public ActionResult AddSpecies(int? id)
        {
            try
            {
                SpeciesViewModel svm = new SpeciesViewModel();

                if (id.HasValue)
                {
                    svm.Action = "GetById";
                    svm.SpeciesId = id.Value;

                    var apiResponse = ApiCall.PostApi("VIMSApi/SpeciesMasterRtr", JsonConvert.SerializeObject(svm));
                    svm = JsonConvert.DeserializeObject<SpeciesViewModel>(apiResponse);

                    if (svm.SpeciesList != null && svm.SpeciesList.Count > 0)
                    {
                        var item = svm.SpeciesList.First();
                        svm.SpeciesId = item.SpeciesId;
                        svm.SpeciesName = item.SpeciesName;
                        svm.SpeciesCode = item.SpeciesCode;
                        svm.IsActive = item.IsActive;
                    }

                    ViewBag.Action = "Update";
                }
                else
                {
                    ViewBag.Action = "Add";
                }

                svm.Action = id.HasValue ? "Update" : "Save";
                return View(svm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "SpeciesMaster", true);
                return RedirectToAction("SpeciesMaster");
            }
        }

        [HttpPost]
        public ActionResult AddSpecies(SpeciesViewModel svm)
        {
            try
            {
                if (svm.Action == "Save")
                {
                    svm.Action = "Insert";
                    svm.CreatedBy = "Admin"; 
                    svm.UpdatedBy = "Admin";

                    var apiResponse = ApiCall.PostApi("VIMSApi/SpeciesMasterInsUpd", JsonConvert.SerializeObject(svm));
                    svm = JsonConvert.DeserializeObject<SpeciesViewModel>(apiResponse);

                    if (!string.IsNullOrEmpty(svm.result) && svm.result.Contains("successfully"))
                    {
                        Success(svm.result, "Master", "AddSpecies", true);
                        return RedirectToAction("AddSpecies", "Master");
                    }
                    else
                    {
                        Danger(svm.result, "Master", "AddSpecies", true);
                        return View(svm);
                    }
                }
                else 
                {
                    svm.Action = "Update";
                    svm.UpdatedBy = "Admin"; 

                    var apiResponse = ApiCall.PostApi("VIMSApi/SpeciesMasterInsUpd", JsonConvert.SerializeObject(svm));
                    svm = JsonConvert.DeserializeObject<SpeciesViewModel>(apiResponse);

                    if (!string.IsNullOrEmpty(svm.result) && svm.result.Contains("successfully"))
                    {
                        Success(svm.result, "Master", "AddSpecies", true);
                        return RedirectToAction("AddSpecies", "Master");
                    }
                    else
                    {
                        Danger(svm.result, "Master", "AddSpecies", true);
                        return View(svm);
                    }
                }
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "AddSpecies", true);
                return View(svm);
            }
        }

        public ActionResult EditSpeciesMaster(int id)
        {
            try
            {
                SpeciesViewModel svm = new SpeciesViewModel
                {
                    Action = "GetById",
                    SpeciesId = id
                };

                var apiResponse = ApiCall.PostApi("VIMSApi/SpeciesMasterRtr", JsonConvert.SerializeObject(svm));
                svm = JsonConvert.DeserializeObject<SpeciesViewModel>(apiResponse);

                if (svm.SpeciesList != null && svm.SpeciesList.Count > 0)
                {
                    var item = svm.SpeciesList.First();
                    svm.SpeciesId = item.SpeciesId;
                    svm.SpeciesName = item.SpeciesName;
                    svm.SpeciesCode = item.SpeciesCode;
                    svm.IsActive = item.IsActive;
                }

                svm.Action = "Update";
                ViewBag.Action = "Update";
                return View("AddSpecies", svm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "SpeciesMaster", true);
                return RedirectToAction("SpeciesMaster", "Master");
            }
        }

        #endregion
    }
}