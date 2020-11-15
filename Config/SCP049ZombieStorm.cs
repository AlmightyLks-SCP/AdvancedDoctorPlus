using System.ComponentModel;

namespace AdvancedDoctorPlus.Config
{
    public class SCP049ZombieStorm
    {
        [Description("Can SCP-049 spawn storms?")]
        public bool Scp049Storm { get; set; } = false;

        [Description("How many kills are required for a storm?")]
        public int Scp049RequiredStreak { get; set; } = 10;

        [Description("How many zombies spawn max. per storm?")]
        public int Scp049MaxZombieSpawn { get; set; } = 5;

        [Description("Text Hint for a ZombieStorm-summoned zombie")]
        public string Scp049ZombieSpawnTextHint { get; set; } = "";
    }
}