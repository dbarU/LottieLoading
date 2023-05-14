using System.Windows.Input;
using LottieLoading.Wpf.Commands;
using MvvmDialogs;

namespace LottieLoading.Wpf.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly IDialogService _dialogService;

    public MainViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;
    }

    public ICommand ShowDialogCommand => new RelayCommand(ShowDialog);

    private void ShowDialog()
    {
        var dialogViewModel = new ModalDialogViewModel();
        var success = _dialogService.ShowDialog(this, dialogViewModel);
      
    }
}