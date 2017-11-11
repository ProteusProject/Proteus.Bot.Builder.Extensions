using System;

namespace Proteus.Bot.Builder.Extensions.Telemetry.Data
{
    /// <summary>
    /// Interface ICommonTelemetryData
    /// </summary>
    public interface ICommonTelemetryData
    {
        /// <summary>
        /// Gets or sets the type of the record.
        /// </summary>
        /// <value>The type of the record.</value>
        string RecordType { get; set; }
        
        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        DateTime Timestamp { get; set; }
        
        /// <summary>
        /// Gets or sets the correlation identifier.
        /// </summary>
        /// <value>The correlation identifier.</value>
        string CorrelationId { get; set; }
        
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
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        string UserId { get; set; }
        
        /// <summary>
        /// Gets or sets arbitrary JSON.
        /// </summary>
        /// <value>The JSON.</value>
        string Json { get; set; }
        
        /// <summary>
        /// Stringify the instance based on the provided Telemetry Context.
        /// </summary>
        /// <param name="context">The Telemetry Context.</param>
        /// <returns>System.String.</returns>
        string AsStringWith(ITelemetryContext context);
    }
}