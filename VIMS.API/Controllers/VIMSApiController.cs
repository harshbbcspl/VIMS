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
