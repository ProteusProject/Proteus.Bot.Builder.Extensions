namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Interface ITelemetryContext
    /// </summary>
    public interface ITelemetryContext
    {
        /// <summary>
        /// Gets or sets the channel identifier.
        /// </summary>
        /// <value>The channel identifier.</value>
        string ChannelId { get; set; }
        
        /// <summary>
        /// Gets or sets the conversation identifier.
        /// </summary>
        /// <value>The conversation identifier.</value>
        string ConversationId { get; set; }
        
        /// <summary>
        /// Gets or sets the activity identifier.
        /// </summary>
        /// <value>The activity identifier.</value>
        string ActivityId { get; set; }
        
        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        string Timestamp { get; }
        
        /// <summary>
        /// Gets the correlation identifier.
        /// </summary>
        /// <value>The correlation identifier.</value>
        string CorrelationId { get; }
        
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        string UserId { get; set; }
        
        /// <summary>
        /// Gets or sets the correlation identifier generator.
        /// </summary>
        /// <value>The correlation identifier generator.</value>
        ITelemetryContextCorrelationIdGenerator CorrelationIdGenerator { get; set; }
        
        /// <summary>
        /// Clones the instance applying a refreshed timestamp.
        /// </summary>
        /// <returns>ITelemetryContext.</returns>
        ITelemetryContext CloneWithRefreshedTimestamp();
    }
}