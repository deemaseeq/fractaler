
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

		//TODO Find a proper ObservableCollection implementation
		TrianglesCollection = new ObservableCollection<Triangle>();

		MainTriangle = new Triangle(500, new Point(0, 500));
		MainTriangle.FillColor = Brushes.DarkSalmon;



		TrianglesCollection.Add(MainTriangle);

		CutTheCenter(MainTriangle.Points);
	}

	public Triangle MainTriangle { get; set; }

	private ObservableCollection<Triangle> trianglesCollection;
	public ObservableCollection<Triangle> TrianglesCollection
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
		cutted.FillColor = Brushes.WhiteSmoke;
		TrianglesCollection.Add(cutted);

		//! We can use some sort of tree structure to determine the depth of the fractal
		//TODO Implement or find a suitable tree

		if (cutted.SideLength < 5)
		{
			return;
		}

		CutTheCenter(new List<Point> { cutted.Points[0], basic[1], cutted.Points[1] });
		CutTheCenter(new List<Point> { basic[0], cutted.Points[0], cutted.Points[2] });
		CutTheCenter(new List<Point> { cutted.Points[2], cutted.Points[1], basic[2] });
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

