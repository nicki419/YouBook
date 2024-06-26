using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Avalonia.Markup.Xaml.Styling;

namespace YouBook.Lang
{
    public static class LocalisationHelper
    {
        public static List<CultureInfo> SupportedCultures = new List<CultureInfo>();
        public static CultureInfo Culture = new CultureInfo("en");
        public static List<CultureInfo> GetSupportedCultures()
        {
            var cultures = new List<CultureInfo>();
            var langFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lang");

            // Ensure English is always included
            var defaultCulture = new CultureInfo("en");
            cultures.Add(defaultCulture);

            if (Directory.Exists(langFolderPath))
            {
                var axamlFiles = Directory.GetFiles(langFolderPath, "*.axaml");

                foreach (var file in axamlFiles)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    var cultureCode = fileName.Split('.').LastOrDefault(); // Assuming the format is 'Strings.en-US'

                    if (!string.IsNullOrEmpty(cultureCode) && CultureInfo.GetCultures(CultureTypes.AllCultures).Any(c => c.Name == cultureCode))
                    {
                        var cultureInfo = new CultureInfo(cultureCode);
                        if (!cultures.Contains(cultureInfo))
                        {
                            cultures.Add(cultureInfo);
                        }
                    }
                }
            }

            return cultures.Distinct().ToList();
        }

        public static void AutoSetCulture()
        {
            var culture = CultureInfo.CurrentCulture;

            if (SupportedCultures.Contains(culture.Parent))
            {
                Culture = culture;
            }
            else
            {
                Culture = new CultureInfo("en");
            }
        }

        public static void SetLanguage(CultureInfo targetLanguage) {

        var translations = App.Current!.Resources.MergedDictionaries.OfType<ResourceInclude>().FirstOrDefault(x => x.Source?.OriginalString?.Contains("/Lang/") ?? false);

        if (translations != null)
            App.Current.Resources.MergedDictionaries.Remove(translations);

        App.Current.Resources.MergedDictionaries.Add(
            new ResourceInclude(new Uri($"avares://YouBook/Lang/Resources.{(targetLanguage.Parent.Name == "" ? targetLanguage.Name : targetLanguage.Parent.Name)}.axaml"))
            {
                Source = new Uri($"avares://YouBook/Lang/Resources.{(targetLanguage.Parent.Name == "" ? targetLanguage.Name : targetLanguage.Parent.Name)}.axaml")
            });
        Culture = targetLanguage;
        }
    }
}