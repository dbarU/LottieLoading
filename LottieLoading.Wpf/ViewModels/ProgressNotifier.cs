namespace LottieLoading.Wpf.ViewModels;

public class ProgressNotifier : ObservableObject
{

    private double _progress;

    public double Progress
    {
        get => _progress;
        set
        {
            _progress = value;
            OnPropertyChanged(nameof(Progress));
        }
    }
}