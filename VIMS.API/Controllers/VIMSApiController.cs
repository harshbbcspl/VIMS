using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIMS.DB;
using VIMS.Model.Home;
using VIMS.Model.Master;
using VIMS.Model.Usermanagement;

namespace VIMS.API.Controllers
{
    public class VIMSApiController : ApiController
    {
        VIMSEntities db = new VIMSEntities();

        #region ==> Home Controller API 

        #region ==>  Login API
        [HttpPost]
        [Route("api/VIMSApi/LoginCheckGet")]
        public HttpResponseMessage LoginCheckGet(LoginViewModel svm)
        {
            try
            {
                if (string.IsNullOrEmpty(svm.UserCode) || string.IsNullOrEmpty(svm.Password))
                {
                    var response = new
                    {
                        result = false,
                        message = "SocietyCode and Password are required",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

                var data = db.VIMS_LoginCheck(
                    svm.UserCode,
                    svm.Password
                ).FirstOrDefault();

                if (data != null)
                {
                    var response = new
                    {
                        result = true,
                        message = "Login success",
                        data = data
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    var response = new
                    {
                        result = false,
                        message = "Invalid username or password",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                var response = new
                {
                    result = false,
                    message = "An error occurred: " + ex.Message,
                    data = ""
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }


        [HttpPost]
        [Route("api/VIMSApi/LoginUserRtr")]
        public HttpResponseMessage LoginUserRtr(LoginViewModel svm)
        {
            try
            {
                if (string.IsNullOrEmpty(svm.UserCode) || string.IsNullOrEmpty(svm.Password))
                {
                    var response = new
                    {
                        result = false,
                        message = "SocietyCode and Password are required",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

                var data = db.VIMS_LoginRtr(
                    svm.UserCode,
                    svm.Password
                ).ToList();

                if (data != null && data.Count > 0)
                {
                    var response = new
                    {
                        result = true,
                        message = "Login data retrieved successfully",
                        data = data
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    var response = new
                    {
                        result = false,
                        message = "Invalid username or password",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                var response = new
                {
                    result = false,
                    message = "An error occurred: " + ex.Message,
                    data = ""
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }

        #endregion

        #region==> Change Password Api
        [HttpPost]
        [Route("api/VIMSApi/ChangePassword")]
        public HttpResponseMessage ChangePassword(ChangePasswordViewModel vm)
        {
            try
            {
                if (string.IsNullOrEmpty(vm.UserCode) ||
                    string.IsNullOrEmpty(vm.OldPassword) ||
                    string.IsNullOrEmpty(vm.NewPassword))
                {
                    var response = new
                    {
                        result = false,
                        message = "UserCode, OldPassword and NewPassword are required",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

                var result = db.VIMS_ChangePassword(
                    vm.UserCode,
                    vm.OldPassword,
                    vm.NewPassword,
                    vm.CreateDate
                ).FirstOrDefault();

                var responseSuccess = new
                {
                    result = true,
                    message = result,
                    data = ""
                };

                return Request.CreateResponse(HttpStatusCode.OK, responseSuccess);
            }
            catch (Exception ex)
            {
                var responseError = new
                {
                    result = false,
                    message = "An error occurred: " + ex.Message,
                    data = ""
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, responseError);
            }
        }
        #endregion

        #endregion


        #region ==> Master Controller API 

        #region ==> Species Master API

        [HttpPost]
        [Route("api/VIMSApi/SpeciesMasterRtr")]
        public HttpResponseMessage SpeciesMasterRtr(SpeciesViewModel svm)
        {
            try
            {
                if (string.IsNullOrEmpty(svm.Action))
                {
                    var response = new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

                var data = db.VIMS_SpeciesMasterRtr(
                    svm.SpeciesId,
                    svm.SpeciesCode,
                    svm.Action
                ).ToList();

                if (data != null && data.Count > 0)
                {
                    var response = new
                    {
                        result = true,
                        message = "Data retrieved successfully",
                        data = data
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    var response = new
                    {
                        result = false,
                        message = "No records found",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                var responseError = new
                {
                    result = false,
                    message = "An error occurred: " + ex.Message,
                    data = ""
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPost]
        [Route("api/VIMSApi/SpeciesMasterInsUpd")]
        public HttpResponseMessage SpeciesMasterInsUpd(SpeciesViewModel svm)
        {
            try
            {
                if (string.IsNullOrEmpty(svm.Action))
                {
                    var response = new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

                var result = db.VIMS_SpeciesMasterInsUpd(
                    svm.SpeciesId,
                    svm.SpeciesName,
                    svm.SpeciesCode,
                    svm.CreatedBy,
                    svm.UpdatedBy,
                    svm.IsActive,
                    svm.Action
                ).FirstOrDefault();

                var responseSuccess = new
                {
                    result = true,
                    message = result,
                    data = ""
                };

                return Request.CreateResponse(HttpStatusCode.OK, responseSuccess);
            }
            catch (Exception ex)
            {
                var responseError = new
                {
                    result = false,
                    message = "An error occurred: " + ex.Message,
                    data = ""
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, responseError);
            }
        }

        #endregion

        #region ==> Breed Master API

        [HttpPost]
        [Route("api/VIMSApi/BreedMasterRtr")]
        public HttpResponseMessage BreedMasterRtr(BreedViewModel bvm)
        {
            try
            {
                if (string.IsNullOrEmpty(bvm.Action))
                {
                    var response = new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

                var data = db.VIMS_BreedMasterRtr(
                    bvm.BreedId,
                    bvm.BreedCode,
                    bvm.SpeciesCode,
                    bvm.Action
                ).ToList();

                if (data != null && data.Count > 0)
                {
                    var response = new
                    {
                        result = true,
                        message = "Data retrieved successfully",
                        data = data
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    var response = new
                    {
                        result = false,
                        message = "No records found",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                var responseError = new
                {
                    result = false,
                    message = "An error occurred: " + ex.Message,
                    data = ""
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPost]
        [Route("api/VIMSApi/BreedMasterInsUpd")]
        public HttpResponseMessage BreedMasterInsUpd(BreedViewModel bvm)
        {
            try
            {
                if (string.IsNullOrEmpty(bvm.Action))
                {
                    var response = new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

                var result = db.VIMS_BreedMasterInsUpd(
                    bvm.BreedId,
                    bvm.BreedCode,
                    bvm.BreedName,
                    bvm.SpeciesCode,
                    bvm.CreatedBy,
                    bvm.UpdatedBy,
                    bvm.IsActive,
                    bvm.Action
                ).FirstOrDefault();

                var responseSuccess = new
                {
                    result = true,
                    message = result,
                    data = ""
                };

                return Request.CreateResponse(HttpStatusCode.OK, responseSuccess);
            }
            catch (Exception ex)
            {
                var responseError = new
                {
                    result = false,
                    message = "An error occurred: " + ex.Message,
                    data = ""
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, responseError);
            }
        }

        #endregion

        #region ==> Ailment Master API

        [HttpPost]
        [Route("api/VIMSApi/AilmentMasterRtr")]
        public HttpResponseMessage AilmentMasterRtr(AilmentViewModel avm)
        {
            try
            {
                if (string.IsNullOrEmpty(avm.Action))
                {
                    var response = new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

                var data = db.VIMS_AilmentMasterRtr(
                    avm.AilmentId,
                    avm.AilmentCode,
                    avm.Action
                ).ToList();

                if (data != null && data.Count > 0)
                {
                    var response = new
                    {
                        result = true,
                        message = "Data retrieved successfully",
                        data = data
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    var response = new
                    {
                        result = false,
                        message = "No records found",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                var responseError = new
                {
                    result = false,
                    message = "An error occurred: " + ex.Message,
                    data = ""
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPost]
        [Route("api/VIMSApi/AilmentMasterInsUpd")]
        public HttpResponseMessage AilmentMasterInsUpd(AilmentViewModel avm)
        {
            try
            {
                if (string.IsNullOrEmpty(avm.Action))
                {
                    var response = new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

                var result = db.VIMS_AilmentMasterInsUpd(
                    avm.AilmentId,
                    avm.AilmentCode,
                    avm.AilmentName,
                    avm.CreatedBy,
                    avm.UpdatedBy,
                    avm.IsActive,
                    avm.Action
                ).FirstOrDefault();

                var responseSuccess = new
                {
                    result = true,
                    message = result,
                    data = ""
                };

                return Request.CreateResponse(HttpStatusCode.OK, responseSuccess);
            }
            catch (Exception ex)
            {
                var responseError = new
                {
                    result = false,
                    message = "An error occurred: " + ex.Message,
                    data = ""
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, responseError);
            }
        }

        #endregion

        #region ==> States Master API

        [HttpPost]
        [Route("api/VIMSApi/StatesMasterRtr")]
        public HttpResponseMessage StatesMasterRtr(StatesViewModel svm)
        {
            try
            {
                if (string.IsNullOrEmpty(svm.Action))
                {
                    var response = new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

                var data = db.VIMS_StatesMasterRtr(
                    svm.StateId,
                    svm.StateCode,
                    svm.Action
                ).ToList();

                if (data != null && data.Count > 0)
                {
                    var response = new
                    {
                        result = true,
                        message = "Data retrieved successfully",
                        data = data
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    var response = new
                    {
                        result = false,
                        message = "No records found",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                var responseError = new
                {
                    result = false,
                    message = "An error occurred: " + ex.Message,
                    data = ""
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPost]
        [Route("api/VIMSApi/StatesMasterInsUpd")]
        public HttpResponseMessage StatesMasterInsUpd(StatesViewModel svm)
        {
            try
            {
                if (string.IsNullOrEmpty(svm.Action))
                {
                    var response = new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

                var result = db.VIMS_StatesMasterInsUpd(
                    svm.StateId,
                    svm.StateCode,
                    svm.StateName,
                    svm.CreatedBy,
                    svm.UpdatedBy,
                    svm.IsActive,
                    svm.Action
                ).FirstOrDefault();

                var responseSuccess = new
                {
                    result = true,
                    message = result,
                    data = ""
                };

                return Request.CreateResponse(HttpStatusCode.OK, responseSuccess);
            }
            catch (Exception ex)
            {
                var responseError = new
                {
                    result = false,
                    message = "An error occurred: " + ex.Message,
                    data = ""
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, responseError);
            }
        }

        #endregion

        #region ==> City Master API

        [HttpPost]
        [Route("api/VIMSApi/CityMasterRtr")]
        public HttpResponseMessage CityMasterRtr(CityViewModel cvm)
        {
            try
            {
                if (string.IsNullOrEmpty(cvm.Action))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    });
                }

                var data = db.VIMS_CityMasterRtr(
                                cvm.CityId,
                                cvm.CityCode,
                                cvm.StateId,
                                cvm.Action
                           ).ToList();

                if (data != null && data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        result = true,
                        message = "Data retrieved successfully",
                        data = data
                    });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        result = false,
                        message = "No records found",
                        data = ""
                    });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    result = false,
                    message = "Error: " + ex.Message,
                    data = ""
                });
            }
        }

        [HttpPost]
        [Route("api/VIMSApi/CityMasterInsUpd")]
        public HttpResponseMessage CityMasterInsUpd(CityViewModel cvm)
        {
            try
            {
                if (string.IsNullOrEmpty(cvm.Action))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    });
                }

                var result = db.VIMS_CityMasterInsUpd(
                                cvm.CityId,
                                cvm.CityCode,
                                cvm.CityName,
                                cvm.StateId,
                                cvm.CreatedBy,
                                cvm.UpdatedBy,
                                cvm.IsActive,
                                cvm.Action
                             ).FirstOrDefault();

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    result = true,
                    message = result,
                    data = ""
                });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    result = false,
                    message = "Error: " + ex.Message,
                    data = ""
                });
            }
        }

        #endregion

        #region ==> Admin Master API

        [HttpPost]
        [Route("api/VIMSApi/AdminMasterRtr")]
        public HttpResponseMessage AdminMasterRtr(AdminViewModel avm)
        {
            try
            {
                if (string.IsNullOrEmpty(avm.Action))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    });
                }

                var data = db.VIMS_AdminMasterRtr(
                                avm.AdminId,
                                avm.AdminCode,
                                avm.Action
                           ).ToList();

                if (data != null && data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        result = true,
                        message = "Data retrieved successfully",
                        data = data
                    });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        result = false,
                        message = "No records found",
                        data = ""
                    });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    result = false,
                    message = "Error: " + ex.Message,
                    data = ""
                });
            }
        }

        [HttpPost]
        [Route("api/VIMSApi/AdminMasterInsUpd")]
        public HttpResponseMessage AdminMasterInsUpd(AdminViewModel avm)
        {
            try
            {
                if (string.IsNullOrEmpty(avm.Action))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    });
                }

                var result = db.VIMS_AdminMasterInsUpd(
                                avm.AdminId,
                                avm.AdminCode,
                                avm.Name,
                                avm.Gender,
                                avm.DateOfBirth,
                                avm.Address,
                                avm.CityId,
                                avm.StateId,
                                avm.PinCode,
                                avm.ContactNumber,
                                avm.Password,
                                avm.RoleId,
                                avm.CreatedBy,
                                avm.UpdatedBy,
                                avm.IsActive,
                                avm.Action
                             ).FirstOrDefault();

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    result = true,
                    message = result,
                    data = ""
                });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    result = false,
                    message = "Error: " + ex.Message,
                    data = ""
                });
            }
        }



        #endregion

        #region ==> Customer Master API

        [HttpPost]
        [Route("api/VIMSApi/CustomerMasterRtr")]
        public HttpResponseMessage CustomerMasterRtr(CustomerViewModel cvm)
        {
            try
            {
                if (string.IsNullOrEmpty(cvm.Action))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    });
                }

                var data = db.VIMS_CustomerMasterRtr(
                                cvm.CustomerId,
                                cvm.CustomerCode,
                                cvm.SocietyCode,
                                cvm.Action
                           ).ToList();

                if (data != null && data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        result = true,
                        message = "Data retrieved successfully",
                        data = data
                    });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        result = false,
                        message = "No records found",
                        data = ""
                    });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    result = false,
                    message = "Error: " + ex.Message,
                    data = ""
                });
            }
        }

        [HttpPost]
        [Route("api/VIMSApi/CustomerMasterInsUpd")]
        public HttpResponseMessage CustomerMasterInsUpd(CustomerViewModel cvm)
        {
            try
            {
                if (string.IsNullOrEmpty(cvm.Action))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    });
                }

                var result = db.VIMS_CustomerMasterInsUpd(
                                cvm.CustomerId,
                                cvm.SocietyCode,
                                cvm.CustomerCode,
                                cvm.Name,
                                cvm.Address,
                                cvm.ContactNumber1,
                                cvm.ContactNumber2,
                                cvm.RoleId,
                                cvm.Password,
                                cvm.CreatedBy,
                                cvm.UpdatedBy,
                                cvm.IsActive,
                                cvm.Action
                             ).FirstOrDefault();

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    result = true,
                    message = result,
                    data = ""
                });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    result = false,
                    message = "Error: " + ex.Message,
                    data = ""
                });
            }
        }


        #endregion

        #region ==> Doctor Master API

        [HttpPost]
        [Route("api/VIMSApi/DoctorMasterRtr")]
        public HttpResponseMessage DoctorMasterRtr(DoctorViewModel dvm)
        {
            try
            {
                if (string.IsNullOrEmpty(dvm.Action))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    });
                }

                var data = db.VIMS_DoctorMasterRtr(
                                dvm.DoctorId,
                                dvm.DoctorCode,
                                dvm.Action
                            ).ToList();

                if (data != null && data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        result = true,
                        message = "Data retrieved successfully",
                        data = data
                    });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new
                    {
                        result = false,
                        message = "No records found",
                        data = ""
                    });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    result = false,
                    message = ex.Message,
                    data = ""
                });
            }
        }

        [HttpPost]
        [Route("api/VIMSApi/DoctorMasterInsUpd")]
        public HttpResponseMessage DoctorMasterInsUpd(DoctorViewModel dvm)
        {
            try
            {
                if (string.IsNullOrEmpty(dvm.Action))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    });
                }

                var resultMessage = db.VIMS_DoctorMasterInsUpd(
                                        dvm.DoctorId,
                                        dvm.DoctorCode,
                                        dvm.Name,
                                        dvm.Gender,
                                        dvm.DateOfBirth,
                                        dvm.Address,
                                        dvm.CityId,
                                        dvm.StateId,
                                        dvm.PinCode,
                                        dvm.ContactNumber1,
                                        dvm.ContactNumber2,
                                        dvm.Password,
                                        dvm.RoleId,
                                        dvm.JoiningDate,
                                        dvm.EndingDate,
                                        dvm.Qualifications,
                                        dvm.SignaturePath,
                                        dvm.CreatedBy,
                                        dvm.UpdatedBy,
                                        dvm.IsActive,
                                        dvm.Action
                                    ).FirstOrDefault();

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    result = true,
                    message = resultMessage,
                    data = ""
                });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    result = false,
                    message = ex.Message,
                    data = ""
                });
            }
        }


        #endregion

        #endregion

        #region ==> Usermanagement Controller Api 

        #region ==> Role Master API

        [HttpPost]
        [Route("api/VIMSApi/RoleMasterRtr")]
        public HttpResponseMessage RoleMasterRtr(RoleMasterViewModel rvm)
        {
            try
            {
                if (string.IsNullOrEmpty(rvm.Action))
                {
                    var response = new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

                var data = db.VIMS_RoleMasterRtr(
                    rvm.RoleId,
                    rvm.Action
                ).ToList();

                if (data != null && data.Count > 0)
                {
                    var response = new
                    {
                        result = true,
                        message = "Data retrieved successfully",
                        data = data
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    var response = new
                    {
                        result = false,
                        message = "No records found",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                var responseError = new
                {
                    result = false,
                    message = "An error occurred: " + ex.Message,
                    data = ""
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPost]
        [Route("api/VIMSApi/RoleMasterInsUpd")]
        public HttpResponseMessage RoleMasterInsUpd(RoleMasterViewModel rvm)
        {
            try
            {
                if (string.IsNullOrEmpty(rvm.Action))
                {
                    var response = new
                    {
                        result = false,
                        message = "Action is required",
                        data = ""
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }

                var result = db.VIMS_RoleMasterInsUpd(
                    rvm.RoleId,
                    rvm.RoleName,
                    rvm.CreatedBy,
                    rvm.UpdatedBy,
                    rvm.IsActive,
                    rvm.Action
                ).FirstOrDefault();

                var responseSuccess = new
                {
                    result = true,
                    message = result,
                    data = ""
                };

                return Request.CreateResponse(HttpStatusCode.OK, responseSuccess);
            }
            catch (Exception ex)
            {
                var responseError = new
                {
                    result = false,
                    message = "An error occurred: " + ex.Message,
                    data = ""
                };
                return Request.CreateResponse(HttpStatusCode.InternalServerError, responseError);
            }
        }

        #endregion


        #endregion

    }
}
