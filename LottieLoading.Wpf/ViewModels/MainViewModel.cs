using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LottieLoading.Wpf.Commands;
using LottieLoading.Wpf.Dialogs;
using MvvmDialogs;

namespace LottieLoading.Wpf.ViewModels;

public class MainViewModel : ObservableObject
{
    private readonly IDialogService _dialogService;

    public MainViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }

    public ICommand ShowDialogCommand => new RelayCommand(ShowDialog);
    public ICommand ShowBackgroundDialogCommand => new RelayCommand(execute: async () => await ShowBackgroundDialog());

    private async Task ShowBackgroundDialog()
    {
        var progressNotifier = new ProgressNotifier();
        var dialogTask = Task.Run(() =>
            Application.Current.Dispatcher.Invoke(() =>
                _dialogService.ShowDialog<ModalDialog>(this,
                    new ProgressNotifiedModalDialogViewModel(progressNotifier))));

        var longRunningTask = Task.Run(async () =>
        {
            Application.Current.Dispatcher.Invoke(() => { progressNotifier.Progress = 10; });
            await Task.Delay(1000);
            Application.Current.Dispatcher.Invoke(() => { progressNotifier.Progress = 20; });
            await Task.Delay(1000);
            Application.Current.Dispatcher.Invoke(() => { progressNotifier.Progress = 30; });
            await Task.Delay(1000);
            Application.Current.Dispatcher.Invoke(() => { progressNotifier.Progress = 40; });
            await Task.Delay(1000);
            Application.Current.Dispatcher.Invoke(() => { progressNotifier.Progress = 100; });
        });

        await Task.WhenAll(dialogTask, longRunningTask);
    }

    private void ShowDialog()
    {
        var success = _dialogService.ShowDialog<ModalDialog>(this, new ModalDialogViewModel());
    }
}
