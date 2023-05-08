
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Avalonia;
using Avalonia.Media;

using FractalerMain.Models;

namespace FractalerMain.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Fractal = new SieTriangleViewModel(500);
    }
    
    public FractalViewModel Fractal { get; set; }
    

    //TODO Define the structure of the VM
    //TODO Find out how ICommand works with ReactiveUI and Avalonia

    //TODO Create a UI wrap for the process
    //TODO We need a button to create a canvas and build the triangle with given depth
    //TODO Implement rebuilding with other parameters
    //TODO Implement a color change

    //TODO Determine if we need unit tests and write them if so
}

