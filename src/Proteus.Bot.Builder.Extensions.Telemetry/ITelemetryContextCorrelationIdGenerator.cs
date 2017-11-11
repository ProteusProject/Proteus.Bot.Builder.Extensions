namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Interface ITelemetryContextCorrelationIdGenerator
    /// </summary>
    public interface ITelemetryContextCorrelationIdGenerator
    {
        /// <summary>
        /// Generates the correlation identifier from the provided telemetry context.
        /// </summary>
        /// <param name="context">The telemetry context.</param>
        /// <returns>System.String.</returns>
        string GenerateCorrelationIdFrom(ITelemetryContext context);
    }
}