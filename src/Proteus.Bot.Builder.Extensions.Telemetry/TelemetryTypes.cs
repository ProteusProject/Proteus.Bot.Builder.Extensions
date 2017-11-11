using System;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Enum TelemetryTypes
    /// </summary>
    [Flags]
    public enum TelemetryTypes
    {
        /// <summary>
        /// none
        /// </summary>
        None = 0,
        
        /// <summary>
        /// requests
        /// </summary>
        Requests = 1,
        
        /// <summary>
        /// intents
        /// </summary>
        Intents = 2,
        
        /// <summary>
        /// entities
        /// </summary>
        Entities = 4,
        
        /// <summary>
        /// responses
        /// </summary>
        Responses = 8,
        
        /// <summary>
        /// counters
        /// </summary>
        Counters = 16,
        
        /// <summary>
        /// measures
        /// </summary>
        Measures = 32,
        
        /// <summary>
        /// service results
        /// </summary>
        ServiceResults = 64,
        
        /// <summary>
        /// exceptions
        /// </summary>
        Exceptions = 128,
        
        /// <summary>
        /// custom events
        /// </summary>
        CustomEvents = 256,
        
        /// <summary>
        /// All
        /// </summary>
        All = ~0,
        
    }
}