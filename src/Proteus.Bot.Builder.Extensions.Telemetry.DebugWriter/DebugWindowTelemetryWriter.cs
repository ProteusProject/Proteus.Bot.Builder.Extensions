using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Internals.Fibers;
using Proteus.Bot.Builder.Extensions.Telemetry.Data;

namespace Proteus.Bot.Builder.Extensions.Telemetry.DebugWriter
{
    /// <summary>
    /// Class DebugWindowTelemetryWriter.
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.StringOutputTelemetryWriterBase" />
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.ITelemetryWriter" />
    public class DebugWindowTelemetryWriter : StringOutputTelemetryWriterBase, ITelemetryWriter
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly DebugWindowTelemetryWriterConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugWindowTelemetryWriter"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="formatter">The formatter.</param>
        public DebugWindowTelemetryWriter(DebugWindowTelemetryWriterConfiguration configuration, ITelemetryOutputFormatter formatter)
        {
            SetField.NotNull(out _configuration, nameof(configuration), configuration);
            SetField.NotNull(out OutputFormatter, nameof(formatter), formatter);
        }

        /// <summary>
        /// Writes the counter.
        /// </summary>
        /// <param name="counterTelemetryData">The counter telemetry data.</param>
        /// <returns>Task.</returns>
        public Task WriteCounterAsync(ICounterTelemetryData counterTelemetryData)
        {
            DoWriteTelemetry(counterTelemetryData, TelemetryTypes.Counters, OutputFormatter.FormatCounter);
            return Task.Delay(0);
        }

        /// <summary>
        /// Writes the measure.
        /// </summary>
        /// <param name="measureTelemetryData">The measure telemetry data.</param>
        /// <returns>Task.</returns>
        public Task WriteMeasureAsync(IMeasureTelemetryData measureTelemetryData)
        {
            DoWriteTelemetry(measureTelemetryData, TelemetryTypes.Measures, OutputFormatter.FormatMeasure);
            return Task.Delay(0);
        }

        /// <summary>
        /// Writes the exception.
        /// </summary>
        /// <param name="exceptionTelemetryData">The exception telemetry data.</param>
        /// <returns>Task.</returns>
        public Task WriteExceptionAsync(IExceptionTelemetryData exceptionTelemetryData)
        {
            DoWriteTelemetry(exceptionTelemetryData, TelemetryTypes.Exceptions, OutputFormatter.FormatException);
            return Task.Delay(0);
        }

        /// <summary>
        /// Writes the service result.
        /// </summary>
        /// <param name="serviceResultTelemetryData">The service result telemetry data.</param>
        /// <returns>Task.</returns>
        public Task WriteServiceResultAsync(IServiceResultTelemetryData serviceResultTelemetryData)
        {
            DoWriteTelemetry(serviceResultTelemetryData, TelemetryTypes.ServiceResults, OutputFormatter.FormatServiceResult);
            return Task.Delay(0);
        }

        /// <summary>
        /// Writes the entity.
        /// </summary>
        /// <param name="entityTelemetryData">The entity telemetry data.</param>
        /// <returns>Task.</returns>
        public Task WriteEntityAsync(IEntityTelemetryData entityTelemetryData)
        {
            DoWriteTelemetry(entityTelemetryData, TelemetryTypes.Entities, OutputFormatter.FormatEntity);
            return Task.Delay(0);
        }

        /// <summary>
        /// Writes the intent.
        /// </summary>
        /// <param name="intentTelemetryData">The intent telemetry data.</param>
        /// <returns>Task.</returns>
        public Task WriteIntentAsync(IIntentTelemetryData intentTelemetryData)
        {
            DoWriteTelemetry(intentTelemetryData, TelemetryTypes.Intents, OutputFormatter.FormatIntent);
            return Task.Delay(0);
        }

        /// <summary>
        /// Writes the request.
        /// </summary>
        /// <param name="requestTelemetryData">The request telemetry data.</param>
        /// <returns>Task.</returns>
        public Task WriteRequestAsync(IRequestTelemetryData requestTelemetryData)
        {
            DoWriteTelemetry(requestTelemetryData, TelemetryTypes.Requests, OutputFormatter.FormatRequest);
            return Task.Delay(0);
        }

        /// <summary>
        /// Writes the response.
        /// </summary>
        /// <param name="responseTelemetryData">The response telemetry data.</param>
        /// <returns>Task.</returns>
        public Task WriteResponseAsync(IResponseTelemetryData responseTelemetryData)
        {
            DoWriteTelemetry(responseTelemetryData, TelemetryTypes.Responses, OutputFormatter.FormatResponse);
            return Task.Delay(0);
        }

        /// <summary>
        /// Writes the event.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="metrics">The metrics.</param>
        /// <returns>Task.</returns>
        public override Task WriteEventAsync(Dictionary<string, string> properties, Dictionary<string, double> metrics = null)
        {
            if (_configuration.Handles(TelemetryTypes.CustomEvents))
            {
                Debug.WriteLine(OutputFormatter.FormatEvent(properties, metrics));
            }

            return Task.Delay(0);
        }

        /// <summary>
        /// Actually write the telemetry.
        /// </summary>
        /// <typeparam name="TTelemetryData">The type of the telemetry data.</typeparam>
        /// <param name="telemetryData">The telemetry data.</param>
        /// <param name="handleTypes">The types of telemetry to handle.</param>
        /// <param name="formatter">The output formatter.</param>
        /// <returns>Task.</returns>
        protected override Task DoWriteTelemetry<TTelemetryData>(TTelemetryData telemetryData, TelemetryTypes handleTypes, Func<TTelemetryData, string> formatter)
        {
            if (_configuration.Handles(handleTypes))
            {
                Debug.WriteLine(formatter(telemetryData));
            }

            return Task.Delay(0);
        }
    }
}
