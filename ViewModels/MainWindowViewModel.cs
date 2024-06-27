using System;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using ReactiveUI;
using CommunityToolkit.Mvvm.Input;
using SukiUI.Controls;
using YouBook.Views;
using YouBook.Views.Dialogues;
using YouBook.Models.Messages;
using System.Diagnostics;
using YouBook.Models;
using SukiUI;
using YouBook.Lang;
using Avalonia.Styling;
using System.Linq;
using Avalonia;

namespace YouBook.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel() {
        UserSettings = new UserSettings();
        ConvertViewModel = new ConvertViewModel();

        MessageBus.Current.Listen<LanguageChangedMessage>().Subscribe(HandleLanguageChangedMessage);
        MessageBus.Current.Listen<ThemeChangedMessage>().Subscribe(HandleThemeChangedMessage);
    }

    public ConvertViewModel ConvertViewModel { get; }

    public UserSettings UserSettings { get; }

    [RelayCommand(CanExecute = nameof(IntroDialogueCanExecute))]
    private static void OpenIntroDialogue() {
        SukiHost.ShowDialog(new IntroDialogueViewModel(), allowBackgroundClose: false);
    }

    private bool IntroDialogueCanExecute() {
        if(UserSettings.IsDarkTheme == null || UserSettings.ColourTheme == null || UserSettings.IsBackgroundAnimated == null || UserSettings.Language == null) {
            return true;
        } 
        return false;
    }

    public void ApplyUserSettings() {
        if(UserSettings.IsDarkTheme != null && UserSettings.ColourTheme != null && UserSettings.IsBackgroundAnimated != null && UserSettings.Language != null) {
            var _theme = SukiTheme.GetInstance();
            _theme.ChangeBaseTheme((bool)UserSettings.IsDarkTheme ? ThemeVariant.Dark : ThemeVariant.Light);
            Application.Current.RequestedThemeVariant = UserSettings.IsDarkTheme == true ? Avalonia.Styling.ThemeVariant.Dark : Avalonia.Styling.ThemeVariant.Light;
            _theme.ChangeColorTheme(_theme.ColorThemes.First(theme => theme.DisplayName == UserSettings.ColourTheme));
            _theme.SetBackgroundAnimationsEnabled(UserSettings.IsBackgroundAnimated == true);
            LocalisationHelper.SetLanguage(UserSettings.Language);
        }
    }

    private void HandleLanguageChangedMessage(LanguageChangedMessage message) {
        UserSettings.Language = LocalisationHelper.Culture;
        UserSettings.Save();
    }

    private void HandleThemeChangedMessage(ThemeChangedMessage message) {
        var _theme = SukiTheme.GetInstance();
        UserSettings.IsDarkTheme = _theme.ActiveBaseTheme == ThemeVariant.Dark;
        UserSettings.ColourTheme = _theme.ActiveColorTheme!.DisplayName;
        UserSettings.IsBackgroundAnimated = _theme.IsBackgroundAnimated;
        UserSettings.Save();
    }
}
