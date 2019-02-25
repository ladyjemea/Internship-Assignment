using System;
using System.Runtime.Serialization;

namespace InternshipAssignment
{
    [Serializable]
    internal class OldShipException : Exception
    {
        public OldShipException()
        {
        }

        public OldShipException(string message) : base(message)
        {
        }

        public OldShipException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OldShipException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}