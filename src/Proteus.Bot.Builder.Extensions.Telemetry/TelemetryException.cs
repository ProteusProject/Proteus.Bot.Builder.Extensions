using System;
using System.Runtime.Serialization;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Class TelemetryException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class TelemetryException: Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TelemetryException"/> class.
        /// </summary>
        public TelemetryException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelemetryException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public TelemetryException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelemetryException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public TelemetryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelemetryException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected TelemetryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
