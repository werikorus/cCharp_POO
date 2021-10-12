using System;
using cCharp_POO.Entities.Enums;

namespace cCharp_POO.Entities
{
    class Circle: Shape
    {
        public double  Radius { get; set; }
                
        public Circle(double radius, Color color): base(color)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * (Radius * Radius);
        }
    }
}
