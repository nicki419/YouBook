using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SukiUI.Controls;
using ReactiveUI;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using YouBook.ViewModels;
using YouBook.Views.Dialogues.IntroDialogueViews;
using System.Diagnostics;


namespace YouBook.Views.Dialogues
{
    public class IntroDialogueViewModel : ObservableObject
    {
        public IntroDialogueViewModel()
        {
            WelcomePageViewModel = new WelcomePageViewModel();
            IntroStacksModel = new IntroStacksViewModel();
            _contentViewModel = WelcomePageViewModel;
            Debug.WriteLine("IntroDialogueModel created");
        }
        private static void CloseDialog() => SukiHost.CloseDialog();

        private ViewModels.ViewModelBase _contentViewModel;
        public ViewModels.ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            set => SetProperty(ref _contentViewModel, value);
        }

        public WelcomePageViewModel WelcomePageViewModel;
        public IntroStacksViewModel IntroStacksModel;

        private static void StartButton() {

        }
    }
}