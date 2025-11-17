using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace VIMS.Web
{
    public class Logger
    {
        public enum LogType
        {
            /// <summary>
            /// Log Type : Information
            /// </summary>
            Information,
            /// <summary>
            /// Log Type : Exception
            /// </summary>
            Exception,
            /// <summary>
            /// Log Type : Warning
            /// </summary>
            Warning
        }
        #region Members
        /// <summary>
        /// _LogFileName : Log File Name
        /// </summary>
        string _LogFileName = "VIMS.Web";

        //string _LogFolder = "";
        /// <summary>
        /// Log Information
        /// </summary>
        bool logInformation = false;
        /// <summary>
        /// Log Exception
        /// </summary>
        bool logException = false;
        /// <summary>
        /// Log Warning
        /// </summary>
        bool logWarning = false;
        #endregion

        #region Object Construction
        /// <summary>
        /// CommunicationLogger : Non-Default Constructor
        /// </summary>
        public Logger()
        {
            logException = true;
            logInformation = true;
            logWarning = true;
        }

        public Logger(string FileName)
        {
            this._LogFileName = FileName;
            logException = true;
            logInformation = true;
            logWarning = true;
        }
        #endregion

        public class GetIPAddress
        {
            public static string GetClientIpAddress()
            {
                string ipAddress = HttpContext.Current.Request.UserHostAddress;

                return ipAddress;
            }
        }

        #region Public Method
        /// <summary>
        /// Log Message
        /// </summary>
        /// <param name="classname">Module Name</param>
        /// <param name="method">Method Name</param>
        /// <param name="message">Message</param>
        /// <param name="msgType">Message Type (Ref ConfigurationFiles\\ExpenseManagerConfigurationSettings.xml for behaviour)</param>
        public void LogMessage(string controller, string method, string message, LogType msgType)
        {
            string ipaddress = GetIPAddress.GetClientIpAddress();
            StreamWriter strW = null;
            try
            {
                bool isLoggingRequested = false;
                switch (msgType)
                {
                    case LogType.Exception:
                        if (logException)
                        {
                            isLoggingRequested = true;
                        }
                        break;
                    case LogType.Information:
                        if (logInformation)
                        {
                            isLoggingRequested = true;
                        }
                        break;
                    case LogType.Warning:
                        if (logWarning)
                        {
                            isLoggingRequested = true;
                        }
                        break;
                }
                if (isLoggingRequested)
                {
                    string logFile = HttpContext.Current.Server.MapPath("~/Logs/BanasDCSLogs/") + _LogFileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                    string callingAssembly = Assembly.GetCallingAssembly().ToString();
                    strW = new StreamWriter(logFile, true);
                    strW.WriteLine("[" + DateTime.Now + "] [" + Convert.ToString(msgType) + "] Ip Address : [" + ipaddress + "] Controller : [" + controller + "] Action : [" + method + "] Message : [" + message + "]");
                }
            }
            catch { }
            finally
            {
                try
                {
                    if (strW != null)
                    {
                        strW.Close();
                        strW = null;
                    }
                }
                catch { }
            }
        }
        #endregion
    }
}