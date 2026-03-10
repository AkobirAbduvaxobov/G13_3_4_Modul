using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_1_Exception
{
    public class AgeException : Exception
    {
        public AgeException(string errorMessage) : base(errorMessage)
        { }
    }
}
