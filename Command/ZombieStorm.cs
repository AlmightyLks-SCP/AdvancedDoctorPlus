using AdvancedDoctorPlus.EventHandler;
using MEC;
using Synapse.Api;
using Synapse.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDoctorPlus.Command
{
    [CommandInformation(
        Name = "ZombieStorm",
        Aliases = new string[] { "storm", "zs" },
        Description = "A Command to spawn a zombie wave",
        Platforms = new Platform[] { Platform.ClientConsole },
        Usage = ".zombiestorm"
        )]
    class ZombieStorm : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            if (!AdvancedDoctorPlus.Config.Scp049ZombieStorm.Scp049Storm)
            {
                result.State = CommandResultState.Error;
                result.Message = "Command deactivtated.";
                return result;
            }

            if (context.Player.RoleType != RoleType.Scp049)
            {
                result.State = CommandResultState.Error;
                result.Message = "Only SCP-049 may use this command.";
                return result;
            }

            var stats = PluginEventHandler.Doctors.First((_) => _.Player == context.Player);

            if (!(stats.Streak >= AdvancedDoctorPlus.Config.Scp049ZombieStorm.Scp049RequiredStreak))
            {
                result.State = CommandResultState.Error;
                result.Message = $"Not enough kills. {stats.Streak}/{AdvancedDoctorPlus.Config.Scp049ZombieStorm.Scp049RequiredStreak}.";
            }
            else if (SynapseController.Server.Players.Where((_) => _.RoleType == RoleType.Scp049).Count() == 0)
            {
                result.State = CommandResultState.Error;
                result.Message = $"Not enough kills. {stats.Streak}/{AdvancedDoctorPlus.Config.Scp049ZombieStorm.Scp049RequiredStreak}.";
            }
            else
            {
                SpawnZombieStorm(context.Player);

                stats.Streak -= AdvancedDoctorPlus.Config.Scp049ZombieStorm.Scp049RequiredStreak;

                result.State = CommandResultState.Error;
                result.Message = $"Done.";
            }

            return result;
        }
        private void SpawnZombieStorm(Player daddy)
        {
            var specs = SynapseController.Server.Players.Where((_) => _.RoleType == RoleType.Spectator).ToList();
            var amount = specs.Count >= AdvancedDoctorPlus.Config.Scp049ZombieStorm.Scp049MaxZombieSpawn ? AdvancedDoctorPlus.Config.Scp049ZombieStorm.Scp049MaxZombieSpawn : specs.Count;

            for (int i = 0; i < amount; i++)
            {
                Player player = specs[i];
                player.ChangeRoleAtPosition(RoleType.Scp0492);

                if (!string.IsNullOrEmpty(AdvancedDoctorPlus.Config.Scp049ZombieStorm.Scp049ZombieSpawnTextHint))
                    player.GiveTextHint(AdvancedDoctorPlus.Config.Scp049ZombieStorm.Scp049ZombieSpawnTextHint);

                Timing.CallDelayed(0.01f, () =>
                {
                    player.Position = daddy.Position;
                });
            }
        }
    }
}
