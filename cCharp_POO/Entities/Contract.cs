using System;
using System.Collections.Generic;

namespace cCharp_POO.Entities
{
    class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }

        public double TotalValue { get; set; }

        public List<Installment>Installment{ get; set; }

    }
}
