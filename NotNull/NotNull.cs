using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotNull
{
    [System.Diagnostics.DebuggerNonUserCode]
    public struct NotNull<T> where T : class
    {
        private T _value;

        public T Value
        {
            get
            {
                if (_value == null)
                {
                    throw new NullReferenceException("Value is null");
                }

                return _value;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Cannot assign null value.");
                }

                _value = value;
            }
        }

        //public static explicit operator T(NotNull<T> notNullValue)
        public static implicit operator T(NotNull<T> notNullValue)
        {
            return notNullValue.Value;
        }

        public static implicit operator NotNull<T>(T value)
        {
            return new NotNull<T> { Value = value };
        }
    }
}
