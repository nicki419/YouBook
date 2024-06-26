using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.VisualTree;
using ReactiveUI;
using SukiUI.Controls;
using YouBook.Models.Messages;
using YouBook.ViewModels;

namespace YouBook.Views;

public partial class MainWindow : SukiWindow
{
    public MainWindow()
    {
        InitializeComponent();
        this.Opened += MainWindow_DataContextChanged;
    }

    private void MainWindow_DataContextChanged(object sender, EventArgs e)
    {
        if (DataContext is MainWindowViewModel viewModel) {
            viewModel.OpenIntroDialogueCommand.NotifyCanExecuteChanged();

            if (viewModel.OpenIntroDialogueCommand.CanExecute(null)) {
                viewModel.OpenIntroDialogueCommand.Execute(null);
            }
            this.DataContextChanged -= MainWindow_DataContextChanged;
            viewModel.ApplyUserSettings();
        }
    }
}