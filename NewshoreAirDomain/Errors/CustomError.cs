using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewshoreAirDomain.Errors
{
    /// <summary>
    /// CustomError represents a custom exception that can be used
    /// to indicate specific errors in the application
    /// </summary>
    public class CustomError : Exception
    {
        public CustomError(string message, Exception innerException)
        : base(message, innerException) { }
    }
}
