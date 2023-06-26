using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrl.Common.Exceptions
{
    public class CodeNotFoundException: Exception
    {
        public CodeNotFoundException(string code): base($"Code {code} not found.")
        {
        }
    }
}
