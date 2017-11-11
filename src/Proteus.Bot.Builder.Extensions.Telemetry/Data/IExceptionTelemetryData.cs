using System;

namespace Proteus.Bot.Builder.Extensions.Telemetry.Data
{
    /// <summary>
    /// Interface IExceptionTelemetryData
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.ICommonTelemetryData" />
    public interface IExceptionTelemetryData : ICommonTelemetryData
    {
        /// <summary>
        /// Gets or sets the component from which the exception originated.
        /// </summary>
        /// <value>The name of the component.</value>
        string ExceptionComponent { get; set; }
        
        /// <summary>
        /// Gets or sets the context from which the exception originated.
        /// </summary>
        /// <value>The context.</value>
        string ExceptionContext { get; set; }
        
        /// <summary>
        /// Gets or sets the exception instance.
        /// </summary>
        /// <value>The exception</value>
        Exception Ex { get; set; }
        
        /// <summary>
        /// Gets the type of the exception (extracted from the exception in Ex).
        /// </summary>
        /// <value>The type of the exception.</value>
        Type ExceptionType { get; }
        
        /// <summary>
        /// Gets the exception message (extracted from the exception in Ex).
        /// </summary>
        /// <value>The exception message.</value>
        string ExceptionMessage { get; }
        
        /// <summary>
        /// Gets the exception detail (extracted from the exception in Ex).
        /// </summary>
        /// <value>The exception detail.</value>
        string ExceptionDetail { get; }
    }
}