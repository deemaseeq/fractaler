using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace FractalerMain.Views;

public partial class SieTriangleView : UserControl
{
    public SieTriangleView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}