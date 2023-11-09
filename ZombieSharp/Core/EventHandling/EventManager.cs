namespace ZombieSharp.Core.EventHandling
{
    using System.Resources;
    using CounterStrikeSharp.API.Core;
    using global::ZombieSharp.Resources;

    /// <summary>
    /// This class registrates all events from partial classes.
    /// </summary>
    public partial class EventManager
    {
        private ZombieSharp _plugin;

        public EventManager(ZombieSharp plugin)
        {
            _plugin = plugin;

            Translations = new ResourceManager(typeof(Phrases))
                .GetResourceSet(new System.Globalization.CultureInfo("en-US"), true, true); // Hard code
        }

        public ResourceSet Translations { get; init; }

        /// <summary>
        /// This method registers all events and adds specific handlers from separated files.
        /// </summary>
        public void RegisterEvents()
        {
            _plugin.RegisterEventHandler<EventRoundStart>(OnRoundStart);
        }
    }
}