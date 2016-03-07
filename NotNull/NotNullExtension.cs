using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotNull
{
    [System.Diagnostics.DebuggerNonUserCode]
    public static class NotNullExtension
    {
        public static T NotNull<T>(this T @this) where T : class
        {
            if (@this == null)
            {
                throw new NullGuardException("Value cannot be null");
            }

            return @this;
        }

        public static NotNull<T> AsNotNull<T>(this T @this) where T : class
        {
            return @this;
        }
    }
}
