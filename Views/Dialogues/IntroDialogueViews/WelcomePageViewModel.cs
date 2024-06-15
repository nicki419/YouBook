using System;
using System.Collections.Generic;
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

            if(SupportedCultures.Contains(CultureInfo.CurrentCulture.NativeName))
            {
                SelectedSupportedCulture = CultureInfo.CurrentCulture.NativeName;
            } 
            else 
            {
                SelectedSupportedCulture = "English";
            }
        }
        public AvaloniaList<string> SupportedCultures { get; } = [];
        [ObservableProperty] private string _selectedSupportedCulture;
    }
}