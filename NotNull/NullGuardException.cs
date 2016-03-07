using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotNull
{
    public class NullGuardException : Exception
    {
        public NullGuardException(string message) : base(message)
        {
            // do nothing - calling base constructor
        }
    }
}
