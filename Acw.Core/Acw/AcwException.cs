using System;
using System.Runtime.Serialization;

namespace Acw.Core.Acw
{
    public class AcwException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="AcwException"/> object.
        /// </summary>
        public AcwException()
        {

        }

        /// <summary>
        /// Creates a new <see cref="AcwException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public AcwException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="AcwException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public AcwException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Constructor for serializing.
        /// </summary>
        public AcwException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
    }
}
