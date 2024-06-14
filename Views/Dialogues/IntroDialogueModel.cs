using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SukiUI.Controls;
using ReactiveUI;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;


namespace YouBook.Views.Dialogues
{
    public class IntroDialogueModel : ObservableObject
    {
        private static void CloseDialog() => SukiHost.CloseDialog();
    }
}