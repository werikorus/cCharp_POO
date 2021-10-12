using System;
using cCharp_POO.Entities.Enums;


namespace cCharp_POO.Entities
{
    abstract class Shape
    {
        public Color Color { get; set; }
               
        public Shape(Color color)
        {
            Color = color;
        }

        public abstract double Area();

    }
}
