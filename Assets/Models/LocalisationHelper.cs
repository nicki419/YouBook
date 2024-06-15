using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using YouBook.Lang;

namespace YouBook.Assets.Models
{
    public class LocalisationHelper
    {
        public static List<CultureInfo> GetSupportedCultures() {
            ResourceManager rm = new ResourceManager(typeof(Resources));
            List<CultureInfo> supportedCultures = new List<CultureInfo>();
            foreach(CultureInfo culture in CultureInfo.GetCultures(CultureTypes.AllCultures)) {
                try {
                    ResourceSet rs = rm.GetResourceSet(culture, true, false);
                    // or ResourceSet rs = rm.GetResourceSet(new CultureInfo(culture.TwoLetterISOLanguageName), true, false);
                    string isSupported = (rs == null) ? " is not supported" : " is supported";
                    Debug.WriteLine(culture + isSupported);
                    if(rs != null) supportedCultures.Add(culture);
                }
                catch (CultureNotFoundException exc)
                {
                    Debug.WriteLine(culture + " is not available on the machine or is an invalid culture identifier.");
                }
            }
            return supportedCultures;
        }
    }
}