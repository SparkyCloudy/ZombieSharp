using System.Collections;

namespace ZombieSharp
{
	public class CommandModule
	{
		private readonly ZombieSharp _core;
		private ZombiePlayer _player;
		private ZTeleModule _zTeleModule;
		
		public CommandModule(ZombieSharp plugin)
		{
			_core = plugin;
		}

		public void Initialize()
		{
			_core.AddCommand("css_zs_infect", "Infect Client Command", InfectClientCommand);
			_core.AddCommand("css_zs_human", "Humanize Client Command", HumanizeClientCommand);
			_core.AddCommand("css_zs_ztele", "Teleport Client to spawn Command", ZTeleClientCommand);
		}

		private void InfectClientCommand(CCSPlayerController client, CommandInfo info)
		{
			if(info.ArgCount <= 1)
			{
				info.ReplyToCommand("[Z:Sharp] Usage: css_zs_infect [<playername>].");
				return;
			}

			var targets = _core.FindTargetByName(info.ArgString);

			if(targets.Count == 0)
			{
				info.ReplyToCommand("[Z:Sharp] Couldn't find any client contain with that name.");
				return;
			}

			foreach (CCSPlayerController target in targets)
			{
				if(!target.IsValid)
					continue;

				if(!target.PawnIsAlive)
				{
					info.ReplyToCommand($"[Z:Sharp] target {target.PlayerName} is not alive.");
					continue;
				}

				if(_player.IsClientInfect(target))
				{
					info.ReplyToCommand($"[Z:Sharp] target {target.PlayerName} is already zombie.");
					continue;
				}

				_core.InfectClient(target, null, false, true);
				info.ReplyToCommand($"[Z:Sharp] Successfully infected {target.PlayerName}");
			}
		}

		private void HumanizeClientCommand(CCSPlayerController client, CommandInfo info)
		{
			if(info.ArgCount <= 1)
			{
				info.ReplyToCommand("[Z:Sharp] Usage: css_zs_human <playername>.");
				return;
			}

			var targets = _core.FindTargetByName(info.ArgString);

			if(targets.Count == 0)
			{
				info.ReplyToCommand("[Z:Sharp] Couldn't find any client contain with that name.");
				return;
			}

			foreach (CCSPlayerController target in targets)
			{
				if(!target.IsValid)
					continue;

				if(!target.PawnIsAlive)
				{
					info.ReplyToCommand($"[Z:Sharp] target {target.PlayerName} is not alive.");
					continue;
				}

				if(_player.IsClientHuman(target))
				{
					info.ReplyToCommand($"[Z:Sharp] target {target.PlayerName} is already human.");
					continue;
				}

				_core.HumanizeClient(target, true);
				info.ReplyToCommand($"[Z:Sharp] Successfully humanized {target.PlayerName}");
			}
		}

		private void ZTeleClientCommand(CCSPlayerController client, CommandInfo info)
		{
			if (!client.IsValid)
				return;
			
			if (!client.PawnIsAlive)
			{
				info.ReplyToCommand("[Z:Sharp] This feature requires that you are alive.");
				return;
			}
			
			_zTeleModule.ZTele_TeleportClientToSpawn(client);
			info.ReplyToCommand("Teleported back to spawn.");
		}
	}
}