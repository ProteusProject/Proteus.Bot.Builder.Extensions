namespace Proteus.Bot.Builder.Extensions.Telemetry.Data
{
    /// <summary>
    /// Interface IMeasureTelemetryData
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.ICommonTelemetryData" />
    public interface IMeasureTelemetryData : ICommonTelemetryData
    {
        /// <summary>
        /// Gets or sets the measure category.
        /// </summary>
        /// <value>The measure category.</value>
        string MeasureCategory { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the measure.
        /// </summary>
        /// <value>The name of the measure.</value>
        string MeasureName { get; set; }
        
        /// <summary>
        /// Gets or sets the measure value.
        /// </summary>
        /// <value>The measure value.</value>
        double MeasureValue { get; set; }
    }
}