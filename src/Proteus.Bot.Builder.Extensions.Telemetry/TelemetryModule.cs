using System.Linq;
using Autofac;
using Microsoft.Bot.Builder.Internals.Fibers;
using Proteus.Bot.Builder.Extensions.Telemetry.Formatters;
using Module = Autofac.Module;

namespace Proteus.Bot.Builder.Extensions.Telemetry
{
    /// <summary>
    /// Class TelemetryModule.
    /// </summary>
    /// <seealso cref="Module" />
    public class TelemetryModule : Module
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly TelemetryModuleConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelemetryModule"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public TelemetryModule(TelemetryModuleConfiguration configuration)
        {
            SetField.NotNull(out _configuration, nameof(configuration), configuration);
        }

        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>Note that the ContainerBuilder parameter is unique to this module.</remarks>
        protected override void Load(ContainerBuilder builder)
        {
            RegisterAllRequiredDefaultTypes(builder);
            RegisterAllTelemetryWriters(builder);

            RegisterTelemetryReporter(builder);

            base.Load(builder);
        }

        /// <summary>
        /// Registers all telemetry writers.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void RegisterAllTelemetryWriters(ContainerBuilder builder)
        {
            RegisterTelemetryWriterConfigurations(builder);
            RegisterTelemetryWriterTypes(builder);
            RegisterTelemetryWriterInstances(builder);
            RegisterTelemetryWritersFromAssemblies(builder);
        }

        /// <summary>
        /// Registers the telemetry writers from assemblies.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void RegisterTelemetryWritersFromAssemblies(ContainerBuilder builder)
        {
            foreach (var assembly in _configuration.TelemetryWriterAssemblies)
            {
                builder.RegisterAssemblyTypes(assembly)
                    .Where(t => t.GetInterfaces().Contains(typeof(ITelemetryWriter)))
                    .AsImplementedInterfaces()
                    .InstancePerRequest();
            }
        }

        /// <summary>
        /// Registers all required default types.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void RegisterAllRequiredDefaultTypes(ContainerBuilder builder)
        {
            RegisterDefaultDateTimeProvider(builder);
            RegisterDefaultTelemetryContext(builder);
            RegisterDefaultOutputFormatter(builder);
        }

        /// <summary>
        /// Registers the default output formatter.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void RegisterDefaultOutputFormatter(ContainerBuilder builder)
        {
            builder.RegisterType<MachineOptimizedOutputFormatter>().As<ITelemetryOutputFormatter>().InstancePerRequest();
        }

        /// <summary>
        /// Registers the telemetry reporter.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void RegisterTelemetryReporter(ContainerBuilder builder)
        {
            builder.RegisterType<TelemetryReporter>().AsImplementedInterfaces().InstancePerRequest();
        }

        /// <summary>
        /// Registers the default telemetry context.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void RegisterDefaultTelemetryContext(ContainerBuilder builder)
        {
            builder.RegisterType<TelemetryContext>().AsImplementedInterfaces().InstancePerRequest();
        }

        /// <summary>
        /// Registers the default date time provider.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void RegisterDefaultDateTimeProvider(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeProvider>().AsImplementedInterfaces().InstancePerRequest();
        }

        /// <summary>
        /// Registers the telemetry writer instances.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void RegisterTelemetryWriterInstances(ContainerBuilder builder)
        {
            foreach (var instance in _configuration.TelemetryWriterInstances)
            {
                builder.RegisterInstance(instance).AsImplementedInterfaces();
            }
        }

        /// <summary>
        /// Registers the telemetry writer types.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void RegisterTelemetryWriterTypes(ContainerBuilder builder)
        {
            foreach (var type in _configuration.TelemetryWriterTypes)
            {
                builder.RegisterType(type).AsImplementedInterfaces().InstancePerRequest();
            }
        }

        /// <summary>
        /// Registers the telemetry writer configurations.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void RegisterTelemetryWriterConfigurations(ContainerBuilder builder)
        {
            foreach (var configuration in _configuration.TelemetryConfigurations)
            {
                builder.RegisterInstance(configuration).AsSelf();
            }
        }
    }
}