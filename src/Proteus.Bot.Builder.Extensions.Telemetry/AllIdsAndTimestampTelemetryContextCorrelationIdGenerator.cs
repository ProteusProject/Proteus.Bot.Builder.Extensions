namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Class AllIdsAndTimestampTelemetryContextCorrelationIdGenerator.
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.ITelemetryContextCorrelationIdGenerator" />
    public class AllIdsAndTimestampTelemetryContextCorrelationIdGenerator : ITelemetryContextCorrelationIdGenerator
    {
        /// <summary>
        /// Generates the correlation identifier from a given telemetry context.
        /// </summary>
        /// <param name="context">The telemetry context.</param>
        /// <returns>System.String.</returns>
        public string GenerateCorrelationIdFrom(ITelemetryContext context)
        {
            return $"{context.ChannelId}{context.ConversationId}{context.ActivityId}{context.UserId}{context.Timestamp}";
        }
    }
}