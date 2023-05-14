using System.ComponentModel;
using System.IO;
using MvvmDialogs;

namespace LottieLoading.Wpf.ViewModels;

public class ProgressNotifiedModalDialogViewModel : ObservableObject, IModalDialogViewModel
{
    private bool? _dialogResult;
    private readonly ProgressNotifier _progressNotifier;
    private string _filePath = string.Empty;

    public ProgressNotifiedModalDialogViewModel(ProgressNotifier progressNotifier)
    {
        _progressNotifier = progressNotifier;
        _progressNotifier.PropertyChanged += ProgressNotifierOnPropertyChanged;
        foreach (var item in Directory.EnumerateFiles(@".\Assets"))
        {
            if (!item.EndsWith(".json")) continue;
            FilePath = item;
            break;
        }
    }

    public string FilePath
    {
        get => _filePath;
        set => SetField(ref _filePath, value);
    }

    private void ProgressNotifierOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(ProgressNotifier.Progress)) return;
        if (_progressNotifier.Progress >= 100)
        {
            DialogResult = true;
        }
    }

    public bool? DialogResult
    {
        get => _dialogResult;
        private set => SetField(ref _dialogResult, value);
    }
}