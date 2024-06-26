using System.Globalization;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using YouBook.ViewModels;
using YouBook.Views;
using YouBook.Lang;
using Avalonia.Markup.Xaml.Styling;
using System;
using System.Linq;
using System.Configuration;
using System.Diagnostics;

namespace YouBook;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        LocalisationHelper.SupportedCultures = LocalisationHelper.GetSupportedCultures();
        LocalisationHelper.AutoSetCulture();
        Debug.WriteLine(GetDefaultExeConfigPath(ConfigurationUserLevel.PerUserRoamingAndLocal));

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
        LocalisationHelper.SetLanguage(LocalisationHelper.Culture);
    }

    public static string GetDefaultExeConfigPath(ConfigurationUserLevel userLevel)
    {
    try
    {
        var UserConfig = ConfigurationManager.OpenExeConfiguration(userLevel);
        return UserConfig.FilePath;
    }
    catch (ConfigurationException e)
    {
        return e.Filename;
    }
    }
}