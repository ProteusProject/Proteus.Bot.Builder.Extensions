using Proteus.Bot.Builder.Extensions.Telemetry;

namespace Proteus.Bot.Builder.Extensions.Azure.Telemetry.QueueStorageWriter
{
    /// <summary>
    /// Class DefaultQueueShardStrategy.
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.IShardStrategy" />
    public class DefaultQueueShardStrategy : IShardStrategy
    {
        /// <summary>
        /// Gets the current shard key.
        /// </summary>
        /// <value>The current shard key.</value>
        public string CurrentShardKey => "telemetry-queue";
    }
}