using System;

namespace Proteus.Bot.Builder.Extensions.Telemetry.Data
{
    /// <summary>
    /// Interface IServiceResultTelemetryData
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.ICommonTelemetryData" />
    public interface IServiceResultTelemetryData : ICommonTelemetryData
    {
        /// <summary>
        /// Gets or sets the name of the service result.
        /// </summary>
        /// <value>The name of the service result.</value>
        string ServiceResultName { get; set; }
        
        /// <summary>
        /// Gets the service result in milliseconds.
        /// </summary>
        /// <value>The service result in milliseconds.</value>
        double ServiceResultMilliseconds { get; }
        
        /// <summary>
        /// Gets or sets a value indicating whether [service result success].
        /// </summary>
        /// <value><c>true</c> if [service result success]; otherwise, <c>false</c>.</value>
        bool ServiceResultSuccess { get; set; }
        
        /// <summary>
        /// Gets or sets the service result response.
        /// </summary>
        /// <value>The service result response.</value>
        string ServiceResultResponse { get; set; }
        
        /// <summary>
        /// Gets or sets the service result start date time.
        /// </summary>
        /// <value>The service result start date time.</value>
        DateTime ServiceResultStartDateTime { get; set; }
        
        /// <summary>
        /// Gets or sets the service result end date time.
        /// </summary>
        /// <value>The service result end date time.</value>
        DateTime ServiceResultEndDateTime { get; set; }
    }
}