using AdvancedDoctorPlus.Config;
using AdvancedDoctorPlus.EventHandler;
using Synapse.Api.Plugin;

namespace AdvancedDoctorPlus
{
    [PluginInformation(
        Author = "AlmightyLks",
        Description = "Adds some SCP-049 utilities",
        Name = "AdvancedDoctorPlus",
        SynapseMajor = 2,
        SynapseMinor = 0,
        SynapsePatch = 0,
        Version = "1.0.0"
        )]
    public class AdvancedDoctorPlus : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "AdvancedDoctorPlus")]
        public static PluginConfig Config;

        public override void Load()
        {
            SynapseController.Server.Logger.Info("<AdvancedDoctorPlus> Loaded");

            _ = new PluginEventHandler();
        }
    }
}
