using System.Collections.Generic;

namespace Proteus.Bot.Builder.Extensions.Telemetry.Data
{
    /// <summary>
    /// Interface IIntentTelemetryData
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.ICommonTelemetryData" />
    public interface IIntentTelemetryData : ICommonTelemetryData
    {
        /// <summary>
        /// Gets or sets the name of the intent.
        /// </summary>
        /// <value>The name of the intent.</value>
        string IntentName { get; set; }
        
        /// <summary>
        /// Gets or sets the intent text.
        /// </summary>
        /// <value>The intent text.</value>
        string IntentText { get; set; }
        
        /// <summary>
        /// Gets or sets the intent confidence score.
        /// </summary>
        /// <value>The intent confidence score.</value>
        double? IntentConfidenceScore { get; set; }
        
        /// <summary>
        /// Gets a value indicating whether [intent has ambiguous entities].
        /// </summary>
        /// <value><c>true</c> if [intent has ambiguous entities]; otherwise, <c>false</c>.</value>
        bool IntentHasAmbiguousEntities { get; }
        
        /// <summary>
        /// Gets the intent entities.
        /// </summary>
        /// <value>The intent entities.</value>
        IList<IEntityTelemetryData> IntentEntities { get; }
    }
}