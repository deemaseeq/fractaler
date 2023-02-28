
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Avalonia;
using Avalonia.Media;

using SierpinskyTriangleShapes.Models;

namespace SierpinskyTriangleShapes.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        MainTriangle = new Triangle(500, new Point(0, 500));
        MainTriangle.FillColor = Brushes.DarkSalmon;

        Depth = 6;

        TrianglesCollection = new ObservableCollection<Triangle>();
        TrianglesCollection.Add(MainTriangle);

        CutTheCenter(MainTriangle.Points, Depth);
    }

    public Triangle MainTriangle { get; private set; }
    public ObservableCollection<Triangle> TrianglesCollection { get; private set; }
    public int Depth { get; private set; }


    private void CutTheCenter(IList<Point> basic, int depth)
    {
        if (depth == 0)
        {
            return;
        }

        Triangle cutted = Triangle.CreateInlineTriangle(basic);
        cutted.FillColor = Brushes.WhiteSmoke;
        TrianglesCollection.Add(cutted);

        CutTheCenter(new List<Point> { cutted.Points[0], basic[1], cutted.Points[1] }, depth - 1);
        CutTheCenter(new List<Point> { basic[0], cutted.Points[0], cutted.Points[2] }, depth - 1);
        CutTheCenter(new List<Point> { cutted.Points[2], cutted.Points[1], basic[2] }, depth - 1);
    }

    //TODO Find a way to use .xaml file extension instead of .axaml

    //TODO Define the structure of the VM
    //TODO Find out how ICommand works with ReactiveUI and Avalonia

    //TODO Create a UI wrap for the process
    //TODO We need a button to create a canvas and build the triangle with given depth
    //TODO Implement rebuilding with other parameters
    //TODO Implement a color change

    //TODO Determine if we need unit tests and write them if so
}

