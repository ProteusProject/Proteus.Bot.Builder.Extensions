using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Proteus.Bot.Builder.Extensions.Telemetry.Data;
using Microsoft.Bot.Builder.Internals.Fibers;

namespace Proteus.Bot.Builder.Extensions.Telemetry.TextFileWriter
{
    /// <summary>
    /// Class TextFileTelemetryWriter.
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.StringOutputTelemetryWriterBase" />
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.ITelemetryWriter" />
    public class TextFileTelemetryWriter : StringOutputTelemetryWriterBase, ITelemetryWriter
    {
        /// <summary>
        /// The reader writer lock instance
        /// </summary>
        private static readonly ReaderWriterLockSlim ReaderWriterLockInstance = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly TextFileTelemetryWriterConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileTelemetryWriter"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="formatter">The formatter.</param>
        public TextFileTelemetryWriter(TextFileTelemetryWriterConfiguration configuration, ITelemetryOutputFormatter formatter)
        {
            SetField.NotNull(out _configuration, nameof(configuration), configuration);
            SetField.NotNull(out OutputFormatter, nameof(formatter), formatter);

            _configuration.ValidateSettings();

            Initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            if (_configuration.OverwriteFileIfExists && File.Exists(_configuration.Filename))
            {
                File.Delete(_configuration.Filename);
            }
        }

        /// <summary>
        /// write service result as an asynchronous operation.
        /// </summary>
        /// <param name="serviceResultTelemetryData">The service result telemetry data.</param>
        /// <returns>Task.</returns>
        public async Task WriteServiceResultAsync(IServiceResultTelemetryData serviceResultTelemetryData)
        {
            await DoWriteTelemetry(serviceResultTelemetryData, TelemetryTypes.ServiceResults,
                OutputFormatter.FormatServiceResult);
        }

        /// <summary>
        /// write intent as an asynchronous operation.
        /// </summary>
        /// <param name="intentTelemetryData">The intent telemetry data.</param>
        /// <returns>Task.</returns>
        public async Task WriteIntentAsync(IIntentTelemetryData intentTelemetryData)
        {
            await DoWriteTelemetry(intentTelemetryData, TelemetryTypes.Intents,
                OutputFormatter.FormatIntent);
        }

        /// <summary>
        /// write entity as an asynchronous operation.
        /// </summary>
        /// <param name="entityTelemetryData">The entity telemetry data.</param>
        /// <returns>Task.</returns>
        public async Task WriteEntityAsync(IEntityTelemetryData entityTelemetryData)
        {
            await DoWriteTelemetry(entityTelemetryData, TelemetryTypes.Entities,
                OutputFormatter.FormatEntity);
        }

        /// <summary>
        /// write request as an asynchronous operation.
        /// </summary>
        /// <param name="requestTelemetryData">The request telemetry data.</param>
        /// <returns>Task.</returns>
        public async Task WriteRequestAsync(IRequestTelemetryData requestTelemetryData)
        {
            await DoWriteTelemetry(requestTelemetryData, TelemetryTypes.Requests,
                OutputFormatter.FormatRequest);
        }

        /// <summary>
        /// write response as an asynchronous operation.
        /// </summary>
        /// <param name="responseTelemetryData">The response telemetry data.</param>
        /// <returns>Task.</returns>
        public async Task WriteResponseAsync(IResponseTelemetryData responseTelemetryData)
        {
            await DoWriteTelemetry(responseTelemetryData, TelemetryTypes.Responses,
                OutputFormatter.FormatResponse);
        }

        /// <summary>
        /// write counter as an asynchronous operation.
        /// </summary>
        /// <param name="counterTelemetryData">The counter telemetry data.</param>
        /// <returns>Task.</returns>
        public async Task WriteCounterAsync(ICounterTelemetryData counterTelemetryData)
        {
            await DoWriteTelemetry(counterTelemetryData, TelemetryTypes.Counters,
                OutputFormatter.FormatCounter);
        }

        /// <summary>
        /// write measure as an asynchronous operation.
        /// </summary>
        /// <param name="measureTelemetryData">The measure telemetry data.</param>
        /// <returns>Task.</returns>
        public async Task WriteMeasureAsync(IMeasureTelemetryData measureTelemetryData)
        {
            await DoWriteTelemetry(measureTelemetryData, TelemetryTypes.Measures,
                OutputFormatter.FormatMeasure);
        }

        /// <summary>
        /// write exception as an asynchronous operation.
        /// </summary>
        /// <param name="exceptionTelemetryData">The exception telemetry data.</param>
        /// <returns>Task.</returns>
        public async Task WriteExceptionAsync(IExceptionTelemetryData exceptionTelemetryData)
        {
            await DoWriteTelemetry(exceptionTelemetryData, TelemetryTypes.Exceptions,
                OutputFormatter.FormatException);
        }

        /// <summary>
        /// Write to file within the context of a threadsafe lock.
        /// </summary>
        /// <param name="message">The message.</param>
        private void ThreadsafeWriteToFile(string message)
        {
            try
            {
                ReaderWriterLockInstance.TryEnterWriteLock(int.MaxValue);
                File.AppendAllText(_configuration.Filename, message);
            }
            finally
            {
                ReaderWriterLockInstance.ExitWriteLock();
            }
        }

        /// <summary>
        /// write event as an asynchronous operation.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="metrics">The metrics.</param>
        /// <returns>Task.</returns>
        public override async Task WriteEventAsync(Dictionary<string, string> properties, Dictionary<string, double> metrics = null)
        {
            if (_configuration.Handles(TelemetryTypes.CustomEvents))
            {
                await Task.Run(() =>
                {
                    ThreadsafeWriteToFile(OutputFormatter.FormatEvent(properties, metrics));
                });
            }
        }

        /// <summary>
        /// Actually write the telemetry.
        /// </summary>
        /// <typeparam name="TTelemetryData">The type of the telemetry data.</typeparam>
        /// <param name="telemetryData">The telemetry data.</param>
        /// <param name="handleTypes">The types of telemetry to handle.</param>
        /// <param name="formatter">The output formatter.</param>
        /// <returns>Task.</returns>
        protected override async Task DoWriteTelemetry<TTelemetryData>(TTelemetryData telemetryData, TelemetryTypes handleTypes, Func<TTelemetryData, string> formatter)
        {
            if (_configuration.Handles(handleTypes))
            {
                await Task.Run(() =>
                {
                    ThreadsafeWriteToFile(formatter(telemetryData));
                });
            }
        }
    }
}