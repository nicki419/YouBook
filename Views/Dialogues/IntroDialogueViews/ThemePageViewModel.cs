using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Collections;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SukiUI;
using SukiUI.Controls;
using SukiUI.Models;
using YouBook.ViewModels;

namespace YouBook.Views.Dialogues.IntroDialogueViews
{
    public partial class ThemePageViewModel: ViewModelBase
    {
        public IAvaloniaReadOnlyList<SukiColorTheme> AvailableColours { get; }
        private readonly SukiTheme _theme = SukiTheme.GetInstance();
        [ObservableProperty] private bool _isBackgroundAnimated;
        [ObservableProperty] private bool _isLightTheme;

        public ThemePageViewModel()
        {
            AvailableColours = _theme.ColorThemes;
            IsLightTheme = _theme.ActiveBaseTheme == ThemeVariant.Light;
            IsBackgroundAnimated = _theme.IsBackgroundAnimated;
            _theme.OnBaseThemeChanged += variant =>
                IsLightTheme = variant == ThemeVariant.Light;
            _theme.OnColorThemeChanged += theme =>
            {
                // TODO: Implement a way to make the correct, might need to wrap the thing in a VM, this isn't ideal.
            };
            _theme.OnBackgroundAnimationChanged += value =>
                IsBackgroundAnimated = value;
        }

        public void ChangeBaseTheme(bool value) {
            Debug.WriteLine($"Changing base theme to {(value ? "Light" : "Dark")}");
            _theme.ChangeBaseTheme(value ? ThemeVariant.Light : ThemeVariant.Dark);
        }

        partial void OnIsBackgroundAnimatedChanged(bool value) {
            _theme.SetBackgroundAnimationsEnabled(value);
        }

        [RelayCommand]
        public void SwitchToColorTheme(SukiColorTheme colorTheme) =>
            _theme.ChangeColorTheme(colorTheme);

        public void FinishButton() {
            Debug.WriteLine("Finish button clicked");
            SukiHost.CloseDialog();
        }
    }
}