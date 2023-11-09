namespace ZombieSharp
{
    using CounterStrikeSharp.API.Core;
    using global::ZombieSharp.Core.EventHandling;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class ZombieSharp : BasePlugin
    {
        private EventManager _eventManager;

        public ZombieSharp()
        {
            PluginHost = Host.CreateDefaultBuilder()
                .ConfigureServices(serviceCollection =>
                {
                    serviceCollection.AddSingleton<ZombieSharp>();
                    serviceCollection.AddSingleton<EventManager>();
                }).Build();

            _eventManager = PluginHost.Services.GetRequiredService<EventManager>();
        }

        public IHost PluginHost { get; init; }

        public override string ModuleName { get; } = "Zombie Sharp";

        public override string ModuleAuthor { get; } = "Oylsister, kurumi";

        public override string ModuleVersion { get; } = "1.0.0.0";

        public override void Load(bool hotReload)
        {
            _eventManager.RegisterEvents();
        }
    }
}