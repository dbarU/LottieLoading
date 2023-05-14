using System.Windows;

namespace LottieLoading.Wpf.ViewModels;

public class ProgressNotifier : ObservableObject
{

    private double _progress;

    public double Progress
    {
        get => _progress;
        set => SetField(ref _progress, value);
    }
}
