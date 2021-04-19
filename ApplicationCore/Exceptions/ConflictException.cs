using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions
{

    //this is the example of customer exceptions
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base()
        {
           

        }

    }
}
