using MEC;
using Synapse.Api;
using Synapse.Api.Events.SynapseEventArguments;
using System.Collections.Generic;
using AdvancedDoctorPlus.Helper;
using SynEvents = Synapse.Api.Events.EventHandler;
using System.Linq;

namespace AdvancedDoctorPlus.EventHandler
{
    internal class PluginEventHandler
    {
        public static HashSet<DoctorStats> Doctors { get; private set; }
        private List<CoroutineHandle> runningCoroutines;
        public PluginEventHandler()
        {
            SynEvents.Get.Player.PlayerSetClassEvent += Player_PlayerSetClassEvent;
            SynEvents.Get.Player.PlayerDeathEvent += Player_PlayerDeathEvent;

            runningCoroutines = new List<CoroutineHandle>();
            Doctors = new HashSet<DoctorStats>();

            runningCoroutines.Add(Timing.RunCoroutine(HealInRange()));
        }

        private void Player_PlayerDeathEvent(PlayerDeathEventArgs ev)
        {
            if (ev.Victim.RoleType == RoleType.Scp049)
                Doctors.RemoveWhere((_) => _.Player == ev.Victim);

            if (ev.Killer.RoleType == RoleType.Scp049)
                Doctors.First((_) => _.Player == ev.Killer).Streak++;
        }
        private void Player_PlayerSetClassEvent(PlayerSetClassEventArgs ev)
        {
            if (ev.Role == RoleType.Scp049)
                Doctors.Add(new DoctorStats() { Player = ev.Player, Streak = 0 });
        }
        private IEnumerator<float> HealInRange()
        {
            var docs = new DoctorStats[Doctors.Count];

            while (true)
            {
                if (AdvancedDoctorPlus.Config.Scp049Healing.Scp049Healing)
                {
                    try
                    {
                        docs = new DoctorStats[Doctors.Count];
                        Doctors.CopyTo(docs);

                        for (int i = 0; i < docs.Length; i++)
                        {
                            var players = SynapseController.Server.Players.ToArray().GetClosestPlayersInRange(docs[i].Player, AdvancedDoctorPlus.Config.Scp049Healing.Scp049HealingRange);

                            foreach (var player in players)
                            {
                                SynapseController.Server.Logger.Info(player.DisplayName);
                                if ((player.Health + AdvancedDoctorPlus.Config.Scp049Healing.Scp049HealingAmount) >= player.MaxHealth)
                                    player.Health = player.MaxHealth;
                                else
                                    player.Health += AdvancedDoctorPlus.Config.Scp049Healing.Scp049HealingAmount;
                            }

                        }
                    }
                    catch (System.Exception e)
                    {
                        SynapseController.Server.Logger.Info(e.StackTrace);
                    }
                }
                yield return Timing.WaitForSeconds(AdvancedDoctorPlus.Config.Scp049Healing.Scp049HealingInterval);
            }
        }
    }
}