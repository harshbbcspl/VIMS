using System;
using System.Collections.Generic;

namespace VIMS.Model.Home
{
    public class ApiResponse<T>
    {
        public bool result { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }

    public class LoginCheckResult
    {
        public string SocietyCode { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserResult
    {
        public string SocietyCode { get; set; }
        public string SocietyName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
