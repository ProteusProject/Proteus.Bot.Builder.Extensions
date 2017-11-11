using System;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Interface IDateTimeProvider
    /// </summary>
    public interface IDateTimeProvider
    {
        /// <summary>
        /// Curernt DateTime.
        /// </summary>
        /// <returns>DateTimeOffset.</returns>
        DateTimeOffset Now();
    }
}