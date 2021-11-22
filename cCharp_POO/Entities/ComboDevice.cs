using System;

namespace cCharp_POO.Entities
{
    class ComboDevice : Device, IScanner, IPrinter
    {
        public void Print(string document)
        {
            Console.WriteLine("ComboDevice print " + document );
        }

        public override void ProcessDoc(string document)
        {
            Console.WriteLine("Combodevice  processing " + document);
        }

        public string Scan()
        {
            return "Combodevice scan result";
        }
    }
}
