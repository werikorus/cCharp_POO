using System;
using System.Collections.Generic;
using System.Text;
using cCharp_POO.Entities.Enums;

namespace cCharp_POO.Entities
{
    abstract class AbstractShape : IShape
    {
        public Color Color { get; set; }

        public abstract double Area();
    }
}
