using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VIMS.Web.GeneralClasses
{
    public class Alert
    {
        public const string TempDataKey = "TempDataAlerts";
        public string AlertStyle { get; set; }
        public string Message { get; set; }
        public string AlertMsg { get; set; }
        public bool Dismissable { get; set; }
    }

    public static class AlertStyles
    {
        public const string Success = "success";
        public const string Information = "info";
        public const string Warning = "warning";
        public const string Danger = "error";
        public const string SuccessMsg = "Success! ";
        public const string InformationMsg = "Note! ";
        public const string WarningMsg = "Warning! ";
        public const string ErrorMsg = "Error! ";
    }
}