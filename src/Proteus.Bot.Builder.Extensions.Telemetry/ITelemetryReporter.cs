using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proteus.Bot.Builder.Extensions.Telemetry.Data;
using Microsoft.Bot.Connector;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Interface ITelemetryReporter
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.ISetTelemetryContext" />
    public interface ITelemetryReporter : ISetTelemetryContext
    {
        /// <summary>
        /// Reports the intent.
        /// </summary>
        /// <param name="intentTelemetryData">The intent telemetry data.</param>
        /// <returns>Task.</returns>
        Task ReportIntentAsync(IIntentTelemetryData intentTelemetryData);
        
        /// <summary>
        /// Reports the request.
        /// </summary>
        /// <param name="requestTelemetryData">The request telemetry data.</param>
        /// <returns>Task.</returns>
        Task ReportRequestAsync(IRequestTelemetryData requestTelemetryData);
        
        /// <summary>
        /// Reports the response.
        /// </summary>
        /// <param name="responseTelemetryData">The response telemetry data.</param>
        /// <returns>Task.</returns>
        Task ReportResponseAsync(IResponseTelemetryData responseTelemetryData);
        
        /// <summary>
        /// Reports the dialog impression.
        /// </summary>
        /// <param name="dialog">The dialog.</param>
        /// <returns>Task.</returns>
        Task ReportDialogImpressionAsync(string dialog);
        
        /// <summary>
        /// Reports the service result.
        /// </summary>
        /// <param name="serviceResultTelemetryData">The service result telemetry data.</param>
        /// <returns>Task.</returns>
        Task ReportServiceResultAsync(IServiceResultTelemetryData serviceResultTelemetryData);
        
        /// <summary>
        /// Reports the exception.
        /// </summary>
        /// <param name="exceptionTelemetryData">The exception telemetry data.</param>
        /// <returns>Task.</returns>
        Task ReportExceptionAsync(IExceptionTelemetryData exceptionTelemetryData);
        
        /// <summary>
        /// Reports the event.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task.</returns>
        Task ReportEventAsync(string key, string value);
        
        /// <summary>
        /// Reports the event.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task.</returns>
        Task ReportEventAsync(string key, double value);
        
        /// <summary>
        /// Reports the event.
        /// </summary>
        /// <param name="metrics">The metrics.</param>
        /// <returns>Task.</returns>
        Task ReportEventAsync(Dictionary<string, double> metrics);
        
        /// <summary>
        /// Reports the event.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="metrics">The metrics.</param>
        /// <returns>Task.</returns>
        Task ReportEventAsync(Dictionary<string, string> properties, Dictionary<string, double> metrics = null);
        
        /// <summary>
        /// Sets the context from the provided activity and/or telemetry context.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <param name="context">The telemetry context.</param>
        /// <returns>Task.</returns>
        Task SetContextFrom(IActivity activity, ITelemetryContext context = null);
    }
}
