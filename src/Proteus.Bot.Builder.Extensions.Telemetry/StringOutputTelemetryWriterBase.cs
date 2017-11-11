using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Class StringOutputTelemetryWriterBase.
    /// </summary>
    public abstract class StringOutputTelemetryWriterBase
    {
        /// <summary>
        /// The output formatter
        /// </summary>
        protected ITelemetryOutputFormatter OutputFormatter;
        
        /// <summary>
        /// Actually write the telemetry.
        /// </summary>
        /// <typeparam name="TTelemetryData">The type of the telemetry data.</typeparam>
        /// <param name="telemetryData">The telemetry data.</param>
        /// <param name="handleTypes">The types of telemetry to handle.</param>
        /// <param name="formatter">The output formatter.</param>
        /// <returns>Task.</returns>
        protected abstract Task DoWriteTelemetry<TTelemetryData>(TTelemetryData telemetryData, TelemetryTypes handleTypes, Func<TTelemetryData, string> formatter);

        /// <summary>
        /// write event as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task.</returns>
        public async Task WriteEventAsync(string key, string value)
        {
            await WriteEventAsync(new Dictionary<string, string> { { key, value } });
        }

        /// <summary>
        /// write event as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task.</returns>
        public async Task WriteEventAsync(string key, double value)
        {
            await WriteEventAsync(new Dictionary<string, double> { { key, value } });
        }

        /// <summary>
        /// write event as an asynchronous operation.
        /// </summary>
        /// <param name="metrics">The metrics.</param>
        /// <returns>Task.</returns>
        public async Task WriteEventAsync(Dictionary<string, double> metrics)
        {
            await WriteEventAsync(new Dictionary<string, string>(), metrics);
        }

        /// <summary>
        /// Writes the event.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="metrics">The metrics.</param>
        /// <returns>Task.</returns>
        public abstract Task WriteEventAsync(Dictionary<string, string> properties, Dictionary<string, double> metrics = null);

        /// <summary>
        /// Sets the telemetry context.
        /// </summary>
        /// <param name="context">The telemetry context.</param>
        public virtual void SetContext(ITelemetryContext context)
        {
            OutputFormatter.SetContext(context);
        }
    }
}