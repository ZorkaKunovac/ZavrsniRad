using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.WebApp2.Exceptions
{
    public class ApiAuthorizationException : Exception
    {
        public ApiAuthorizationException()
        {
        }

        public ApiAuthorizationException(string message) : base(message)
        {
        }
    }
}
