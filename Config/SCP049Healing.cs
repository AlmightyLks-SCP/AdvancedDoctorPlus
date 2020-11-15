using System.ComponentModel;

namespace AdvancedDoctorPlus.Config
{
    public class SCP049Healing
    {
        [Description("Can SCP-049 heal zombies?")]
        public bool Scp049Healing { get; set; } = false;

        [Description("How far can SCP-049 heal?")]
        public float Scp049HealingRange { get; set; } = 10.0f;

        [Description("How much can SCP-049 heal per interval?")]
        public float Scp049HealingAmount { get; set; } = 10.0f;

        [Description("How many seconds should be between each interval?")]
        public float Scp049HealingInterval { get; set; } = 2.5f;
    }
}
