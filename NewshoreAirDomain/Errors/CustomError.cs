using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirDomain.Errors
{
    public class CustomError : Exception
    {
        public CustomError(string message, Exception innerException)
        : base(message, innerException) { }

    }
}
