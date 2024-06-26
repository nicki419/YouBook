using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Styling;
using SukiUI;
using SukiUI.Models;

namespace YouBook.Models
{
    public class UserSettings: ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [DefaultSettingValue(null)]
        public CultureInfo? Language {
            get => (CultureInfo?)this["Language"];
            set => this["Language"] = value;
        }



        [UserScopedSetting()]
        [DefaultSettingValue(null)]
        public bool? IsDarkTheme {
            get => (bool?)this["IsDarkTheme"];
            set => this["IsDarkTheme"] = value;
        }

        [UserScopedSetting()]
        [DefaultSettingValue(null)]
        public string? ColourTheme {
            get => (string?)this["ColourTheme"];
            set => this["ColourTheme"] = value;
        }

        [UserScopedSetting()]
        [DefaultSettingValue(null)]
        public bool? IsBackgroundAnimated {
            get => (bool?)this["IsBackgroundAnimated"];
            set => this["IsBackgroundAnimated"] = value;
        }
    }
}