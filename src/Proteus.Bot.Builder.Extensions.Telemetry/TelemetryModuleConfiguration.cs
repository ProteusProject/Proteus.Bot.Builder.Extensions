using System;
using System.Collections.Generic;
using System.Reflection;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Class TelemetryModuleConfiguration.
    /// </summary>
    public class TelemetryModuleConfiguration
    {
        /// <summary>
        /// Gets or sets the telemetry configurations.
        /// </summary>
        /// <value>The telemetry configurations.</value>
        public IList<object> TelemetryConfigurations { get; set; }
        
        /// <summary>
        /// Gets or sets the telemetry writer types.
        /// </summary>
        /// <value>The telemetry writer types.</value>
        public IList<Type> TelemetryWriterTypes { get; set; }
        
        /// <summary>
        /// Gets or sets the telemetry writer instances.
        /// </summary>
        /// <value>The telemetry writer instances.</value>
        public IList<ITelemetryWriter> TelemetryWriterInstances { get; set; }
        
        /// <summary>
        /// Gets or sets the telemetry writer assemblies.
        /// </summary>
        /// <value>The telemetry writer assemblies.</value>
        public IList<Assembly> TelemetryWriterAssemblies { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="TelemetryModuleConfiguration"/> class.
        /// </summary>
        public TelemetryModuleConfiguration()
        {
            TelemetryConfigurations = new List<object>();
            TelemetryWriterTypes = new List<Type>();
            TelemetryWriterInstances = new List<ITelemetryWriter>();
            TelemetryWriterAssemblies = new List<Assembly>();
        }
    }
}