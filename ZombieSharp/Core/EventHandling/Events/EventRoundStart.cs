namespace ZombieSharp.Core.EventHandling
{
    using CounterStrikeSharp.API;
    using CounterStrikeSharp.API.Core;

    /// <summary>
    /// Handle EventRoundStart to partial class.
    /// </summary>
    public partial class EventManager
    {
        private HookResult OnRoundStart(EventRoundStart @event, GameEventInfo info)
        {
            Server.PrintToChatAll(Translations.GetString("General round objective"));

            return HookResult.Continue;
        }
    }
}