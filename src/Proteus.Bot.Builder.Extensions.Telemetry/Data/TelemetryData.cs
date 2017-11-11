using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proteus.Bot.Builder.Extensions.Telemetry.Data
{
    /// <summary>
    /// Class TelemetryData.
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.IRequestTelemetryData" />
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.IIntentTelemetryData" />
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.IEntityTelemetryData" />
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.IResponseTelemetryData" />
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.ICounterTelemetryData" />
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.IMeasureTelemetryData" />
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.IServiceResultTelemetryData" />
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.IExceptionTelemetryData" />
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.Data.ITraceTelemetryData" />
    public class TelemetryData :
        IRequestTelemetryData,
        IIntentTelemetryData,
        IEntityTelemetryData,
        IResponseTelemetryData,
        ICounterTelemetryData,
        IMeasureTelemetryData,
        IServiceResultTelemetryData,
        IExceptionTelemetryData,
        ITraceTelemetryData
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TelemetryData" /> class.
        /// </summary>
        public TelemetryData()
        {
            IntentEntities = new List<IEntityTelemetryData>();
        }

        #region ICommonTelemetryData

        /// <summary>
        /// Gets or sets the type of the record.
        /// </summary>
        /// <value>The type of the record.</value>
        public string RecordType { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the correlation identifier.
        /// </summary>
        /// <value>The correlation identifier.</value>
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or sets the channel identifier.
        /// </summary>
        /// <value>The channel identifier.</value>
        public string ChannelId { get; set; }

        /// <summary>
        /// Gets or sets the conversation identifier.
        /// </summary>
        /// <value>The conversation identifier.</value>
        public string ConversationId { get; set; }
        
        /// <summary>
        /// Gets or sets the activity identifier.
        /// </summary>
        /// <value>The activity identifier.</value>
        public string ActivityId { get; set; }
        
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId { get; set; }
        
        /// <summary>
        /// Gets or sets arbitrary JSON.
        /// </summary>
        /// <value>The JSON.</value>
        public string Json { get; set; }

        #endregion

        #region IRequestTelemetryData

        /// <summary>
        /// Gets or sets the request start date time.
        /// </summary>
        /// <value>The request start date time.</value>
        public DateTime RequestStartDateTime { get; set; }

        /// <summary>
        /// Gets or sets the request end date time.
        /// </summary>
        /// <value>The request end date time.</value>
        public DateTime RequestEndDateTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [request is cache hit].
        /// </summary>
        /// <value><c>true</c> if [request is cache hit]; otherwise, <c>false</c>.</value>
        public bool RequestIsCacheHit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [request is ambiguous].
        /// </summary>
        /// <value><c>true</c> if [request is ambiguous]; otherwise, <c>false</c>.</value>
        public bool RequestIsAmbiguous { get; set; }

        /// <summary>
        /// Gets or sets the request quality.
        /// </summary>
        /// <value>The request quality.</value>
        public string RequestQuality { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [request is authenticated].
        /// </summary>
        /// <value><c>true</c> if [request is authenticated]; otherwise, <c>false</c>.</value>
        public bool RequestIsAuthenticated { get; set; }

        /// <summary>
        /// Gets the request duration in milliseconds.
        /// </summary>
        /// <value>The request duration in milliseconds.</value>
        public double RequestMilliseconds => RequestEndDateTime.Subtract(RequestStartDateTime).TotalMilliseconds;

        #endregion

        #region IIntentTelemetryData

        /// <summary>
        /// Gets or sets the name of the intent.
        /// </summary>
        /// <value>The name of the intent.</value>
        public string IntentName { get; set; }

        /// <summary>
        /// Gets or sets the intent text.
        /// </summary>
        /// <value>The intent text.</value>
        public string IntentText { get; set; }

        /// <summary>
        /// Gets or sets the intent confidence score.
        /// </summary>
        /// <value>The intent confidence score.</value>
        public double? IntentConfidenceScore { get; set; }

        /// <summary>
        /// Gets a value indicating whether [intent has ambiguous entities].
        /// </summary>
        /// <value><c>true</c> if [intent has ambiguous entities]; otherwise, <c>false</c>.</value>
        public bool IntentHasAmbiguousEntities => IntentEntities.Any(entity => entity.EntityIsAmbiguous);

        /// <summary>
        /// Gets the intent entities.
        /// </summary>
        /// <value>The intent entities.</value>
        public IList<IEntityTelemetryData> IntentEntities { get; }

        #endregion

        #region IEntityTelemetryData

        /// <summary>
        /// Gets or sets the type of the entity.
        /// </summary>
        /// <value>The type of the entity.</value>
        public string EntityType { get; set; }

        /// <summary>
        /// Gets or sets the entity value.
        /// </summary>
        /// <value>The entity value.</value>
        public string EntityValue { get; set; }

        /// <summary>
        /// Gets or sets the entity confidence score.
        /// </summary>
        /// <value>The entity confidence score.</value>
        public double? EntityConfidenceScore { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [entity is ambiguous].
        /// </summary>
        /// <value><c>true</c> if [entity is ambiguous]; otherwise, <c>false</c>.</value>
        public bool EntityIsAmbiguous { get; set; }

        #endregion

        #region IResponseTelemetryData

        /// <summary>
        /// Gets or sets the response text.
        /// </summary>
        /// <value>The response text.</value>
        public string ResponseText { get; set; }

        /// <summary>
        /// Gets or sets the response image URL.
        /// </summary>
        /// <value>The response image URL.</value>
        public string ResponseImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the response JSON.
        /// </summary>
        /// <value>The response JSON.</value>
        public string ResponseJson { get; set; }

        /// <summary>
        /// Gets or sets the type of the response.
        /// </summary>
        /// <value>The type of the response.</value>
        public string ResponseType { get; set; }

        #endregion

        #region ICounterTelemetryData

        /// <summary>
        /// Gets or sets the counter category.
        /// </summary>
        /// <value>The counter category.</value>
        public string CounterCategory { get; set; }

        /// <summary>
        /// Gets or sets the name of the counter.
        /// </summary>
        /// <value>The name of the counter.</value>
        public string CounterName { get; set; }

        /// <summary>
        /// Gets or sets the counter value.
        /// </summary>
        /// <value>The counter value.</value>
        public int CounterValue { get; set; }

        #endregion

        #region IMeasureTelemetryData

        /// <summary>
        /// Gets or sets the measure category.
        /// </summary>
        /// <value>The measure category.</value>
        public string MeasureCategory { get; set; }

        /// <summary>
        /// Gets or sets the name of the measure.
        /// </summary>
        /// <value>The name of the measure.</value>
        public string MeasureName { get; set; }

        /// <summary>
        /// Gets or sets the measure value.
        /// </summary>
        /// <value>The measure value.</value>
        public double MeasureValue { get; set; }

        #endregion

        #region IServiceResultTelemetryData

        /// <summary>
        /// Gets or sets the name of the service result.
        /// </summary>
        /// <value>The name of the service result.</value>
        public string ServiceResultName { get; set; }

        /// <summary>
        /// Gets the service result in milliseconds.
        /// </summary>
        /// <value>The service result in milliseconds.</value>
        public double ServiceResultMilliseconds => ServiceResultEndDateTime.Subtract(ServiceResultStartDateTime).TotalMilliseconds;

        /// <summary>
        /// Gets or sets a value indicating whether [service result success].
        /// </summary>
        /// <value><c>true</c> if [service result success]; otherwise, <c>false</c>.</value>
        public bool ServiceResultSuccess { get; set; }

        /// <summary>
        /// Gets or sets the service result response.
        /// </summary>
        /// <value>The service result response.</value>
        public string ServiceResultResponse { get; set; }

        /// <summary>
        /// Gets or sets the service result start date time.
        /// </summary>
        /// <value>The service result start date time.</value>
        public DateTime ServiceResultStartDateTime { get; set; }

        /// <summary>
        /// Gets or sets the service result end date time.
        /// </summary>
        /// <value>The service result end date time.</value>
        public DateTime ServiceResultEndDateTime { get; set; }

        #endregion

        #region ITraceTelemetryData

        /// <summary>
        /// Gets or sets the name of the trace.
        /// </summary>
        /// <value>The name of the trace.</value>
        public string TraceName { get; set; }

        /// <summary>
        /// Gets or sets the trace JSON.
        /// </summary>
        /// <value>The trace JSON.</value>
        public string TraceJson { get; set; }

        #endregion

        #region IExceptionTelemetryData

        /// <summary>
        /// Gets or sets the component from which the exception originated.
        /// </summary>
        /// <value>The name of the component.</value>
        public string ExceptionComponent { get; set; }

        /// <summary>
        /// Gets or sets the context from which the exception originated.
        /// </summary>
        /// <value>The context.</value>
        public string ExceptionContext { get; set; }

        /// <summary>
        /// Gets the type of the exception (extracted from the exception in Ex).
        /// </summary>
        /// <value>The type of the exception.</value>
        public Type ExceptionType => Ex?.GetType();

        /// <summary>
        /// Gets the exception message (extracted from the exception in Ex).
        /// </summary>
        /// <value>The exception message.</value>
        public string ExceptionMessage => Ex?.Message;

        /// <summary>
        /// Gets the exception detail (extracted from the exception in Ex).
        /// </summary>
        /// <value>The exception detail.</value>
        public string ExceptionDetail => Ex?.ToString();

        /// <summary>
        /// Gets or sets the exception instance.
        /// </summary>
        /// <value>The exception</value>
        public Exception Ex { get; set; }

        #endregion


        #region ICommonTelemetryData

        /// <summary>
        /// Stringify the instance based on the provided Telemetry Context.
        /// </summary>
        /// <param name="context">The Telemetry Context.</param>
        /// <returns>System.String.</returns>
        public string AsStringWith(ITelemetryContext context)
        {
            var sb = new StringBuilder();

            sb.Append($"{RecordType}");
            sb.Append($"\t{context.Timestamp}");
            sb.Append($"\t{context.CorrelationId}");
            sb.Append($"\t{context.ChannelId}");
            sb.Append($"\t{context.ConversationId}");
            sb.Append($"\t{context.ActivityId}");
            sb.Append($"\t{context.UserId}");
            sb.Append($"\t{Json}");

            sb.Append($"\t{RequestIsCacheHit}");
            sb.Append($"\t{RequestMilliseconds}");
            sb.Append($"\t{RequestIsAmbiguous}");
            sb.Append($"\t{RequestQuality}");
            sb.Append($"\t{RequestIsAuthenticated}");

            sb.Append($"\t{IntentName}");
            sb.Append($"\t{IntentText}");
            sb.Append($"\t{IntentConfidenceScore}");

            sb.Append($"\t{EntityType}");
            sb.Append($"\t{EntityValue}");
            sb.Append($"\t{EntityConfidenceScore}");
            sb.Append($"\t{EntityIsAmbiguous}");

            sb.Append($"\t{ResponseText}");
            sb.Append($"\t{ResponseImageUrl}");
            sb.Append($"\t{ResponseJson}");
            sb.Append($"\t{ResponseType}");

            sb.Append($"\t{CounterCategory}");
            sb.Append($"\t{CounterName}");
            sb.Append($"\t{CounterValue}");

            sb.Append($"\t{MeasureCategory}");
            sb.Append($"\t{MeasureName}");
            sb.Append($"\t{MeasureValue}");

            sb.Append($"\t{ServiceResultName}");
            sb.Append($"\t{ServiceResultMilliseconds}");
            sb.Append($"\t{ServiceResultSuccess}");
            sb.Append($"\t{ServiceResultResponse}");

            sb.Append($"\t{TraceName}");
            sb.Append($"\t{TraceJson}");

            sb.Append($"\t{ExceptionComponent}");
            sb.Append($"\t{ExceptionContext}");
            sb.Append($"\t{ExceptionType}");
            sb.Append($"\t{ExceptionMessage}");
            sb.Append($"\t{ExceptionDetail}");

            sb.Append($"{Environment.NewLine}");

            return sb.ToString();
        }

        #endregion

        #region DataFactoryMethods

        /// <summary>
        /// Factory Method to build new intent data.
        /// </summary>
        /// <returns>IIntentTelemetryData.</returns>
        public static IIntentTelemetryData NewIntentData() { return new TelemetryData(); }

        /// <summary>
        /// Factory Method to build new entity data.
        /// </summary>
        /// <returns>IEntityTelemetryData.</returns>
        public static IEntityTelemetryData NewEntityData() { return new TelemetryData(); }

        /// <summary>
        /// Factory Method to build new request data.
        /// </summary>
        /// <returns>IRequestTelemetryData.</returns>
        public static IRequestTelemetryData NewRequestData() { return new TelemetryData(); }

        /// <summary>
        /// Factory Method to build new response data.
        /// </summary>
        /// <returns>IResponseTelemetryData.</returns>
        public static IResponseTelemetryData NewResponseData() { return new TelemetryData(); }

        /// <summary>
        /// Factory Method to build new counter data.
        /// </summary>
        /// <returns>ICounterTelemetryData.</returns>
        public static ICounterTelemetryData NewCounterData() { return new TelemetryData(); }

        /// <summary>
        /// Factory Method to build new measure data.
        /// </summary>
        /// <returns>IMeasureTelemetryData.</returns>
        public static IMeasureTelemetryData NewMeasureData() { return new TelemetryData(); }

        /// <summary>
        /// Factory Method to build new service result data.
        /// </summary>
        /// <returns>IServiceResultTelemetryData.</returns>
        public static IServiceResultTelemetryData NewServiceResultData() { return new TelemetryData(); }

        /// <summary>
        /// Factory Method to build new exception data.
        /// </summary>
        /// <returns>IExceptionTelemetryData.</returns>
        public static IExceptionTelemetryData NewExceptionData() { return new TelemetryData(); }

        /// <summary>
        /// Factory Method to build new trace data.
        /// </summary>
        /// <returns>ITraceTelemetryData.</returns>
        public static ITraceTelemetryData NewTraceData() { return new TelemetryData(); }

        #endregion

    }
}