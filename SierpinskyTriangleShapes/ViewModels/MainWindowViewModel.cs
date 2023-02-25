
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.Shapes;
using DynamicData.Binding;
using SierpinskyTriangleShapes.Models;

namespace SierpinskyTriangleShapes.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        this.depth = 7;

        //TODO Find a proper ObservableCollection implementation
        TrianglesCollection = new ObservableCollectionExtended<Triangle>();

        MainTriangle = new Triangle(400, new Point(0, 400));

        TrianglesCollection.Add(MainTriangle);



        InlineTriangle = MainTriangle.CreateInlineTriangle();
    }

    public Triangle MainTriangle { get; set; }
    public Triangle InlineTriangle { get; set; }

    private IObservableCollection<Triangle> trianglesCollection;
    public IObservableCollection<Triangle> TrianglesCollection
    {
        get => trianglesCollection;
        set
        {
            trianglesCollection = value;
            //TODO Notify property changed
        }
    }

    private int depth;

    private void CutTheCenter(IList<Point> basic)
    {

        Triangle cutted = Triangle.CreateInlineTriangle(basic);
        TrianglesCollection.Add(cutted);

        //TODO How to limit depth of the recursion?

        if (cutted.SideLength < 10)
        {
            return;
        }

        CutTheCenter(new List<Point> { cutted.Points[0], basic[1], cutted.Points[2] });
        CutTheCenter(new List<Point> { basic[0], cutted.Points[0], cutted.Points[1] });
        CutTheCenter(new List<Point> { cutted.Points[1], cutted.Points[2], basic[2] });
    }

    //TODO Define the structure of the VM
    //TODO Find out how ICommand works with ReactiveUI and Avalonia

    //TODO Define how triangle will be drawn after the program start
    //TODO Connect VM triangles collection with the view
}

