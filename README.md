# AdvancedDoctorPlus

A simple SCP SL [Synapse](https://github.com/SynapseSL/Synapse/) Plugin to buff SCP-049.  
Credits for the stunning idea and EXILED-predecessor [DocRework](https://github.com/rby-blackruby/DocRework) made by [Blackruby](https://github.com/rby-blackruby/)! :)

---
### Configs

Default config:

```yaml
[AdvancedDoctorPlus]
{
scp049Healing:
# Can SCP-049 heal zombies?
  scp049Healing: false
  # How far can SCP-049 heal?
  scp049HealingRange: 10
  # How much can SCP-049 heal per interval?
  scp049HealingAmount: 10
  # How many seconds should be between each interval?
  scp049HealingInterval: 2.5
scp049ZombieStorm:
# Can SCP-049 spawn storms?
  scp049Storm: false
  # How many kills are required for a storm?
  scp049RequiredStreak: 10
  # How many zombies spawn max. per storm?
  scp049MaxZombieSpawn: 5
  # Text Hint for a ZombieStorm-summoned zombie
  scp049ZombieSpawnTextHint: ''
}
```
---
### Commands (Client Console)  

- `ZombieStorm` / `storm` / `zs`  
As SCP-049, you have access to the `Zombiestorm` command, which will give you the power to summon a configured amount of zombies from spectators.  
Though, first you have to have reached a certain configured killstreak.

---
### Configs

Default config:

```yaml
[AdvancedDoctorPlus]
{
scp049Healing:
# Can SCP-049 heal zombies?
  scp049Healing: false
  # How far can SCP-049 heal?
  scp049HealingRange: 10
  # How much can SCP-049 heal per interval?
  scp049HealingAmount: 10
  # How many seconds should be between each interval?
  scp049HealingInterval: 2.5
scp049ZombieStorm:
# Can SCP-049 spawn storms?
  scp049Storm: false
  # How many kills are required for a storm?
  scp049RequiredStreak: 10
  # How many zombies spawn max. per storm?
  scp049MaxZombieSpawn: 5
  # Text Hint for a ZombieStorm-summoned zombie
  scp049ZombieSpawnTextHint: ''
}
```
