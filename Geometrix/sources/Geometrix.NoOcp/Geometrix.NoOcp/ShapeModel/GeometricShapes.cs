﻿using System;
using System.Collections.ObjectModel;

namespace iQuest.Geometrix.NoOcp.ShapeModel
{
    internal class GeometricShapes : Collection<object>
    {
        public double CalculateArea()
        {
            double area = 0;

            foreach (object shape in Items)
            {
                switch (shape)
                {
                    case Rectangle rectangle:
                        area += rectangle.Width * rectangle.Height;
                        break;

                    case Circle circle:
                        area += circle.Radius * circle.Radius * Math.PI;
                        break;
                    case Triangle triangle:
                        double p = (triangle.SideA + triangle.SideB + triangle.SideC) / 2;
                        area += Math.Sqrt(p*(p-triangle.SideA)*(p-triangle.SideB)*(p-triangle.SideC));
                        break;
                    default:
                        throw new Exception("Unknown shape.");
                }
            }

            return area;
        }
    }
}