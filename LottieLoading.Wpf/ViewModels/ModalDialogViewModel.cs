using System.IO;
using System.Threading.Tasks;
using System.Windows;
using MvvmDialogs;

namespace LottieLoading.Wpf.ViewModels;

public class ModalDialogViewModel : ObservableObject, IModalDialogViewModel
{
    private bool? _dialogResult;
    private string _filePath = string.Empty;

    public ModalDialogViewModel()
    {
        foreach (var item in Directory.EnumerateFiles(@".\Assets"))
        {
            if (!item.EndsWith(".json")) continue;
            FilePath = item;
            break;
        }

        Task.Run(async () =>
        {
            await Task.Delay(5000);
            Application.Current.Dispatcher.Invoke(() => { DialogResult = true; });
        });
    }


    public bool? DialogResult
    {
        get => _dialogResult;
        private set => SetField(ref _dialogResult, value);
    }

    public string FilePath
    {
        get => _filePath;
        set => SetField(ref _filePath, value);
    }
}
