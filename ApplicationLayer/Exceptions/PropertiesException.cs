using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Exceptions
{
    public sealed class PropertiesException : Exception
    {
        public PropertiesException(string requestName, Error? error = default, Exception? innerException = default)
            : base("Application exception", innerException)
        {
            RequestName = requestName;
            Error = error;
        }

        public string RequestName { get; }

        public Error? Error { get; }
    }
}
