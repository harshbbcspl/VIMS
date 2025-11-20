using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using VIMS.Model.Home;

namespace VIMS.Web.Helpers
{
    public static class AjaxDataHelper
    {
        public static List<T> GetDataFromApi<T>(string apiName, object request)
        {
            try
            {
                var apiResponse = ApiCall.PostApi(apiName, JsonConvert.SerializeObject(request));
                var response = JsonConvert.DeserializeObject<ApiResponse<List<T>>>(apiResponse);

                if (response != null && response.result)
                    return response.data;

                return new List<T>();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }
    }
}