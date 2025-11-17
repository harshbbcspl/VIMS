using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIMS.DB;
using VIMS.Model.Master;

namespace VIMS.API.Controllers
{
    public class VIMSApiController : ApiController
    {
        VIMSEntities db = new VIMSEntities();

        #region ==> Master API 

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
    }
}
