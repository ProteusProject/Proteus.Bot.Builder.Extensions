using System;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Class ShardPerMonthStrategy.
    /// </summary>
    /// <remarks>Results in a new shard key returned each calendar month (12 per calendar year).</remarks>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.IShardStrategy" />
    public class ShardPerMonthStrategy : IShardStrategy
    {
        /// <summary>
        /// Gets the current shard key.
        /// </summary>
        /// <value>The current shard key.</value>
        public string CurrentShardKey => $"{DateTime.UtcNow:yyyy-MM}";
    }
}