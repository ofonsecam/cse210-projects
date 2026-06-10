using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapesList = new List<Shape>();

            Square smallSquare = new Square("Red", 4.0);
            Rectangle mediumRectangle = new Rectangle("Blue", 5.0, 3.0);
            Circle plateCircle = new Circle("Green", 2.0);

            shapesList.Add(smallSquare);
            shapesList.Add(mediumRectangle);
            shapesList.Add(plateCircle);

            Console.WriteLine("---Results of Area Calculations---");
            foreach (Shape shape in shapesList)
            {
                string color = shape.GetColor();
                double area = shape.GetArea();

                string shapeType = shape.GetType().Name;
                Console.WriteLine($"Form:{shapeType} ({color}): Area = {area:F2}");
            }
        }
    }
}