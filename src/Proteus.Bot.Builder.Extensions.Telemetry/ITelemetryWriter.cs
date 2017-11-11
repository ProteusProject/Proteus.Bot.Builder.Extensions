using System.Collections.Generic;
using System.Threading.Tasks;
using Proteus.Bot.Builder.Extensions.Telemetry.Data;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Interface ITelemetryWriter
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.ISetTelemetryContext" />
    public interface ITelemetryWriter : ISetTelemetryContext
    {
        /// <summary>
        /// Writes the intent.
        /// </summary>
        /// <param name="intentTelemetryData">The intent telemetry data.</param>
        /// <returns>Task.</returns>
        Task WriteIntentAsync(IIntentTelemetryData intentTelemetryData);
        
        /// <summary>
        /// Writes the entity.
        /// </summary>
        /// <param name="entityTelemetryData">The entity telemetry data.</param>
        /// <returns>Task.</returns>
        Task WriteEntityAsync(IEntityTelemetryData entityTelemetryData);
        
        /// <summary>
        /// Writes the counter.
        /// </summary>
        /// <param name="counterTelemetryData">The counter telemetry data.</param>
        /// <returns>Task.</returns>
        Task WriteCounterAsync(ICounterTelemetryData counterTelemetryData);
        
        /// <summary>
        /// Writes the measure.
        /// </summary>
        /// <param name="measureTelemetryData">The measure telemetry data.</param>
        /// <returns>Task.</returns>
        Task WriteMeasureAsync(IMeasureTelemetryData measureTelemetryData);
        
        /// <summary>
        /// Writes the response.
        /// </summary>
        /// <param name="responseTelemetryData">The response telemetry data.</param>
        /// <returns>Task.</returns>
        Task WriteResponseAsync(IResponseTelemetryData responseTelemetryData);
        
        /// <summary>
        /// Writes the service result.
        /// </summary>
        /// <param name="serviceResultTelemetryData">The service result telemetry data.</param>
        /// <returns>Task.</returns>
        Task WriteServiceResultAsync(IServiceResultTelemetryData serviceResultTelemetryData);
        
        /// <summary>
        /// Writes the exception.
        /// </summary>
        /// <param name="exceptionTelemetryData">The exception telemetry data.</param>
        /// <returns>Task.</returns>
        Task WriteExceptionAsync(IExceptionTelemetryData exceptionTelemetryData);
        
        /// <summary>
        /// Writes the event.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task.</returns>
        Task WriteEventAsync(string key, string value);
        
        /// <summary>
        /// Writes the event.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task.</returns>
        Task WriteEventAsync(string key, double value);
        
        /// <summary>
        /// Writes the event.
        /// </summary>
        /// <param name="metrics">The metrics.</param>
        /// <returns>Task.</returns>
        Task WriteEventAsync(Dictionary<string, double> metrics);
        
        /// <summary>
        /// Writes the event.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="metrics">The metrics.</param>
        /// <returns>Task.</returns>
        Task WriteEventAsync(Dictionary<string, string> properties, Dictionary<string, double> metrics = null);
        
        /// <summary>
        /// Writes the request.
        /// </summary>
        /// <param name="requestTelemetryData">The request telemetry data.</param>
        /// <returns>Task.</returns>
        Task WriteRequestAsync(IRequestTelemetryData requestTelemetryData);
    }
}