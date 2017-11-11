namespace Proteus.Bot.Builder.Extensions.Telemetry.Data
{
    /// <summary>
    /// Interface ICounterTelemetryData
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.ICommonTelemetryData" />
    public interface ICounterTelemetryData : ICommonTelemetryData
    {
        /// <summary>
        /// Gets or sets the counter category.
        /// </summary>
        /// <value>The counter category.</value>
        string CounterCategory { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the counter.
        /// </summary>
        /// <value>The name of the counter.</value>
        string CounterName { get; set; }
        
        /// <summary>
        /// Gets or sets the counter value.
        /// </summary>
        /// <value>The counter value.</value>
        int CounterValue { get; set; }
    }
}