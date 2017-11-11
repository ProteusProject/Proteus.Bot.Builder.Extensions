using System;
using System.Collections.Generic;
using Proteus.Bot.Builder.Extensions.Telemetry.Data;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Interface ITelemetryOutputFormatter
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.ISetTelemetryContext" />
    public interface ITelemetryOutputFormatter : ISetTelemetryContext
    {
        /// <summary>
        /// Formats the service result.
        /// </summary>
        /// <param name="serviceResultTelemetryData">The service result telemetry data.</param>
        /// <returns>System.String.</returns>
        string FormatServiceResult(IServiceResultTelemetryData serviceResultTelemetryData);
        
        /// <summary>
        /// Formats the request.
        /// </summary>
        /// <param name="requestTelemetryData">The request telemetry data.</param>
        /// <returns>System.String.</returns>
        string FormatRequest(IRequestTelemetryData requestTelemetryData);
        
        /// <summary>
        /// Formats the intent.
        /// </summary>
        /// <param name="intentTelemetryData">The intent telemetry data.</param>
        /// <returns>System.String.</returns>
        string FormatIntent(IIntentTelemetryData intentTelemetryData);
        
        /// <summary>
        /// Formats the entity.
        /// </summary>
        /// <param name="entityTelemetryData">The entity telemetry data.</param>
        /// <returns>System.String.</returns>
        string FormatEntity(IEntityTelemetryData entityTelemetryData);
        
        /// <summary>
        /// Formats the counter.
        /// </summary>
        /// <param name="counterTelemetryData">The counter telemetry data.</param>
        /// <returns>System.String.</returns>
        string FormatCounter(ICounterTelemetryData counterTelemetryData);
        
        /// <summary>
        /// Formats the measure.
        /// </summary>
        /// <param name="measureTelemetryData">The measure telemetry data.</param>
        /// <returns>System.String.</returns>
        string FormatMeasure(IMeasureTelemetryData measureTelemetryData);
        
        /// <summary>
        /// Formats the exception.
        /// </summary>
        /// <param name="exceptionTelemetryData">The exception telemetry data.</param>
        /// <returns>System.String.</returns>
        string FormatException(IExceptionTelemetryData exceptionTelemetryData);
        
        /// <summary>
        /// Formats the event.
        /// </summary>
        /// <param name="metrics">The metrics.</param>
        /// <returns>System.String.</returns>
        string FormatEvent(Dictionary<string, double> metrics);
        
        /// <summary>
        /// Formats the event.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="metrics">The metrics.</param>
        /// <returns>System.String.</returns>
        string FormatEvent(Dictionary<string, string> properties, Dictionary<string, double> metrics = null);
        
        /// <summary>
        /// Formats the response.
        /// </summary>
        /// <param name="responseTelemetryData">The response telemetry data.</param>
        /// <returns>System.String.</returns>
        string FormatResponse(IResponseTelemetryData responseTelemetryData);
    }
}
