using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proteus.Bot.Builder.Extensions.Telemetry.Data;
using Microsoft.Bot.Connector;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Class TelemetryReporter.
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.ITelemetryReporter" />
    public class TelemetryReporter : ITelemetryReporter
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public TelemetryReporterConfiguration Configuration { get; }
        
        /// <summary>
        /// Gets or sets the telemetry writers.
        /// </summary>
        /// <value>The telemetry writers.</value>
        public List<ITelemetryWriter> TelemetryWriters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelemetryReporter"/> class.
        /// </summary>
        /// <param name="writers">The writers.</param>
        /// <param name="configuration">The configuration.</param>
        public TelemetryReporter(IEnumerable<ITelemetryWriter> writers, TelemetryReporterConfiguration configuration = null)
        {
            Configuration = configuration ?? new TelemetryReporterConfiguration();
            TelemetryWriters = new List<ITelemetryWriter>(writers);
        }

        /// <summary>
        /// report intent as an asynchronous operation.
        /// </summary>
        /// <param name="intentTelemetryData">The intent telemetry data.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Proteus.Bot.Builder.Extensions.Telemetry.TelemetryException">Failed to write to TelemetryWriters.</exception>
        public async Task ReportIntentAsync(IIntentTelemetryData intentTelemetryData)
        {
            try
            {
                var tasks = new List<Task>();
                TelemetryWriters.ForEach(tw => { tasks.Add(tw.WriteIntentAsync(intentTelemetryData)); });
                TelemetryWriters.ForEach(tw => { tasks.AddRange(ProcessEntities(intentTelemetryData.IntentEntities)); });

                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                if (!Configuration.FailSilently)
                {
                    throw new TelemetryException("Failed to write to TelemetryWriters.", e);
                }
            }
        }

        /// <summary>
        /// report request as an asynchronous operation.
        /// </summary>
        /// <param name="requestTelemetryData">The request telemetry data.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Proteus.Bot.Builder.Extensions.Telemetry.TelemetryException">Failed to write to TelemetryWriters.</exception>
        public async Task ReportRequestAsync(IRequestTelemetryData requestTelemetryData)
        {
            try
            {
                var tasks = new List<Task>();
                TelemetryWriters.ForEach(tw => { tasks.Add(tw.WriteRequestAsync(requestTelemetryData)); });

                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                if (!Configuration.FailSilently)
                {
                    throw new TelemetryException("Failed to write to TelemetryWriters.", e);
                }
            }
        }

        /// <summary>
        /// report response as an asynchronous operation.
        /// </summary>
        /// <param name="responseTelemetryData">The response telemetry data.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Proteus.Bot.Builder.Extensions.Telemetry.TelemetryException">Failed to write to TelemetryWriters.</exception>
        public async Task ReportResponseAsync(IResponseTelemetryData responseTelemetryData)
        {
            try
            {
                var tasks = new List<Task>();
                TelemetryWriters.ForEach(tw => { tasks.Add(tw.WriteResponseAsync(responseTelemetryData)); });

                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                if (!Configuration.FailSilently)
                {
                    throw new TelemetryException("Failed to write to TelemetryWriters.", e);
                }
            }
        }


        /// <summary>
        /// report exception as an asynchronous operation.
        /// </summary>
        /// <param name="exceptionTelemetryData">The exception telemetry data.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Proteus.Bot.Builder.Extensions.Telemetry.TelemetryException">Failed to write to TelemetryWriters.</exception>
        public async Task ReportExceptionAsync(IExceptionTelemetryData exceptionTelemetryData)
        {
            try
            {
                var tasks = new List<Task>();
                TelemetryWriters.ForEach(tw => { tasks.Add(tw.WriteExceptionAsync(exceptionTelemetryData)); });

                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                if (!Configuration.FailSilently)
                {
                    throw new TelemetryException("Failed to write to TelemetryWriters.", e);
                }
            }
        }

        /// <summary>
        /// Sets the context from the provided activity and/or telemetry context.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <param name="context">The telemetry context.</param>
        /// <returns>Task.</returns>
        public Task SetContextFrom(IActivity activity, ITelemetryContext context = null)
        {
            if (null == context)
            {
                context = new TelemetryContext(new DateTimeProvider());
            }

            context.ActivityId = activity.Id;
            context.ChannelId = activity.ChannelId;
            context.ConversationId = activity.Conversation.Id;
            context.UserId = activity.Conversation.Name;

            //flow the context through to all the children objects which depend upon it
            SetContext(context);

            return Task.Delay(0);
        }

        /// <summary>
        /// Processes the entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IEnumerable&lt;Task&gt;.</returns>
        private IEnumerable<Task> ProcessEntities(IEnumerable<IEntityTelemetryData> entities)
        {
            var tasks = new List<Task>();
            foreach (var entity in entities)
            {
                TelemetryWriters.ForEach(tw => tasks.Add(tw.WriteEntityAsync(entity)));
            }
            return tasks;
        }

        /// <summary>
        /// report service result as an asynchronous operation.
        /// </summary>
        /// <param name="serviceResultTelemetryData">The service result telemetry data.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Proteus.Bot.Builder.Extensions.Telemetry.TelemetryException">Failed to write to TelemetryWriters.</exception>
        public async Task ReportServiceResultAsync(IServiceResultTelemetryData serviceResultTelemetryData)
        {
            try
            {
                var tasks = new List<Task>();
                TelemetryWriters.ForEach(tw => { tasks.Add(tw.WriteServiceResultAsync(serviceResultTelemetryData)); });

                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                if (!Configuration.FailSilently)
                {
                    throw new TelemetryException("Failed to write to TelemetryWriters.", e);
                }
            }
        }

        /// <summary>
        /// Adds the telemetry writer.
        /// </summary>
        /// <param name="telemetryWriter">The telemetry writer.</param>
        public void AddTelemetryWriter(ITelemetryWriter telemetryWriter)
        {
            TelemetryWriters.Add(telemetryWriter);
        }

        /// <summary>
        /// Removes the telemetry writer.
        /// </summary>
        /// <param name="telemetryWriter">The telemetry writer.</param>
        public void RemoveTelemetryWriter(ITelemetryWriter telemetryWriter)
        {
            TelemetryWriters.Remove(telemetryWriter);
        }

        /// <summary>
        /// Removes all telemetry writers.
        /// </summary>
        public void RemoveAllTelemetryWriters()
        {
            TelemetryWriters.Clear();
        }

        /// <summary>
        /// report dialog impression as an asynchronous operation.
        /// </summary>
        /// <param name="dialog">The dialog.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Proteus.Bot.Builder.Extensions.Telemetry.TelemetryException">Failed to write to TelemetryWriters.</exception>
        public async Task ReportDialogImpressionAsync(string dialog)
        {
            try
            {
                var tasks = new List<Task>();
                TelemetryWriters.ForEach(tw => { tasks.Add(tw.WriteCounterAsync(new TelemetryData { CounterName = dialog, CounterValue = 1 })); });

                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                if (!Configuration.FailSilently)
                {
                    throw new TelemetryException("Failed to write to TelemetryWriters.", e);
                }
            }
        }

        /// <summary>
        /// Sets the telemetry context.
        /// </summary>
        /// <param name="context">The telemetry context.</param>
        public void SetContext(ITelemetryContext context)
        {
            TelemetryWriters.ForEach(tw => tw.SetContext(context));
        }

        /// <summary>
        /// report event as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task.</returns>
        public async Task ReportEventAsync(string key, string value)
        {
            await ReportEventAsync(new Dictionary<string, string> { { key, value } });
        }

        /// <summary>
        /// report event as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Task.</returns>
        public async Task ReportEventAsync(string key, double value)
        {
            await ReportEventAsync(new Dictionary<string, double> { { key, value } });
        }

        /// <summary>
        /// report event as an asynchronous operation.
        /// </summary>
        /// <param name="metrics">The metrics.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Proteus.Bot.Builder.Extensions.Telemetry.TelemetryException">Failed to write to TelemetryWriters.</exception>
        public async Task ReportEventAsync(Dictionary<string, double> metrics)
        {
            try
            {
                var tasks = new List<Task>();
                TelemetryWriters.ForEach(tw => { tasks.Add(tw.WriteEventAsync(metrics)); });

                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                if (!Configuration.FailSilently)
                {
                    throw new TelemetryException("Failed to write to TelemetryWriters.", e);
                }
            }
        }

        /// <summary>
        /// report event as an asynchronous operation.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="metrics">The metrics.</param>
        /// <returns>Task.</returns>
        /// <exception cref="Proteus.Bot.Builder.Extensions.Telemetry.TelemetryException">Failed to write to TelemetryWriters.</exception>
        public async Task ReportEventAsync(Dictionary<string, string> properties, Dictionary<string, double> metrics = null)
        {
            try
            {
                var tasks = new List<Task>();
                TelemetryWriters.ForEach(tw => { tasks.Add(tw.WriteEventAsync(properties, metrics)); });

                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                if (!Configuration.FailSilently)
                {
                    throw new TelemetryException("Failed to write to TelemetryWriters.", e);
                }
            }
        }
    }
}