using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Bot.Builder.Internals.Fibers;
using Proteus.Bot.Builder.Extensions.Telemetry.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Proteus.Bot.Builder.Extensions.Telemetry.Formatters
{
    /// <summary>
    /// Class MachineOptimizedOutputFormatter.
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.ITelemetryOutputFormatter" />
    public class MachineOptimizedOutputFormatter : ITelemetryOutputFormatter
    {
        /// <summary>
        /// The telemetry context
        /// </summary>
        private ITelemetryContext _context;


        /// <summary>
        /// Initializes a new instance of the <see cref="MachineOptimizedOutputFormatter"/> class.
        /// </summary>
        /// <param name="context">The telemetry context.</param>
        public MachineOptimizedOutputFormatter(ITelemetryContext context)
        {
            SetField.NotNull(out _context, nameof(context), context);
        }

        /// <summary>
        /// Sets the context.
        /// </summary>
        /// <param name="context">The telemetry context.</param>
        public void SetContext(ITelemetryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Formats the service result.
        /// </summary>
        /// <param name="serviceResultTelemetryData">The service result telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatServiceResult(IServiceResultTelemetryData serviceResultTelemetryData)
        {
            serviceResultTelemetryData.RecordType = "serviceResult";
            return serviceResultTelemetryData.AsStringWith(_context);
        }

        /// <summary>
        /// Formats the request.
        /// </summary>
        /// <param name="requestTelemetryData">The request telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatRequest(IRequestTelemetryData requestTelemetryData)
        {
            requestTelemetryData.RecordType = "request";
            return requestTelemetryData.AsStringWith(_context);
        }

        /// <summary>
        /// Formats the intent.
        /// </summary>
        /// <param name="intentTelemetryData">The intent telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatIntent(IIntentTelemetryData intentTelemetryData)
        {
            intentTelemetryData.RecordType = "intent";
            return intentTelemetryData.AsStringWith(_context);
        }

        /// <summary>
        /// Formats the entity.
        /// </summary>
        /// <param name="entityTelemetryData">The entity telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatEntity(IEntityTelemetryData entityTelemetryData)
        {
            entityTelemetryData.RecordType = "entity";
            return entityTelemetryData.AsStringWith(_context);
        }

        /// <summary>
        /// Formats the response.
        /// </summary>
        /// <param name="responseTelemetryData">The response telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatResponse(IResponseTelemetryData responseTelemetryData)
        {
            responseTelemetryData.RecordType = "response";
            return responseTelemetryData.AsStringWith(_context);
        }

        /// <summary>
        /// Formats the counter.
        /// </summary>
        /// <param name="counterTelemetryData">The counter telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatCounter(ICounterTelemetryData counterTelemetryData)
        {
            counterTelemetryData.RecordType = "counter";
            return counterTelemetryData.AsStringWith(_context);
        }

        /// <summary>
        /// Formats the measure.
        /// </summary>
        /// <param name="measureTelemetryData">The measure telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatMeasure(IMeasureTelemetryData measureTelemetryData)
        {
            measureTelemetryData.RecordType = "measure";
            return measureTelemetryData.AsStringWith(_context);
        }

        /// <summary>
        /// Formats the exception.
        /// </summary>
        /// <param name="exceptionTelemetryData">The exception telemetry data.</param>
        /// <returns>System.String.</returns>
        public string FormatException(IExceptionTelemetryData exceptionTelemetryData)
        {
            exceptionTelemetryData.RecordType = "exception";
            return exceptionTelemetryData.AsStringWith(_context);
        }

        /// <summary>
        /// Formats the event.
        /// </summary>
        /// <param name="metrics">The metrics.</param>
        /// <returns>System.String.</returns>
        public string FormatEvent(Dictionary<string, double> metrics)
        {
            return FormatEvent(new Dictionary<string, string>(), metrics);
        }

        /// <summary>
        /// Formats the event.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="metrics">The metrics.</param>
        /// <returns>System.String.</returns>
        public string FormatEvent(Dictionary<string, string> properties, Dictionary<string, double> metrics = null)
        {
            //make sure we have at least an empty dictionary so that remainder of code needn't branch
            if (null == metrics)
            {
                metrics = new Dictionary<string, double>();
            }

            //build up JSON representation of the arbitrary dictionaries passed in
            var jsonObject = new JObject(

                    new JProperty("properties",
                        new JArray(
                            from p in properties
                            select new JObject(new JProperty(p.Key, p.Value))
                        )
                    ),

                    new JProperty("metrics",
                        new JArray(
                            from m in metrics
                            select new JObject(new JProperty(m.Key, m.Value)))
                    )

            );

            var record = new TelemetryData { RecordType = "trace", TraceName = "trace", TraceJson = $"{jsonObject.ToString(Formatting.None)}" };
            return record.AsStringWith(_context);
        }
    }
}