using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrl.Common.Exceptions
{
    public class InvalidUrlException : Exception
    {
        public InvalidUrlException(string url) : base($"Invalid Url: {url}")
        {
        }
    }
}
