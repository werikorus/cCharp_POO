using System;
using System.Collections.Generic;
using System.Text;

namespace cCharp_POO.Services
{
    class CanadaTaxService: ITaxService
    {
        public double Tax(double amount)
        {
            if (amount <= 100.00)
            {
                return amount * 0.3;
            }
            else
            {
                return amount * 0.19;
            }
        }
    }
}
