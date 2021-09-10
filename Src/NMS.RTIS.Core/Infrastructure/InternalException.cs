using System;

namespace NMS.RTIS.Core.Infrastructure
{
    public class InternalException : Exception
    {
        public InternalException(string msg) : base(msg)
        {

        }
    }
}
