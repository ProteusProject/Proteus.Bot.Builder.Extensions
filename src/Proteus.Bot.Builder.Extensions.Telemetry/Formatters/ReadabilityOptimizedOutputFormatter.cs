using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Bot.Builder.Internals.Fibers;
using Proteus.Bot.Builder.Extensions.Telemetry.Data;

namespace Proteus.Bot.Builder.Extensions.Telemetry.Formatters
{
    /// <summary>
    /// Class ReadabilityOptimizedOutputFormatter.
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.ITelemetryOutputFormatter" />
    public class ReadabilityOptimizedOutputFormatter : ITelemetryOutputFormatter
    {
        /// <summary>
        /// The telemetry context
        /// </summary>
        private ITelemetryContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadabilityOptimizedOutputFormatter"/> class.
        /// </summary>
        /// <param name="context">The telemetry context.</param>
        public ReadabilityOptimizedOutputFormatter(ITelemetryContext context)
        {
            SetField.NotNull(out _context, nameof(context), context);
        }

        /// <summary>
        /// Gets the date time string.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetDateTimeString()
        {
            return DateTimeOffset.Now.ToString("O");
        }
        /// <summary>
        /// Formats the counter.
        /// </summary>
        /// <param name="counterTelemetryData">The counter telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatCounter(ICounterTelemetryData counterTelemetryData)
        {
            return $"{GetDateTimeString()}\t{GetTelemetryContextProperties()}\tCounter: [{counterTelemetryData.CounterCategory}/{counterTelemetryData.CounterName}] - Count: [{counterTelemetryData.CounterValue}]";
        }

        /// <summary>
        /// Formats the measure.
        /// </summary>
        /// <param name="measureTelemetryData">The measure telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatMeasure(IMeasureTelemetryData measureTelemetryData)
        {
            return $"{GetDateTimeString()}\t{GetTelemetryContextProperties()}\tMeasure: [{measureTelemetryData.MeasureCategory}/{measureTelemetryData.MeasureName}] - Value: [{measureTelemetryData.MeasureValue}]";
        }

        /// <summary>
        /// Formats the entity.
        /// </summary>
        /// <param name="entityTelemetryData">The entity telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatEntity(IEntityTelemetryData entityTelemetryData)
        {
            return $"{GetDateTimeString()}\t{GetTelemetryContextProperties()}\tEntity: [{entityTelemetryData.EntityType} ({entityTelemetryData.EntityConfidenceScore}) / Ambiguous: {entityTelemetryData.EntityIsAmbiguous}]-[{entityTelemetryData.EntityValue}]";
        }

        /// <summary>
        /// Formats the request.
        /// </summary>
        /// <param name="requestTelemetryData">The request telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatRequest(IRequestTelemetryData requestTelemetryData)
        {
            return $"{GetDateTimeString()}\t{GetTelemetryContextProperties()}\tRequest: [Ambiguous: {requestTelemetryData.RequestIsAmbiguous} / Quality: {requestTelemetryData.RequestQuality} / Duration (ms): {requestTelemetryData.RequestMilliseconds} / cache hit?: {requestTelemetryData.RequestIsCacheHit}]";
        }

        /// <summary>
        /// Formats the response.
        /// </summary>
        /// <param name="responseTelemetryData">The response telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatResponse(IResponseTelemetryData responseTelemetryData)
        {
            return $"{GetDateTimeString()}\t{GetTelemetryContextProperties()}\tResponse: [ image URL: {responseTelemetryData.ResponseImageUrl} / JSON: {responseTelemetryData.ResponseJson} / type: {responseTelemetryData.ResponseType}] - [{responseTelemetryData.ResponseText}] ";
        }

        /// <summary>
        /// Formats the exception.
        /// </summary>
        /// <param name="exceptionTelemetryData">The exception telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatException(IExceptionTelemetryData exceptionTelemetryData)
        {
            return $"{GetDateTimeString()}\t{GetTelemetryContextProperties()}\tException: [{exceptionTelemetryData.ExceptionComponent} with [{exceptionTelemetryData.ExceptionContext}]" + Environment.NewLine + $"\t{exceptionTelemetryData.Ex}";
        }

        /// <summary>
        /// Formats the intent.
        /// </summary>
        /// <param name="intentTelemetryData">The intent telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatIntent(IIntentTelemetryData intentTelemetryData)
        {
            return $"{GetDateTimeString()}\t{GetTelemetryContextProperties()}\tIntent: [{intentTelemetryData.IntentName} ({intentTelemetryData.IntentConfidenceScore}) / Ambiguous Entities: {intentTelemetryData.IntentHasAmbiguousEntities}] - [{intentTelemetryData.IntentText}]";
        }

        /// <summary>
        /// Formats the service result.
        /// </summary>
        /// <param name="serviceResultTelemetryData">The service result telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatServiceResult(IServiceResultTelemetryData serviceResultTelemetryData)
        {
            return $"{GetDateTimeString()}\t{GetTelemetryContextProperties()}\tServiceResult: [{serviceResultTelemetryData.ServiceResultName}] - result: [{serviceResultTelemetryData.ServiceResultResponse}] - duration(ms): [{serviceResultTelemetryData.ServiceResultEndDateTime.Subtract(serviceResultTelemetryData.ServiceResultStartDateTime).TotalMilliseconds}] - success: [{serviceResultTelemetryData.ServiceResultSuccess}]";
        }

        /// <summary>
        /// Sets the context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void SetContext(ITelemetryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the telemetry context properties.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetTelemetryContextProperties()
        {
            return $"correlationId: {_context.CorrelationId}\tchannelId: {_context.ChannelId}\tconversationId: {_context.ConversationId}\tactivityId: {_context.ActivityId}\tuserId: {_context.UserId}\ttimestamp: {_context.Timestamp}";
        }

        /// <summary>
        /// Formats the event.
        /// </summary>
        /// <param name="metrics">The metrics.</param>
        /// <returns>System.String.</returns>
        public string FormatEvent(Dictionary<string, double> metrics)
        {
            var message = new StringBuilder();

            foreach (var metric in metrics)
            {
                message.Append($"[{metric.Key},{metric.Value}]");
            }

            return $"{GetDateTimeString()}\t{GetTelemetryContextProperties()}\tEvent: [{message}]";
        }

        /// <summary>
        /// Formats the event.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="metrics">The metrics.</param>
        /// <returns>System.String.</returns>
        public string FormatEvent(Dictionary<string, string> properties, Dictionary<string, double> metrics = null)
        {
            var message = new StringBuilder();

            foreach (var property in properties)
            {
                message.Append($"[{property.Key},{property.Value}]");
            }

            if (null != metrics)
            {
                foreach (var metric in metrics)
                {
                    message.Append($"[{metric.Key},{metric.Value}]");
                }
            }

            return $"{GetDateTimeString()}\t{GetTelemetryContextProperties()}\tEvent: [{message}]";
        }
    }
}
