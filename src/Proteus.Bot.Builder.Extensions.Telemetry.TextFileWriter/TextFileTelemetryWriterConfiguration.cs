using System;
using System.IO;
using Microsoft.Bot.Builder.Internals.Fibers;

namespace Proteus.Bot.Builder.Extensions.Telemetry.TextFileWriter
{
    /// <summary>
    /// Class TextFileTelemetryWriterConfiguration.
    /// </summary>
    /// <seealso cref="Proteus.Bot.Builder.Extensions.Telemetry.TypeDiscriminatingTelemetryWriterConfigurationBase" />
    public class TextFileTelemetryWriterConfiguration : TypeDiscriminatingTelemetryWriterConfigurationBase
    {
        /// <summary>
        /// The file shard strategy
        /// </summary>
        private readonly IShardStrategy _fileShardStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileTelemetryWriterConfiguration"/> class.
        /// </summary>
        /// <param name="fileShardStrategy">The file shard strategy.</param>
        public TextFileTelemetryWriterConfiguration(IShardStrategy fileShardStrategy = null)
        {
            if (null == fileShardStrategy)
            {
                fileShardStrategy = new ShardPerDayStrategy();
            }

            SetField.NotNull(out _fileShardStrategy, nameof(fileShardStrategy), fileShardStrategy);
            Filename = BuildDefaultFilename();
        }

        /// <summary>
        /// Builds the default filename.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <exception cref="DirectoryNotFoundException">Unable to determine full path to executing assembly as default base path for log file.</exception>
        private string BuildDefaultFilename()
        {
            var executingDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            if (string.IsNullOrEmpty(executingDirectory))
            {
                throw new DirectoryNotFoundException("Unable to determine full path to executing assembly as default base path for log file.");
            }

            var fullyQualifiedFilePath = Path.Combine(executingDirectory.Replace("file:\\", string.Empty), $"{_fileShardStrategy.CurrentShardKey}.log");

            return fullyQualifiedFilePath;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [overwrite file if exists].
        /// </summary>
        /// <value><c>true</c> if [overwrite file if exists]; otherwise, <c>false</c>.</value>
        public bool OverwriteFileIfExists { get; set; }
        
        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        /// <value>The filename.</value>
        public string Filename { get; set; }

        /// <summary>
        /// Validates the settings.
        /// </summary>
        /// <exception cref="ArgumentException">Filename</exception>
        public void ValidateSettings()
        {
            if (string.IsNullOrEmpty(Filename))
            {
                throw new ArgumentException(nameof(Filename));
            }
        }
    }
}