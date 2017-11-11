using System;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Class ShardPerDayStrategy.
    /// </summary>
    /// <remarks>Results in a new shard key returned each day (24 hour period).</remarks>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.IShardStrategy" />
    public class ShardPerDayStrategy : IShardStrategy
    {
        /// <summary>
        /// Gets the current shard key.
        /// </summary>
        /// <value>The current shard key.</value>
        public string CurrentShardKey => $"{DateTime.UtcNow:yyyy-MM-dd}";
    }
}