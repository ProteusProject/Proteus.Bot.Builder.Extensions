namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Interface IShardStrategy
    /// </summary>
    public interface IShardStrategy
    {
        /// <summary>
        /// Gets the current shard key.
        /// </summary>
        /// <value>The current shard key.</value>
        string CurrentShardKey { get; }
    }
}