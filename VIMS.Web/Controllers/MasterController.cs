using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VIMS.DB;
using VIMS.Model.Home;
using VIMS.Model.Master;
using VIMS.Web.GeneralClasses;
using VIMS.Web.Helpers;
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
                else if (Type == "StatesMaster")
                {
                    StatesViewModel sm = new StatesViewModel();
                    sm.Action = "Active";
                    sm.UpdatedDate = generalFunctions.getTimeZoneDatetimedb();
                    sm.UpdatedBy = User.Identity.Name;
                    sm.StateId = Convert.ToInt32(Code);
                    sm.IsActive = status.Equals("true");

                    var apiResult = ApiCall.PostApi("StatesMasterInsUpd", JsonConvert.SerializeObject(sm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResult);

                    msg = response.message;
                }
                else if (Type == "CityMaster")
                {
                    CityViewModel sm = new CityViewModel();
                    sm.Action = "Active";
                    sm.UpdatedDate = generalFunctions.getTimeZoneDatetimedb();
                    sm.UpdatedBy = User.Identity.Name;
                    sm.CityId = Convert.ToInt32(Code);
                    sm.IsActive = status.Equals("true");

                    var apiResult = ApiCall.PostApi("CityMasterInsUpd", JsonConvert.SerializeObject(sm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResult);

                    msg = response.message;
                }
                else if (Type == "CustomerMaster")
                {
                    CustomerViewModel sm = new CustomerViewModel();
                    sm.Action = "Active";
                    sm.UpdatedDate = generalFunctions.getTimeZoneDatetimedb();
                    sm.UpdatedBy = User.Identity.Name;
                    sm.CustomerId = Convert.ToInt32(Code);
                    sm.IsActive = status.Equals("true");

                    var apiResult = ApiCall.PostApi("CustomerMasterInsUpd", JsonConvert.SerializeObject(sm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResult);

                    msg = response.message;
                }
                else if (Type == "AdminMaster")
                {
                    AdminViewModel sm = new AdminViewModel();
                    sm.Action = "Active";
                    sm.UpdatedDate = generalFunctions.getTimeZoneDatetimedb();
                    sm.UpdatedBy = User.Identity.Name;
                    sm.AdminId = Convert.ToInt32(Code);
                    sm.IsActive = status.Equals("true");

                    var apiResult = ApiCall.PostApi("AdminMasterInsUpd", JsonConvert.SerializeObject(sm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResult);

                    msg = response.message;
                }
                else if (Type == "DoctorMaster")
                {
                    DoctorViewModel sm = new DoctorViewModel();
                    sm.Action = "Active";
                    sm.UpdatedDate = generalFunctions.getTimeZoneDatetimedb();
                    sm.UpdatedBy = User.Identity.Name;
                    sm.DoctorId = Convert.ToInt32(Code);
                    sm.IsActive = status.Equals("true");

                    var apiResult = ApiCall.PostApi("DoctorMasterInsUpd", JsonConvert.SerializeObject(sm));
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

        #region ==> States Master

        public ActionResult StatesMaster()
        {
            StatesViewModel svm = new StatesViewModel
            {
                Action = "All"
            };

            var apiResponse = ApiCall.PostApi("StatesMasterRtr", JsonConvert.SerializeObject(svm));
            var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_StatesMasterRtr_Result>>>(apiResponse);

            if (response != null && response.result == true)
            {
                return View(response.data);
            }

            return View(new List<VIMS_StatesMasterRtr_Result>());
        }

        public ActionResult AddState(int? id)
        {
            try
            {
                StatesViewModel svm = new StatesViewModel();

                if (id.HasValue)
                {
                    svm.Action = "GetById";
                    svm.StateId = id.Value;

                    var apiResponse = ApiCall.PostApi("StatesMasterRtr", JsonConvert.SerializeObject(svm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_StatesMasterRtr_Result>>>(apiResponse);

                    if (response != null && response.result == true && response.data.Count > 0)
                    {
                        var item = response.data.First();
                        svm.StateId = item.StateId;
                        svm.StateCode = item.StateCode;
                        svm.StateName = item.StateName;
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
                Danger(ex.Message, "Master", "StatesMaster", true);
                return RedirectToAction("StatesMaster");
            }
        }

        [HttpPost]
        public ActionResult AddState(StatesViewModel svm)
        {
            try
            {
                string apiName = "StatesMasterInsUpd";

                if (svm.Action == "Save")
                {
                    svm.Action = "Insert";
                    svm.CreatedBy = User.Identity.Name;
                    svm.UpdatedBy = User.Identity.Name;
                }
                else
                {
                    svm.Action = "Update";
                    svm.UpdatedBy = User.Identity.Name;
                }

                var apiResponse = ApiCall.PostApi(apiName, JsonConvert.SerializeObject(svm));
                var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResponse);

                if (response != null && response.result == true)
                {
                    Success(response.message, "Master", "AddState", true);
                    return RedirectToAction("StatesMaster");
                }
                else
                {
                    Danger(response?.message ?? "Something went wrong", "Master", "AddState", true);
                    return View(svm);
                }
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "AddState", true);
                return View(svm);
            }
        }


        public ActionResult EditState(int id)
        {
            try
            {
                StatesViewModel svm = new StatesViewModel
                {
                    Action = "GetById",
                    StateId = id
                };

                var apiResponse = ApiCall.PostApi("StatesMasterRtr", JsonConvert.SerializeObject(svm));
                var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_StatesMasterRtr_Result>>>(apiResponse);

                if (response != null && response.result == true && response.data.Count > 0)
                {
                    var item = response.data.First();
                    svm.StateId = item.StateId;
                    svm.StateCode = item.StateCode;
                    svm.StateName = item.StateName;
                    svm.IsActive = item.IsActive;
                }

                svm.Action = "Update";
                ViewBag.Action = "Update";

                return View("AddState", svm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "StatesMaster", true);
                return RedirectToAction("StatesMaster");
            }
        }

        #endregion

        #region ==> City Master 

        public ActionResult CityMaster()
        {
            CityViewModel cvm = new CityViewModel
            {
                Action = "All"
            };

            var apiResponse = ApiCall.PostApi("CityMasterRtr", JsonConvert.SerializeObject(cvm));
            var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_CityMasterRtr_Result>>>(apiResponse);

            if (response != null && response.result == true)
            {
                return View(response.data);
            }

            return View(new List<VIMS_CityMasterRtr_Result>());
        }

        public ActionResult AddCity(int? id)
        {
            try
            {
                CityViewModel cvm = new CityViewModel();

                StatesViewModel svm = new StatesViewModel { Action = "ActiveStates" };
                var spApi = ApiCall.PostApi("StatesMasterRtr", JsonConvert.SerializeObject(svm));
                var spResponse = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_StatesMasterRtr_Result>>>(spApi);

                if (spResponse != null && spResponse.result)
                {
                    cvm.StatesList = spResponse.data;
                }

                if (id.HasValue)
                {
                    cvm.Action = "GetById";
                    cvm.CityId = id.Value;

                    var apiResponse = ApiCall.PostApi("CityMasterRtr", JsonConvert.SerializeObject(cvm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_CityMasterRtr_Result>>>(apiResponse);

                    if (response != null && response.result && response.data.Count > 0)
                    {
                        var item = response.data.First();

                        cvm.CityId = item.CityId;
                        cvm.CityCode = item.CityCode;
                        cvm.CityName = item.CityName;
                        cvm.StateId = item.StateId;
                        cvm.IsActive = item.IsActive;
                    }

                    ViewBag.Action = "Update";
                    cvm.Action = "Update";
                }
                else
                {
                    ViewBag.Action = "Add";
                    cvm.Action = "Save";
                }

                return View(cvm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "CityMaster", true);
                return RedirectToAction("CityMaster");
            }
        }

        [HttpPost]
        public ActionResult AddCity(CityViewModel cvm)
        {
            try
            {
                if (cvm.Action == "Save")
                {
                    cvm.Action = "Insert";
                    cvm.CreatedBy = User.Identity.Name;
                    cvm.UpdatedBy = User.Identity.Name;
                }
                else
                {
                    cvm.Action = "Update";
                    cvm.UpdatedBy = User.Identity.Name;
                }

                var apiResponse = ApiCall.PostApi("CityMasterInsUpd", JsonConvert.SerializeObject(cvm));
                var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResponse);

                if (response != null && response.result == true)
                {
                    Success(response.message, "Master", "AddCity", true);
                    return RedirectToAction("CityMaster");
                }
                else
                {
                    Danger(response?.message ?? "Something went wrong", "Master", "AddCity", true);
                    return View(cvm);
                }
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "AddCity", true);
                return View(cvm);
            }
        }

        public ActionResult EditCity(int id)
        {
            return RedirectToAction("AddCity", new { id = id });
        }


        #endregion

        #region ==> Customer Master

        public ActionResult CustomerMaster()
        {
            CustomerViewModel cvm = new CustomerViewModel
            {
                Action = "All"
            };

            var apiResponse = ApiCall.PostApi("CustomerMasterRtr", JsonConvert.SerializeObject(cvm));
            var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_CustomerMasterRtr_Result>>>(apiResponse);

            if (response != null && response.result)
            {
                return View(response.data);
            }

            return View(new List<VIMS_CustomerMasterRtr_Result>());
        }

        public ActionResult AddCustomer(int? id)
        {
            try
            {
                CustomerViewModel cvm = new CustomerViewModel();

                VIMS_RoleMasterRtr_Result roles = new VIMS_RoleMasterRtr_Result();
                var roleReq = new { Action = "ActiveRoles" };
                var roleApi = ApiCall.PostApi("RoleMasterRtr", JsonConvert.SerializeObject(roleReq));
                var roleResponse = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_RoleMasterRtr_Result>>>(roleApi);

                if (roleResponse != null && roleResponse.result)
                {
                    cvm.RoleList = roleResponse.data;
                }

                if (id.HasValue)
                {
                    cvm.Action = "GetById";
                    cvm.CustomerId = id.Value;

                    var apiResponse = ApiCall.PostApi("CustomerMasterRtr", JsonConvert.SerializeObject(cvm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_CustomerMasterRtr_Result>>>(apiResponse);

                    if (response != null && response.result && response.data.Count > 0)
                    {
                        var item = response.data.First();

                        cvm.CustomerId = item.CustomerId;
                        cvm.SocietyCode = item.SocietyCode;
                        cvm.CustomerCode = item.CustomerCode;
                        cvm.Name = item.Name;
                        cvm.Address = item.Address;
                        cvm.ContactNumber1 = item.ContactNumber1;
                        cvm.ContactNumber2 = item.ContactNumber2;
                        cvm.RoleId = item.RoleId;
                        cvm.IsActive = item.IsActive;
                        cvm.Password = item.Password;
                    }

                    ViewBag.Action = "Update";
                    cvm.Action = "Update";
                }
                else
                {
                    ViewBag.Action = "Add";
                    cvm.Action = "Save";
                }

                return View(cvm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "CustomerMaster", true);
                return RedirectToAction("CustomerMaster");
            }
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerViewModel cvm)
        {
            try
            {
                if (cvm.Action == "Save")
                {
                    cvm.Action = "Insert";
                    cvm.CreatedBy = User.Identity.Name;
                    cvm.UpdatedBy = User.Identity.Name;
                }
                else
                {
                    cvm.Action = "Update";
                    cvm.UpdatedBy = User.Identity.Name;
                }

                var apiResponse = ApiCall.PostApi("CustomerMasterInsUpd", JsonConvert.SerializeObject(cvm));
                var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResponse);

                if (response != null && response.result)
                {
                    Success(response.message, "Master", "CustomerMaster", true);
                    return RedirectToAction("CustomerMaster");
                }

                Danger(response?.message ?? "Something went wrong", "Master", "CustomerMaster", true);
                return View(cvm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "CustomerMaster", true);
                return View(cvm);
            }
        }

        public ActionResult EditCustomer(int id)
        {
            return RedirectToAction("AddCustomer", new { id = id });
        }


        #endregion

        #region ==> Admin Master

        public ActionResult AdminMaster()
        {
            AdminViewModel avm = new AdminViewModel { Action = "All" };

            var apiResponse = ApiCall.PostApi("AdminMasterRtr", JsonConvert.SerializeObject(avm));
            var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_AdminMasterRtr_Result>>>(apiResponse);

            if (response != null && response.result)
            {
                return View(response.data);
            }

            return View(new List<VIMS_AdminMasterRtr_Result>());
        }

        public ActionResult AddAdmin(int? id)
        {
            try
            {
                AdminViewModel avm = new AdminViewModel();

                var roleReq = new { Action = "ActiveRoles" };
                var roleApi = ApiCall.PostApi("RoleMasterRtr", JsonConvert.SerializeObject(roleReq));
                var roleResponse = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_RoleMasterRtr_Result>>>(roleApi);
                if (roleResponse != null && roleResponse.result)
                    avm.RoleList = roleResponse.data;

                var stateReq = new { Action = "ActiveStates" };
                var stateApi = ApiCall.PostApi("StatesMasterRtr", JsonConvert.SerializeObject(stateReq));
                var stateResponse = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_StatesMasterRtr_Result>>>(stateApi);
                if (stateResponse != null && stateResponse.result)
                    avm.StatesList = stateResponse.data;

                if (id.HasValue)
                {
                    avm.Action = "GetById";
                    avm.AdminId = id.Value;

                    var apiResponse = ApiCall.PostApi("AdminMasterRtr", JsonConvert.SerializeObject(avm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_AdminMasterRtr_Result>>>(apiResponse);

                    if (response != null && response.result && response.data.Count > 0)
                    {
                        var item = response.data.First();
                        avm.AdminId = item.AdminId;
                        avm.AdminCode = item.AdminCode;
                        avm.Name = item.Name;
                        avm.Gender = item.Gender;
                        avm.DateOfBirth = item.DateOfBirth;
                        avm.Address = item.Address;
                        avm.StateId = item.StateId;
                        avm.CityId = item.CityId;
                        avm.PinCode = item.PinCode;
                        avm.ContactNumber = item.ContactNumber;
                        avm.Password = item.Password;
                        avm.RoleId = item.RoleId;
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
                Danger(ex.Message, "Master", "AdminMaster", true);
                return RedirectToAction("AdminMaster");
            }
        }

        [HttpPost]
        public ActionResult AddAdmin(AdminViewModel avm)
        {
            try
            {
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

                avm.DateOfBirth = generalFunctions.ConvertDOB_To_YYYYMMDD(avm.DateOfBirth);

                var apiResponse = ApiCall.PostApi("AdminMasterInsUpd", JsonConvert.SerializeObject(avm));
                var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResponse);

                if (response != null && response.result)
                {
                    Success(response.message, "Master", "AdminMaster", true);
                    return RedirectToAction("AdminMaster");
                }

                Danger(response?.message ?? "Something went wrong", "Master", "AdminMaster", true);
                return View(avm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "AdminMaster", true);
                return View(avm);
            }
        }

        public ActionResult EditAdmin(int id)
        {
            return RedirectToAction("AddAdmin", new { id = id });
        }

      
        #endregion

        #region ==> Doctor Master

        public ActionResult DoctorMaster()
        {
            DoctorViewModel dvm = new DoctorViewModel { Action = "All" };

            var apiResponse = ApiCall.PostApi("DoctorMasterRtr", JsonConvert.SerializeObject(dvm));

            var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_DoctorMasterRtr_Result>>>(apiResponse);

            if (response != null && response.result)
            {
                return View(response.data);
            }

            return View(new List<VIMS_DoctorMasterRtr_Result>());
        }

        public ActionResult AddDoctor(int? id)
        {
            try
            {
                DoctorViewModel dvm = new DoctorViewModel();

                var stateReq = new { Action = "ActiveStates" };
                var stateApi = ApiCall.PostApi("StatesMasterRtr", JsonConvert.SerializeObject(stateReq));
                var stateResponse = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_StatesMasterRtr_Result>>>(stateApi);
                if (stateResponse != null && stateResponse.result)
                    dvm.StatesList = stateResponse.data;

                var roleReq = new { Action = "ActiveRoles" };
                var roleApi = ApiCall.PostApi("RoleMasterRtr", JsonConvert.SerializeObject(roleReq));
                var roleResponse = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_RoleMasterRtr_Result>>>(roleApi);
                if (roleResponse != null && roleResponse.result)
                    dvm.RoleList = roleResponse.data;

                if (id.HasValue)
                {
                    dvm.Action = "GetById";
                    dvm.DoctorId = id.Value;

                    var apiResponse = ApiCall.PostApi("DoctorMasterRtr", JsonConvert.SerializeObject(dvm));
                    var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_DoctorMasterRtr_Result>>>(apiResponse);

                    if (response != null && response.result && response.data.Count > 0)
                    {
                        var item = response.data.First();

                        dvm.DoctorId = item.DoctorId;
                        dvm.DoctorCode = item.DoctorCode;
                        dvm.Name = item.Name;
                        dvm.Gender = item.Gender;
                        dvm.DateOfBirth = item.DateOfBirth;
                        dvm.Address = item.Address;
                        dvm.StateId = item.StateId;
                        dvm.CityId = item.CityId;
                        dvm.PinCode = item.PinCode;
                        dvm.ContactNumber1 = item.ContactNumber1;
                        dvm.ContactNumber2 = item.ContactNumber2;
                        dvm.Password = item.Password;
                        dvm.RoleId = item.RoleId;
                        dvm.JoiningDate = item.JoiningDate;
                        dvm.EndingDate = item.EndingDate;
                        dvm.Qualifications = item.Qualifications;
                        dvm.SignaturePath = item.SignaturePath;
                        dvm.IsActive = item.IsActive;
                    }

                    ViewBag.Action = "Update";
                    dvm.Action = "Update";
                }
                else
                {
                    ViewBag.Action = "Add";
                    dvm.Action = "Save";
                }

                return View(dvm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "DoctorMaster", true);
                return RedirectToAction("DoctorMaster");
            }
        }

        [HttpPost]
        public ActionResult AddDoctor(HttpPostedFileBase signatureFile, DoctorViewModel dvm)
        {
            try
            {
                string path = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["fileupload"]);
                string folder = path + "DoctorSignature";

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                if (dvm.Action == "Save")
                {
                    if (signatureFile != null && signatureFile.ContentLength > 0)
                    {
                        string ext = Path.GetExtension(signatureFile.FileName);
                        string fileName = Guid.NewGuid() + ext;

                        dvm.SignaturePath = "DoctorSignature/" + fileName;

                        string fullpath = Path.Combine(folder, fileName);
                        signatureFile.SaveAs(fullpath);
                    }
                    else
                    {
                        Danger("Please upload doctor signature file.", "Master", "DoctorMaster", true);
                        return RedirectToAction("DoctorMaster");
                    }

                    dvm.Action = "Insert";
                    dvm.CreatedBy = User.Identity.Name;
                    dvm.UpdatedBy = User.Identity.Name;
                }
                else  
                {
                    if (signatureFile != null && signatureFile.ContentLength > 0)
                    {
                        string ext = Path.GetExtension(signatureFile.FileName);
                        string fileName = Guid.NewGuid() + ext;

                        dvm.SignaturePath = "DoctorSignature/" + fileName;

                        string fullpath = Path.Combine(folder, fileName);
                        signatureFile.SaveAs(fullpath);
                    }
                    else
                    {
                        dvm.SignaturePath = dvm.SignaturePath;  
                    }

                    dvm.Action = "Update";
                    dvm.UpdatedBy = User.Identity.Name;
                }


                dvm.DateOfBirth = generalFunctions.ConvertDOB_To_YYYYMMDD(dvm.DateOfBirth);
                dvm.JoiningDate = generalFunctions.ConvertDOB_To_YYYYMMDD(dvm.JoiningDate);
                dvm.EndingDate = generalFunctions.ConvertDOB_To_YYYYMMDD(dvm.EndingDate);

                var apiResponse = ApiCall.PostApi("DoctorMasterInsUpd", JsonConvert.SerializeObject(dvm));
                var response = JsonConvert.DeserializeObject<ApiResponse<string>>(apiResponse);

                if (response != null && response.result)
                {
                    Success(response.message, "Master", "DoctorMaster", true);
                    return RedirectToAction("DoctorMaster");
                }

                Danger(response?.message ?? "Something went wrong", "Master", "DoctorMaster", true);
                return View(dvm);
            }
            catch (Exception ex)
            {
                Danger(ex.Message, "Master", "DoctorMaster", true);
                return View(dvm);
            }
        }

        public ActionResult EditDoctor(int id)
        {
            return RedirectToAction("AddDoctor", new { id = id });
        }

        public ActionResult DownloadOrShowSignature(string id)
        {
            try
            {
                DoctorViewModel sb = new DoctorViewModel { Action = "All" };
                var apiResponse = ApiCall.PostApi("DoctorMasterRtr", JsonConvert.SerializeObject(sb));

                var response = JsonConvert.DeserializeObject<ApiResponse<List<VIMS_DoctorMasterRtr_Result>>>(apiResponse);

                if (response != null && response.result && response.data != null && response.data.Count > 0)
                {
                    var doctor = response.data.FirstOrDefault(x => x.DoctorCode.ToString() == id);

                    if (doctor != null && !string.IsNullOrEmpty(doctor.SignaturePath))
                    {
                        string fileUrl = string.Format("{0}{1}", System.Configuration.ConfigurationManager.AppSettings["FileRtr"], doctor.SignaturePath);

                        using (WebClient webClient = new WebClient())
                        {
                            byte[] fileBytes = webClient.DownloadData(fileUrl);
                            if (fileBytes != null && fileBytes.Length > 0)
                            {
                                string contentType = MimeMapping.GetMimeMapping(doctor.SignaturePath);
                                string fileExtension = Path.GetExtension(doctor.SignaturePath);
                                string fileName = id + fileExtension; 

                                return File(fileBytes, contentType, fileName);
                            }
                        }
                    }
                }

                return HttpNotFound("Signature not found.");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }



        #endregion

        #region ==> Ajax Method 

        [HttpPost]
        public JsonResult GetCitiesByState(int stateId)
        {
            try
            {
                var request = new { StateId = stateId, Action = "GetByState" };
                var cities = AjaxDataHelper.GetDataFromApi<VIMS_CityMasterRtr_Result>("CityMasterRtr", request);

                return Json(cities, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new List<VIMS_CityMasterRtr_Result>(), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}