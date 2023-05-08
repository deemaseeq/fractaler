using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FractalerMain.Models;

using Avalonia;
using Avalonia.Media;

namespace FractalerMain.ViewModels
{
    public class SieTriangleViewModel : FractalViewModel
    {
        public SieTriangleViewModel(int sideLength)
        {
            SideLenght = sideLength;
            
            MainTriangle = new Triangle(SideLenght, new Point(0, SideLenght));
            MainTriangle.FillColor = Brushes.DarkSalmon;

            //TODO Get this value from a parameter
            Depth = 6;

            TrianglesCollection = new ObservableCollection<Triangle>();
            TrianglesCollection.Add(MainTriangle);

            CutTheCenter(MainTriangle.Points, Depth);
        }

        private Triangle MainTriangle { get; set; }
        public ObservableCollection<Triangle> TrianglesCollection { get; private set; }
        
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
    }
}

