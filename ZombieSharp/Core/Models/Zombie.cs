namespace ZombieSharp.Core.Models
{
    using CounterStrikeSharp.API.Core;

    public class Zombie
    {
        public Zombie(CCSPlayerController player, ZombieStatus status)
        {
            Player = player;
            Status = status;
        }

        public CCSPlayerController Player { get; init; }

        public ZombieStatus Status { get; private set; }
    }
}