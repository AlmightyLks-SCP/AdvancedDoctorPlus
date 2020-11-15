using Synapse.Config;

namespace AdvancedDoctorPlus.Config
{
    public class PluginConfig : AbstractConfigSection
    {
        public SCP049Healing Scp049Healing { get; set; } = new SCP049Healing();
        public SCP049ZombieStorm Scp049ZombieStorm { get; set; } = new SCP049ZombieStorm();
    }
}