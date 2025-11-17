using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace VIMS.Web.GeneralClasses
{
    public class LangTrans
    {
        public static List<Languages> AvailableLanguages = new List<Languages>
        {
             new Languages{ LangFullName = "English", LangCultureName = "en"},
             new Languages{ LangFullName = "Gujarati", LangCultureName = "gu"}
        };

        public static bool IsLanguageAvailable(string lang) //Here all added languages are available  
        {
            return AvailableLanguages.Where(a => a.LangCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage() //On page load the default language selection is English.  
        {
            return AvailableLanguages[0].LangCultureName;
        }

        public void SetLanguage(string lang) //Here language selection with property and function setup  
        {
            try
            {
                if (!IsLanguageAvailable(lang))
                    lang = GetDefaultLanguage();
                var cultureInfo = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                HttpCookie langCookie = new HttpCookie("culture", lang);
                langCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(langCookie);

            }
            catch (Exception ex)
            {

            }
        }
    }

    public class Languages //Declare object names  
    {
        public string LangFullName { get; set; }
        public string LangCultureName { get; set; }
    }
}