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

namespace YouBook.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel() {
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
            TitleBarVisible = false;
        }
    }

    [RelayCommand(CanExecute = nameof(IntroDialogueCanExecute))]
    private static void OpenIntroDialogue() {
        SukiHost.ShowDialog(new IntroDialogueViewModel(), allowBackgroundClose: true);
    }

    private bool IntroDialogueCanExecute() {
        return true;
    }

    private bool titleBarVisible = true;
    public bool TitleBarVisible {
        get => titleBarVisible;
        set => this.SetProperty(ref titleBarVisible, value);
    }
}
