using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.WebApp2.Exceptions
{

    public class ApiAuthenticationException : Exception
    {
        public ApiAuthenticationException()
        {
        }

        public ApiAuthenticationException(string message) : base(message)
        {
        }
    }
}
