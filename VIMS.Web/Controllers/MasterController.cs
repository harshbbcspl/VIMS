using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIMS.DB;
using VIMS.Model.Home;
using VIMS.Model.Master;
using VIMS.Web.GeneralClasses;
using static VIMS.Web.GeneralClasses.GeneralClass;

namespace VIMS.Web.Controllers
{
    public class MasterController : GeneralClass
    {
        #region==> Change Status 
        public ActionResult ChangeStatus(string Code, string status, string Type)
        {
            string msg = "";
            try
            {
                if (Type == "BreedMaster")
                {
                    BreedViewModel sm = new BreedViewModel();
                    sm.Action = "Active";
                    sm.UpdatedDate = generalFunctions.getTimeZoneDatetimedb();
                    sm.UpdatedBy = User.Identity.Name;
                    sm.BreedId = Convert.ToInt32(Code);  
                    sm.IsActive = status.Equals("true"); 
                    var apiResult = ApiCall.PostApi("BreedMasterInsUpd",JsonConvert.SerializeObject(sm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResult);
                    msg = response.message;  
                }
                else if (Type == "SpeciesMaster")
                {
                    SpeciesViewModel sm = new SpeciesViewModel();
                    sm.Action = "Active";
                    sm.UpdatedDate = generalFunctions.getTimeZoneDatetimedb();
                    sm.UpdatedBy = User.Identity.Name;
                    sm.SpeciesId = Convert.ToInt32(Code);
                    sm.IsActive = status.Equals("true");

                    var apiResult = ApiCall.PostApi("SpeciesMasterInsUpd", JsonConvert.SerializeObject(sm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResult);

                    msg = response.message;
                }
                else if (Type == "AilmentMaster")
                {
                    AilmentViewModel sm = new AilmentViewModel();
                    sm.Action = "Active";
                    sm.UpdatedDate = generalFunctions.getTimeZoneDatetimedb();
                    sm.UpdatedBy = User.Identity.Name;
                    sm.AilmentId = Convert.ToInt32(Code);
                    sm.IsActive = status.Equals("true");

                    var apiResult = ApiCall.PostApi("AilmentMasterInsUpd", JsonConvert.SerializeObject(sm));
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
                Danger(ex.Message.ToString(), "Master", "ChangeStatus", true); ;
                return RedirectToAction("Dashboard", "Home");
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion

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

                        var apiResponse = ApiCall.PostApi("SpeciesMasterRtr", JsonConvert.SerializeObject(svm));

                        // Deserialize into ApiResponse<T>
                        var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_SpeciesMasterRtr_Result>>>(apiResponse);

                        if (response != null && response.result == true)
                        {
                            return View(response.data);
                        }

                        return View(new List<VIMS_SpeciesMasterRtr_Result>());
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

                    var apiResponse = ApiCall.PostApi("SpeciesMasterRtr", JsonConvert.SerializeObject(svm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_SpeciesMasterRtr_Result>>>(apiResponse);

                    if (response != null && response.result == true && response.data.Count > 0)
                    {
                        var item = response.data.First();
                        svm.SpeciesId = item.SpeciesId;
                        svm.SpeciesName = item.SpeciesName;
                        svm.SpeciesCode = item.SpeciesCode;
                        svm.IsActive = item.IsActive;
                    }

                    ViewBag.Action = "Update";
                    svm.Action = "Update";
                }
                else
                {
                    ViewBag.Action = "Add";
                    svm.Action = "Save";
                }

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
                string apiName = "SpeciesMasterInsUpd";

                if (svm.Action == "Save")
                {
                    svm.Action = "Insert";
                    svm.CreatedBy = "Admin";
                    svm.UpdatedBy = "Admin";
                }
                else
                {
                    svm.Action = "Update";
                    svm.UpdatedBy = "Admin";
                }

                var apiResponse = ApiCall.PostApi(apiName, JsonConvert.SerializeObject(svm));

                var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResponse);

                if (response != null && response.result == true)
                {
                    Success(response.message, "Master", "AddSpecies", true);
                    return RedirectToAction("SpeciesMaster");
                }
                else
                {
                    Danger(response?.message ?? "Something went wrong", "Master", "AddSpecies", true);
                    return View(svm);
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

                var apiResponse = ApiCall.PostApi("SpeciesMasterRtr", JsonConvert.SerializeObject(svm));
                var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_SpeciesMasterRtr_Result>>>(apiResponse);

                if (response != null && response.result == true && response.data.Count > 0)
                {
                    var item = response.data.First();
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

        #region ==> Breed Master

        public ActionResult BreedMaster()
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
                        BreedViewModel bvm = new BreedViewModel
                        {
                            Action = "All"
                        };

                        var apiResponse = ApiCall.PostApi("BreedMasterRtr", JsonConvert.SerializeObject(bvm));
                        var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_BreedMasterRtr_Result>>>(apiResponse);

                        if (response != null && response.result == true)
                        {
                            return View(response.data);
                        }

                        return View(new List<VIMS_BreedMasterRtr_Result>());
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

        public ActionResult AddBreed(int? id)
        {
            try
            {
                BreedViewModel bvm = new BreedViewModel();

                SpeciesViewModel sp = new SpeciesViewModel();
                sp.Action = "ActiveSpecies";
                var spApi = ApiCall.PostApi("SpeciesMasterRtr", JsonConvert.SerializeObject(sp));
                var spResponse = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_SpeciesMasterRtr_Result>>>(spApi);

                if (spResponse != null && spResponse.result && spResponse.data != null)
                {
                    bvm.SpeciesList = spResponse.data;
                }

                if (id.HasValue)
                {
                    bvm.Action = "GetById";
                    bvm.BreedId = id.Value;

                    var apiResponse = ApiCall.PostApi("BreedMasterRtr", JsonConvert.SerializeObject(bvm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_BreedMasterRtr_Result>>>(apiResponse);

                    if (response != null && response.result == true && response.data.Count > 0)
                    {
                        var item = response.data.First();
                        bvm.BreedId = item.BreedId;
                        bvm.BreedCode = item.BreedCode;
                        bvm.BreedName = item.BreedName;
                        bvm.SpeciesCode = item.SpeciesCode;
                        bvm.IsActive = item.IsActive;
                    }

                    ViewBag.Action = "Update";
                    bvm.Action = "Update";
                }
                else
                {
                    ViewBag.Action = "Add";
                    bvm.Action = "Save";
                }

                return View(bvm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "BreedMaster", true);
                return RedirectToAction("BreedMaster", "Master");
            }
        }

        [HttpPost]
        public ActionResult AddBreed(BreedViewModel bvm)
        {
            try
            {
                string apiName = "BreedMasterInsUpd";

                if (bvm.Action == "Save")
                {
                    bvm.Action = "Insert";
                    bvm.CreatedBy = User.Identity.Name;
                    bvm.UpdatedBy = User.Identity.Name;
                }
                else
                {
                    bvm.Action = "Update";
                    bvm.UpdatedBy = User.Identity.Name;
                }

                var apiResponse = ApiCall.PostApi(apiName, JsonConvert.SerializeObject(bvm));
                var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResponse);

                if (response != null && response.result == true)
                {
                    Success(response.message, "Master", "AddBreed", true);
                    return RedirectToAction("BreedMaster");
                }
                else
                {
                    Danger(response?.message ?? "Something went wrong", "Master", "AddBreed", true);
                    return View(bvm);
                }
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "AddBreed", true);
                return View(bvm);
            }
        }

        public ActionResult EditBreedMaster(int id)
        {
            try
            {
                BreedViewModel bvm = new BreedViewModel
                {
                    Action = "GetById",
                    BreedId = id
                };

                var apiResponse = ApiCall.PostApi("BreedMasterRtr", JsonConvert.SerializeObject(bvm));
                var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_BreedMasterRtr_Result>>>(apiResponse);

                if (response != null && response.result == true && response.data.Count > 0)
                {
                    var item = response.data.First();
                    bvm.BreedId = item.BreedId;
                    bvm.BreedCode = item.BreedCode;
                    bvm.BreedName = item.BreedName;
                    bvm.SpeciesCode = item.SpeciesCode;
                    bvm.IsActive = item.IsActive;
                }

                SpeciesViewModel sp = new SpeciesViewModel();
                sp.Action = "ActiveSpecies";  
                var spApi = ApiCall.PostApi("SpeciesMasterRtr", JsonConvert.SerializeObject(sp));
                var spResponse = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_SpeciesMasterRtr_Result>>>(spApi);
                if (spResponse != null && spResponse.result && spResponse.data != null)
                {
                    bvm.SpeciesList = spResponse.data;
                }

                bvm.Action = "Update";
                ViewBag.Action = "Update";

                return View("AddBreed", bvm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "BreedMaster", true);
                return RedirectToAction("BreedMaster", "Master");
            }
        }


        #endregion

        #region ==> Ailment Master

        public ActionResult AilmentMaster()
        {
            try
            {
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
                            AilmentViewModel avm = new AilmentViewModel
                            {
                                Action = "All"
                            };

                            var apiResponse = ApiCall.PostApi("AilmentMasterRtr", JsonConvert.SerializeObject(avm));
                            var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_AilmentMasterRtr_Result>>>(apiResponse);

                            if (response != null && response.result == true)
                            {
                                return View(response.data);
                            }

                            return View(new List<VIMS_AilmentMasterRtr_Result>());
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
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "AilmentMaster", true);
                return RedirectToAction("Dashboard", "Home");
            }
        }

        public ActionResult AddAilment(int? id)
        {
            try
            {
                AilmentViewModel avm = new AilmentViewModel();

                if (id.HasValue)
                {
                    avm.Action = "GetById";
                    avm.AilmentId = id.Value;

                    var apiResponse = ApiCall.PostApi("AilmentMasterRtr", JsonConvert.SerializeObject(avm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_AilmentMasterRtr_Result>>>(apiResponse);

                    if (response != null && response.result == true && response.data.Count > 0)
                    {
                        var item = response.data.First();
                        avm.AilmentId = item.AilmentId;
                        avm.AilmentCode = item.AilmentCode;
                        avm.AilmentName = item.AilmentName;
                        avm.IsActive = item.IsActive;
                    }

                    ViewBag.Action = "Update";
                    avm.Action = "Update";
                }
                else
                {
                    ViewBag.Action = "Add";
                    avm.Action = "Save";
                }

                return View(avm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "AilmentMaster", true);
                return RedirectToAction("AilmentMaster", "Master");
            }
        }

        [HttpPost]
        public ActionResult AddAilment(AilmentViewModel avm)
        {
            try
            {
                string apiName = "AilmentMasterInsUpd";

                if (avm.Action == "Save")
                {
                    avm.Action = "Insert";
                    avm.CreatedBy = User.Identity.Name;
                    avm.UpdatedBy = User.Identity.Name;
                }
                else
                {
                    avm.Action = "Update";
                    avm.UpdatedBy = User.Identity.Name;
                }

                var apiResponse = ApiCall.PostApi(apiName, JsonConvert.SerializeObject(avm));
                var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResponse);

                if (response != null && response.result == true)
                {
                    Success(response.message, "Master", "AddAilment", true);
                    return RedirectToAction("AilmentMaster");
                }
                else
                {
                    Danger(response?.message ?? "Something went wrong", "Master", "AddAilment", true);
                    return View(avm);
                }
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "AddAilment", true);
                return View(avm);
            }
        }

        public ActionResult EditAilmentMaster(int id)
        {
            try
            {
                AilmentViewModel avm = new AilmentViewModel
                {
                    Action = "GetById",
                    AilmentId = id
                };

                var apiResponse = ApiCall.PostApi("AilmentMasterRtr", JsonConvert.SerializeObject(avm));
                var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_AilmentMasterRtr_Result>>>(apiResponse);

                if (response != null && response.result == true && response.data.Count > 0)
                {
                    var item = response.data.First();
                    avm.AilmentId = item.AilmentId;
                    avm.AilmentCode = item.AilmentCode;
                    avm.AilmentName = item.AilmentName;
                    avm.IsActive = item.IsActive;
                }

                avm.Action = "Update";
                ViewBag.Action = "Update";

                return View("AddAilment", avm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "AilmentMaster", true);
                return RedirectToAction("AilmentMaster", "Master");
            }
        }

        #endregion


    }
}