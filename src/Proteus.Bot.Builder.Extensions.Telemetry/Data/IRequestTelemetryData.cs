using System;

namespace Proteus.Bot.Builder.Extensions.Telemetry.Data
{
    /// <summary>
    /// Interface IRequestTelemetryData
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.ICommonTelemetryData" />
    public interface IRequestTelemetryData : ICommonTelemetryData
    {
        /// <summary>
        /// Gets or sets the request start date time.
        /// </summary>
        /// <value>The request start date time.</value>
        DateTime RequestStartDateTime { get; set; }
        
        /// <summary>
        /// Gets or sets the request end date time.
        /// </summary>
        /// <value>The request end date time.</value>
        DateTime RequestEndDateTime { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether [request is cache hit].
        /// </summary>
        /// <value><c>true</c> if [request is cache hit]; otherwise, <c>false</c>.</value>
        bool RequestIsCacheHit { get; set; }
        
        /// <summary>
        /// Gets or sets the request quality.
        /// </summary>
        /// <value>The request quality.</value>
        string RequestQuality { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether [request is ambiguous].
        /// </summary>
        /// <value><c>true</c> if [request is ambiguous]; otherwise, <c>false</c>.</value>
        bool RequestIsAmbiguous { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether [request is authenticated].
        /// </summary>
        /// <value><c>true</c> if [request is authenticated]; otherwise, <c>false</c>.</value>
        bool RequestIsAuthenticated { get; set; }
        
        /// <summary>
        /// Gets the request duration in milliseconds.
        /// </summary>
        /// <value>The request duration in milliseconds.</value>
        double RequestMilliseconds { get; }
    }
}