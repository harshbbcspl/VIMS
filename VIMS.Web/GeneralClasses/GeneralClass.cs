using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Security.Cryptography;
using System.Web.Routing;
using System.Configuration;
using System.Net.Mail;
using VIMS.Model.Home;

namespace VIMS.Web.GeneralClasses
{
    public abstract class GeneralClass : Controller
    {
        protected readonly Logger Log;

        public GeneralClass()
        {
            Log = new Logger();
        }
        public void Success(string message, string controller, string action, bool dismissable = false)
        {
            AddAlert(AlertStyles.Success, message, dismissable, AlertStyles.SuccessMsg);
            Log.LogMessage(controller, action, message, Logger.LogType.Information);
        }

        public void Information(string message, string controller, string action, bool dismissable = false)
        {
            AddAlert(AlertStyles.Information, message, dismissable, AlertStyles.InformationMsg);
            Log.LogMessage(controller, action, message, Logger.LogType.Information);
        }

        public void Warning(string message, string controller, string action, bool dismissable = false)
        {
            AddAlert(AlertStyles.Warning, message, dismissable, AlertStyles.WarningMsg);
            Log.LogMessage(controller, action, message, Logger.LogType.Warning);
        }

        public void Danger(string message, string controller, string action, bool dismissable = false)
        {
            AddAlert(AlertStyles.Danger, message, dismissable, AlertStyles.ErrorMsg);
            Log.LogMessage(controller, action, message, Logger.LogType.Exception);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable, string AlertMsg)
        {
            var alerts = TempData.ContainsKey(Alert.TempDataKey)
                ? (List<Alert>)TempData[Alert.TempDataKey]
                : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                AlertMsg = AlertMsg,
                Dismissable = dismissable
            });

            TempData[Alert.TempDataKey] = alerts;
        }
        public class generalFunctions
        {
            #region ==>GeneralFunctions
            public static string Encrypt(string toEncrypt, bool useHashing)
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
                string key = "bbcspl";

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }

            public static string Decrypt(string cipherString, bool useHashing)
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                string key = "bbcspl";

                if (useHashing)
                {
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            public static string getTimeZoneDatetimedb()
            {
                var info = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTimeOffset localServerTime = DateTimeOffset.Now;
                DateTimeOffset gatime = TimeZoneInfo.ConvertTime(localServerTime, info);
                string gatimes = gatime.ToString("yyyy-MM-dd HH:mm:ss");
                return gatimes.Replace('.', ':');
            }
            public static string getTimeZoneTime()
            {
                var info = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTimeOffset localServerTime = DateTimeOffset.Now;
                DateTimeOffset gatime = TimeZoneInfo.ConvertTime(localServerTime, info);
                string gatimes = gatime.ToString("HH:mm:ss");
                return gatimes.Replace('.', ':');
            }

            public static string getTimeZoneTimeHHMM()
            {
                var info = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTimeOffset localServerTime = DateTimeOffset.Now;
                DateTimeOffset gatime = TimeZoneInfo.ConvertTime(localServerTime, info);
                string gatimes = gatime.ToString("HH:mm");
                return gatimes.Replace('.', ':');
            }
            public static string ConvertDOB_To_YYYYMMDD(string dob)
            {
                try
                {
                    DateTime parsed = DateTime.ParseExact(dob, "dd-MM-yyyy",
                                    System.Globalization.CultureInfo.InvariantCulture);
                    return parsed.ToString("yyyy-MM-dd");
                }
                catch
                {
                    return dob;
                }
            }
            public static string getDate()
            {
                var info = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTimeOffset localServerTime = DateTimeOffset.Now;
                DateTimeOffset gatime = TimeZoneInfo.ConvertTime(localServerTime, info);
                return gatime.ToString("yyyy-MM-dd");
            }
            public static string getDDMMYYYYDate()
            {
                var info = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTimeOffset localServerTime = DateTimeOffset.Now;
                DateTimeOffset gatime = TimeZoneInfo.ConvertTime(localServerTime, info);
                return gatime.ToString("dd-MM-yyyy");
            }
            public static string getMonthDateYearConvert(string strdate)
            {
                string str = "";
                str = strdate.Split('-').ElementAt(1) + "-" + strdate.Split('-').ElementAt(0) + "-" + strdate.Split('-').ElementAt(2);
                return str;
            }
            public static string getYearMonth()
            {
                var info = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTimeOffset localServerTime = DateTimeOffset.Now;
                DateTimeOffset gatime = TimeZoneInfo.ConvertTime(localServerTime, info);
                return gatime.ToString("yyyy-MM");
            }
            public static string dateconvert(string strdate)
            {
                string str = "";
                str = strdate.Split('-').ElementAt(2) + "-" + strdate.Split('-').ElementAt(1) + "-" + strdate.Split('-').ElementAt(0);
                return str;
            }
            public static string dateconvert1(string strdate)
            {
                string str = "";
                str = strdate.Split('-').ElementAt(0) + "-" + strdate.Split('-').ElementAt(1) + "-" + strdate.Split('-').ElementAt(2);
                return str;
            }


            public static string GetFiscalYear(DateTime date)
            {
                if (date.Month <= 12)
                {
                    return int.Parse(date.ToString("yyyy")).ToString();
                }
                else
                {
                    return date.Year.ToString() + "-" + (int.Parse(date.ToString("yyyy")) + 1).ToString();
                }
                //if (date.Month < 4)
                //{
                //    return (int.Parse(date.ToString("yyyy")) - 1).ToString() + "-" + date.ToString("yyyy");
                //}
                //else
                //{
                //    return date.Year.ToString() + "-" + (int.Parse(date.ToString("yyyy")) + 1).ToString();
                //}
            }

            public static String getCommon(String AbsoluteUri)
            {
                string page = "";
                try
                {
                    page = AbsoluteUri;
                    char[] delimiterChars = { '/' };
                    string[] link = page.Split(delimiterChars);


                    int length = link.Length;
                    var ab = link[length - 2].ToString() + "/" + link[length - 1].ToString();
                    page = ab;
                }
                catch (Exception ex)
                { ex.Message.ToString(); }
                return page;
            }

            public static string GetConnectionString(string conString)
            {
                string[] parts = conString.Split(';');
                List<string> updatedParts = new List<string>();

                foreach (string part in parts)
                {
                    if (!part.StartsWith("metadata="))
                    {
                        updatedParts.Add(part);
                    }
                }

                string newConnectionString = string.Join(";", updatedParts);
                int startIndex = newConnectionString.IndexOf("provider connection string=") + "provider connection string=".Length;
                string extractedConnectionString = newConnectionString.Substring(startIndex).Trim('"');
                return extractedConnectionString;
            }

            #endregion

        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies["LoginMaster"] != null)
            {
                if (filterContext.HttpContext.Request.Cookies["LoginMaster"]["IsLogin"] != "True")
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                            {"controller", "Home"},
                            {"action", "Login"}
                            });
                }
                else
                {
                    Language();
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                            {"controller", "Home"},
                            {"action", "Login"}
                            });
            }
        }

        public static void SendMail_Message(string strSubject, string strBodyMessage, string strTo, string strcc, string strBCC, string strAttachment = "")
        {
            string MailFrom = ConfigurationManager.AppSettings["UserName"];
            string MailUid = ConfigurationManager.AppSettings["Userid"];
            string MailPwd = ConfigurationManager.AppSettings["Password"];
            string host = ConfigurationManager.AppSettings["smtpAddress"];
            int Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);

            MailMessage mail = new MailMessage();


            mail.From = new MailAddress(MailFrom);


            mail.To.Add(strTo);

            if (strcc != null || strcc.Length > 0 || strcc == "")
            {
                mail.CC.Add(strcc);
            }

            if (strBCC != null && strBCC.Length > 0 || strBCC == "")
            {
                mail.Bcc.Add(strBCC);
            }

            // Attachment part is added on 09-01-2021
            if (!string.IsNullOrEmpty(strAttachment))
            {
                foreach (var attach in strAttachment.Split(';'))
                {
                    mail.Attachments.Add(new Attachment(attach));
                }
            }

            mail.Subject = strSubject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = strBodyMessage;
            mail.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
            mail.IsBodyHtml = true;
            ///// imt
            System.Net.Mail.AlternateView plainView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(strBodyMessage, @"<(.|\n)*?>", string.Empty), null, "text/plain");
            System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(strBodyMessage, null, "text/html");
            mail.AlternateViews.Add(plainView);
            mail.AlternateViews.Add(htmlView);
            SmtpClient smtp = new SmtpClient(host);
            System.Net.NetworkCredential netcred = new System.Net.NetworkCredential(MailUid, MailPwd);

            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = netcred;
            smtp.Port = Port;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                //return;
                throw ex;
            }
        }

        public void Language()
        {
            new LangTrans().SetLanguage(LoggedUserDetails.Language);
        }

        public LoginViewModel LoggedUserDetails
        {
            get
            {
                LoginViewModel em = new LoginViewModel();
                HttpCookie reqCookies = Request.Cookies["LoginMaster"];
                if (reqCookies != null)
                {
                    em.UserCode = reqCookies["UserCode"].ToString();
                    em.UserName = reqCookies["UserName"].ToString();
                    em.RoleId = reqCookies["RoleId"].ToString();
                    em.RoleName = reqCookies["RoleName"].ToString();
                    em.Language = reqCookies["Lang"].ToString();
                    em.IsLogin = reqCookies["IsLogin"].ToString();
                    return em;
                }
                else
                {
                    return em;
                }
            }
        }

    }
}