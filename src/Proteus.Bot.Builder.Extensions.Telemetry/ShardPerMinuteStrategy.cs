using System;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Class ShardPerMinuteStrategy.
    /// </summary>
    /// <remarks>Results in a new shard key returned each minute (60 second period).</remarks>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.IShardStrategy" />
    public class ShardPerMinuteStrategy : IShardStrategy
    {
        /// <summary>
        /// Gets the current shard key.
        /// </summary>
        /// <value>The current shard key.</value>
        public string CurrentShardKey => $"{DateTime.UtcNow:yyyy-MM-dd-HH-mm}";
    }
}