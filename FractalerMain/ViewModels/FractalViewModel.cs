using Avalonia.Media;

namespace FractalerMain.ViewModels;

public abstract class FractalViewModel : ViewModelBase
{
    protected int Depth { get; set; }

    protected int SideLenght { get; set; }
    
    public ISolidColorBrush ForegroundColor { get; set; }
    public ISolidColorBrush AccentColor { get; set; }
}