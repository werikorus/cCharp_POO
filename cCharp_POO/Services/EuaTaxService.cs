using System;
using System.Collections.Generic;
using System.Text;

namespace cCharp_POO.Services
{
    class EuaTaxService : ITaxService
    {
        public double Tax(double amount)
        {
            if (amount <= 100.0)
            {
                return amount * 0.9;
            }
            else
            {
                return amount * 0.23;
            }
        }

    }
}
