using Proteus.Bot.Builder.Extensions.Telemetry;

namespace Proteus.Bot.Builder.Extensions.Azure.Telemetry.BlobStorageWriter
{
    /// <summary>
    /// Class DefaultContainerShardStrategy.
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.IShardStrategy" />
    public class DefaultContainerShardStrategy : IShardStrategy
    {
        /// <summary>
        /// Gets the current shard key.
        /// </summary>
        /// <value>The current shard key.</value>
        public string CurrentShardKey => "telemetry-container";
    }
}