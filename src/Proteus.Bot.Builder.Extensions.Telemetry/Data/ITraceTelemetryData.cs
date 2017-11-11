namespace Proteus.Bot.Builder.Extensions.Telemetry.Data
{
    /// <summary>
    /// Interface ITraceTelemetryData
    /// </summary>
    public interface ITraceTelemetryData
    {
        /// <summary>
        /// Gets or sets the name of the trace.
        /// </summary>
        /// <value>The name of the trace.</value>
        string TraceName { get; set; }
        
        /// <summary>
        /// Gets or sets the trace JSON.
        /// </summary>
        /// <value>The trace JSON.</value>
        string TraceJson { get; set; }
    }
}