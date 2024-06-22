using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReactiveUI;
using YouBook.Lang;
using YouBook.Models.Messages;
using YouBook.ViewModels;

namespace YouBook.Views.Dialogues.IntroDialogueViews
{
    public partial class WelcomePageViewModel : ViewModelBase
    {
        public WelcomePageViewModel()
        {
            SupportedCultures = new AvaloniaList<string> {};
            foreach (CultureInfo culture in LocalisationHelper.SupportedCultures)
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

            if(SupportedCultures.Contains(LocalisationHelper.Culture.IsNeutralCulture ? LocalisationHelper.Culture.Parent.NativeName : LocalisationHelper.Culture.Parent.NativeName))
            {
                SelectedSupportedCulture = LocalisationHelper.Culture.IsNeutralCulture ? LocalisationHelper.Culture.Parent.NativeName : LocalisationHelper.Culture.Parent.NativeName;
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
            LocalisationHelper.SetLanguage(cultureInfo ?? new CultureInfo("en"));
            Debug.WriteLine("Selected culture: " + LocalisationHelper.Culture.NativeName);
            
        }

        public void StartButtonClicked() {
            Debug.WriteLine("Start button clicked");
            MessageBus.Current.SendMessage(new StartButtonClickedMessage());
        }
    }
}