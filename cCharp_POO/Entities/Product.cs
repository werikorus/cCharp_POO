using System;
using System.Collections.Generic;
using System.Globalization;

namespace cCharp_POO.Entities
{
    class Product
    {
        private object na;

        public string Name { get; set; }
        public double Price { get; set; }

        public Product(){}

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public Product(object na)
        {
            this.na = na;
        }

        public virtual string PriceTag() {
            return Name
               + " $ "
               + Price.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
