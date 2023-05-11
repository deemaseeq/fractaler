using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Media;

namespace FractalerMain.Models
{
    public class Triangle
    {

        public Triangle(int sideLength, Point leftPoint, bool isFlipped = false)
        {

            var height = sideLength * (Math.Sqrt(3) / 2);

            Point firstPoint;
            Point secondPoint;
            Point thirdPoint;

            if (isFlipped)
            {
                firstPoint = new Point(leftPoint.X, leftPoint.Y - height);
                secondPoint = new Point(firstPoint.X + sideLength, firstPoint.Y);
                thirdPoint = new Point(sideLength / 2, firstPoint.Y + height);
            }
            else
            {
                firstPoint = leftPoint;
                secondPoint = new Point(sideLength / 2, firstPoint.Y - height);
                thirdPoint = new Point(leftPoint.X + sideLength, firstPoint.Y);
            }
            
            Points = new List<Point>
            {
                firstPoint,
                secondPoint,
                thirdPoint
            };

            SideLength = sideLength;
        }

        public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            Points = new List<Point>
            {
                firstPoint,
                secondPoint,
                thirdPoint
            };

            SideLength = thirdPoint.X - firstPoint.X;
        }


        public IList<Point> Points { get; private set; }
        
        public double SideLength { get; private set; }

        public ISolidColorBrush FillColor { get; set; }

        private static Point FindSideMiddlePoint(Point firstPoint, Point secondPoint)
        {
            //TODO Check if points belong to canvas
            //TODO Possible check if the point belongs to original line

            double middleX = (firstPoint.X + secondPoint.X) / 2;
            double middleY = (firstPoint.Y + secondPoint.Y) / 2;
            Point middlePoint = new(middleX, middleY);
            return middlePoint;
        }

        public Triangle CreateInlineTriangle()
        {
            Point firstPoint = FindSideMiddlePoint(Points[0], Points[1]);
            Point secondPoint = FindSideMiddlePoint(Points[1], Points[2]);
            Point thirdPoint = FindSideMiddlePoint(Points[2], Points[0]);

            Triangle inlineTriangle = new(firstPoint, secondPoint, thirdPoint);
            return inlineTriangle;
        }

        public static Triangle CreateInlineTriangle
            (Point baseFirstPoint, Point baseSecondPoint, Point baseThirdPoint)
        {
            Point firstPoint = FindSideMiddlePoint(baseFirstPoint, baseSecondPoint);
            Point secondPoint = FindSideMiddlePoint(baseSecondPoint, baseThirdPoint);
            Point thirdPoint = FindSideMiddlePoint(baseThirdPoint, baseFirstPoint);

            Triangle inlineTriangle = new(firstPoint, secondPoint, thirdPoint);
            return inlineTriangle;
        }

        public static Triangle CreateInlineTriangle
            (IList<Point> baseTrianglePoints)
        {
            Point firstPoint = FindSideMiddlePoint(baseTrianglePoints[0], baseTrianglePoints[1]);
            Point secondPoint = FindSideMiddlePoint(baseTrianglePoints[1], baseTrianglePoints[2]);
            Point thirdPoint = FindSideMiddlePoint(baseTrianglePoints[2], baseTrianglePoints[0]);

            Triangle inlineTriangle = new Triangle(firstPoint, secondPoint, thirdPoint);
            return inlineTriangle;
        }
    }
}

