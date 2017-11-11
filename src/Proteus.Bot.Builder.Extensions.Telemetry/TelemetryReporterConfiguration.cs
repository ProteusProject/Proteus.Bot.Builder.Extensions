namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Class TelemetryReporterConfiguration.
    /// </summary>
    public class TelemetryReporterConfiguration
    {
        /// <summary>
        /// Gets or sets a value indicating whether [fail silently].
        /// </summary>
        /// <remarks>If <see cref="FailSilently"/> is true, exceptions in telemetry subsystem itself (including misconfigurations) will be caught and not rethrown.</remarks>
        /// <value><c>true</c> if [fail silently]; otherwise, <c>false</c>.</value>
        public bool FailSilently { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelemetryReporterConfiguration"/> class.
        /// </summary>
        public TelemetryReporterConfiguration()
        {
            //by default, ensure that the telemetry reporting swallows all exceptions
            // to ensure that mis-configured telemetry doesn't crash the system
            // (can be set to FALSE for e.g., debugging/troubleshooting any telemetry issues)
            FailSilently = true;
        }
    }
}