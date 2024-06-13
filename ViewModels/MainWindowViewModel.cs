using System;
using System.Runtime.InteropServices;
using ReactiveUI;

namespace YouBook.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel() {
        if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
            TitleBarVisible = false;
            WindowHeight = 490;
        } else {
            WindowHeight = 450;
        }
    }
    private int windowHeight = 450;
    public int WindowHeight {
        get => windowHeight;
        set => this.RaiseAndSetIfChanged(ref windowHeight, value);
    }
    private bool titleBarVisible = true;
    public bool TitleBarVisible {
        get => titleBarVisible;
        set => this.RaiseAndSetIfChanged(ref titleBarVisible, value);
    }
}
