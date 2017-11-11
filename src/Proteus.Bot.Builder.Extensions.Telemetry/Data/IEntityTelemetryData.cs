namespace Proteus.Bot.Builder.Extensions.Telemetry.Data
{
    /// <summary>
    /// Interface IEntityTelemetryData
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.ICommonTelemetryData" />
    public interface IEntityTelemetryData : ICommonTelemetryData
    {
        /// <summary>
        /// Gets or sets the type of the entity.
        /// </summary>
        /// <value>The type of the entity.</value>
        string EntityType { get; set; }
        
        /// <summary>
        /// Gets or sets the entity value.
        /// </summary>
        /// <value>The entity value.</value>
        string EntityValue { get; set; }
        
        /// <summary>
        /// Gets or sets the entity confidence score.
        /// </summary>
        /// <value>The entity confidence score.</value>
        double? EntityConfidenceScore { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether [entity is ambiguous].
        /// </summary>
        /// <value><c>true</c> if [entity is ambiguous]; otherwise, <c>false</c>.</value>
        bool EntityIsAmbiguous { get; set; }
    }
}