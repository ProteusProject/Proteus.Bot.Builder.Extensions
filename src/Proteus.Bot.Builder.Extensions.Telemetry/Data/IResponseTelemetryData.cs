using System;

namespace Proteus.Bot.Builder.Extensions.Telemetry.Data
{
    /// <summary>
    /// Interface IResponseTelemetryData
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.ICommonTelemetryData" />
    public interface IResponseTelemetryData : ICommonTelemetryData
    {
        /// <summary>
        /// Gets or sets the response text.
        /// </summary>
        /// <value>The response text.</value>
        string ResponseText { get; set; }
        
        /// <summary>
        /// Gets or sets the response image URL.
        /// </summary>
        /// <value>The response image URL.</value>
        string ResponseImageUrl { get; set; }
       
        /// <summary>
        /// Gets or sets the response JSON.
        /// </summary>
        /// <value>The response JSON.</value>
        string ResponseJson { get; set; }
        
        /// <summary>
        /// Gets or sets the type of the response.
        /// </summary>
        /// <value>The type of the response.</value>
        string ResponseType { get; set; }
    }
}