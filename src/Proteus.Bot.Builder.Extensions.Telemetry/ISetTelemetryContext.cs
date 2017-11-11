namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Interface ISetTelemetryContext
    /// </summary>
    public interface ISetTelemetryContext
    {
        /// <summary>
        /// Sets the telemetry context.
        /// </summary>
        /// <param name="context">The telemetry context.</param>
        void SetContext(ITelemetryContext context);
    }
}