using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverDealerOn
{
    public class RoverOutOfBoundsException : Exception 
    {
        public RoverOutOfBoundsException()
        {
        }

        public RoverOutOfBoundsException(string message)
        : base(message)
        {

        }

        public RoverOutOfBoundsException(string message, Exception inner)
        : base(message, inner)
    {
        }



    }
}
