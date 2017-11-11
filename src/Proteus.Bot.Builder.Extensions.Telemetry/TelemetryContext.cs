using Microsoft.Bot.Builder.Internals.Fibers;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Class TelemetryContext.
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.ITelemetryContext" />
    public class TelemetryContext : ITelemetryContext
    {
        /// <summary>
        /// The date time provider
        /// </summary>
        private readonly IDateTimeProvider _dateTimeProvider;

        /// <summary>
        /// Gets or sets the channel identifier.
        /// </summary>
        /// <value>The channel identifier.</value>
        public string ChannelId { get; set; }
        
        /// <summary>
        /// Gets or sets the conversation identifier.
        /// </summary>
        /// <value>The conversation identifier.</value>
        public string ConversationId { get; set; }
        
        /// <summary>
        /// Gets or sets the activity identifier.
        /// </summary>
        /// <value>The activity identifier.</value>
        public string ActivityId { get; set; }
        
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId { get; set; }
        
        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        public string Timestamp { get; }
        
        /// <summary>
        /// Gets the correlation identifier.
        /// </summary>
        /// <value>The correlation identifier.</value>
        public string CorrelationId => CorrelationIdGenerator.GenerateCorrelationIdFrom(this);
        
        /// <summary>
        /// Gets or sets the correlation identifier generator.
        /// </summary>
        /// <value>The correlation identifier generator.</value>
        public ITelemetryContextCorrelationIdGenerator CorrelationIdGenerator { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="TelemetryContext"/> class.
        /// </summary>
        /// <param name="dateTimeProvider">The date time provider.</param>
        /// <param name="correlationIdGenerator">The correlation identifier generator.</param>
        public TelemetryContext(IDateTimeProvider dateTimeProvider, ITelemetryContextCorrelationIdGenerator correlationIdGenerator = null)
        {
            SetField.NotNull(out _dateTimeProvider, nameof(dateTimeProvider), dateTimeProvider);

            //set the Timestamp only once so that it will remain consistent for the life of the object
            Timestamp = dateTimeProvider.Now().ToString("O");

            //set a default generator for the correlation id
            CorrelationIdGenerator = correlationIdGenerator ?? new AllIdsAndTimestampTelemetryContextCorrelationIdGenerator();
        }

        /// <summary>
        /// Clones the instance applying a refreshed timestamp.
        /// </summary>
        /// <returns>ITelemetryContext.</returns>
        public ITelemetryContext CloneWithRefreshedTimestamp()
        {
            return new TelemetryContext(_dateTimeProvider)
            {
                ConversationId = this.ConversationId,
                ActivityId = this.ActivityId,
                ChannelId = this.ChannelId,
                UserId = this.UserId,
                CorrelationIdGenerator = this.CorrelationIdGenerator
            };
        }

    }
}