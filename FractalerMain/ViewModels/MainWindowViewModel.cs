using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia;
using Avalonia.Media;
using FractalerMain.Models;
using ReactiveUI;

namespace FractalerMain.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        SelectedType = FractalType.SierpinskyTriangle;

        Build = ReactiveCommand.Create(() =>
        {
            FractalViewModel = SelectedType switch
            {
                FractalType.SierpinskyTriangle => new SieTriangleViewModel(500, SelectedDepth),
                _ => new SieTriangleViewModel(500, SelectedDepth)
            };
        });
    }

    private FractalViewModel _fractalViewModel;
    public FractalViewModel FractalViewModel
    {
        get => _fractalViewModel;
        set => this.RaiseAndSetIfChanged(ref _fractalViewModel, value);
    }
    
    private int _selectedDepth;
    /// <summary>
    /// Depth of the fractal selected by the user.
    /// <value>0-8, where 0 is just a shape. Max value of 8 is the highest reasonable value.</value>
    /// </summary>
    public int SelectedDepth
    {
        //TODO Find a way to increase depth without huge performance penalty
        get => _selectedDepth;
        set => this.RaiseAndSetIfChanged(ref _selectedDepth, value);
    }

    public FractalType SelectedType { get; set; }

    public ReactiveCommand<Unit, Unit> Build { get; }


    //TODO Find out how ICommand works with ReactiveUI and Avalonia

    //TODO Finish the UI
    //TODO Implement a color change

    //TODO Determine if we need unit tests and write them if so
}