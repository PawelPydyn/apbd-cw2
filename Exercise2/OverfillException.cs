using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    internal class OverfillException : Exception
    {
        public OverfillException() : base("PRZELADOWANIE!!!") { 

        }
        public OverfillException(string message) : base(message)
        {
        
        }
    }
}
