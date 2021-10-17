using System;
using cCharp_POO.Entities.Exceptions;


namespace cCharp_POO.Entities.Exceptions
{
    class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {

        }

    }
}
