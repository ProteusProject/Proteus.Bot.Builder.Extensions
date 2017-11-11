namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Class TypeDiscriminatingTelemetryWriterConfigurationBase.
    /// </summary>
    public abstract class TypeDiscriminatingTelemetryWriterConfigurationBase
    {
        /// <summary>
        /// Gets or sets the telemetry types to handle.
        /// </summary>
        /// <value>The telemetry types to handle.</value>
        public TelemetryTypes TelemetryTypesToHandle { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeDiscriminatingTelemetryWriterConfigurationBase"/> class.
        /// </summary>
        protected TypeDiscriminatingTelemetryWriterConfigurationBase()
        {
            TelemetryTypesToHandle = TelemetryTypes.All;
        }

        /// <summary>
        /// Identifies whether the specified telemetry type is configured to be handled.
        /// </summary>
        /// <param name="telemetryType">Type of the telemetry.</param>
        /// <returns><c>true</c> if telemetry type is handled, <c>false</c> otherwise.</returns>
        public bool Handles(TelemetryTypes telemetryType)
        {
            return TelemetryTypesToHandle.HasFlag(telemetryType);
        }
    }
}