using System;
using System.Globalization;

namespace cCharp_POO.Entities
{
    class ImportedProduct : Product
    {
        public double CustomsFee { get; set; }

        public ImportedProduct() { }

        public ImportedProduct(string name, double price, double customFee)
            : base(name, price)
        {
            CustomsFee = customFee;
        }

        public double TotalPrice()
        {
            return Price + CustomsFee;
        }

        public override string PriceTag()
        {
            return Name
                    + " $ "
                    + TotalPrice().ToString("F2", CultureInfo.InvariantCulture)
                    + " (Customs fee: $ "
                    + CustomsFee.ToString("F2", CultureInfo.InvariantCulture)
                    + ")";
        }

    }

}
