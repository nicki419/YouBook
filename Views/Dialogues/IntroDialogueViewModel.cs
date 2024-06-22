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
    public partial class IntroDialogueViewModel : ViewModelBase
    {
        public IntroDialogueViewModel()
        {
            WelcomePageViewModel = new WelcomePageViewModel();
            ThemePageViewModel = new ThemePageViewModel();
            _contentViewModel = WelcomePageViewModel;

            MessageBus.Current.Listen<Models.Messages.StartButtonClickedMessage>().Subscribe(_ => StartButton());

            Debug.WriteLine("IntroDialogueModel created");
        }

        [ObservableProperty]private ViewModelBase _contentViewModel;

        public WelcomePageViewModel WelcomePageViewModel;
        public ThemePageViewModel ThemePageViewModel;

        private void StartButton() {
            ContentViewModel = ThemePageViewModel;
        }
    }
}