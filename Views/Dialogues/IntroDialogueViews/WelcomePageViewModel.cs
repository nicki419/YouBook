using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using YouBook.Assets.Models;
using YouBook.ViewModels;

namespace YouBook.Views.Dialogues.IntroDialogueViews
{
    public partial class WelcomePageViewModel : ViewModelBase
    {
        public WelcomePageViewModel()
        {
            SupportedCultures = new AvaloniaList<string> {};
            foreach (CultureInfo culture in LocalisationHelper.GetSupportedCultures())
            {
                if (culture.Equals(CultureInfo.InvariantCulture))
                {
                    SupportedCultures.Add("English"); // Add "English" for InvariantCulture
                }
                else
                {
                    SupportedCultures.Add(culture.NativeName); // Otherwise, add the culture's native name
                }
            }

            if(SupportedCultures.Contains(Lang.Resources.Culture.IsNeutralCulture ? Lang.Resources.Culture.Parent.NativeName : Lang.Resources.Culture.Parent.NativeName))
            {
                SelectedSupportedCulture = Lang.Resources.Culture.IsNeutralCulture ? Lang.Resources.Culture.Parent.NativeName : Lang.Resources.Culture.Parent.NativeName;
            } 
            else 
            {
                SelectedSupportedCulture = "English";
            }
        }
        public AvaloniaList<string> SupportedCultures { get; } = [];
        [ObservableProperty] private string _selectedSupportedCulture;
        partial void OnSelectedSupportedCultureChanged(string? oldValue, string newValue)
        {
            if(oldValue == newValue) return;

            var cultureInfo = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .FirstOrDefault(culture => culture.NativeName.Equals(newValue, StringComparison.InvariantCultureIgnoreCase));
            Lang.Resources.Culture = cultureInfo ?? CultureInfo.InvariantCulture;
            Debug.WriteLine("Selected culture: " + Lang.Resources.Culture.NativeName);
            
        }
    }
}