using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using System.Text.Json.Serialization;

namespace SLAYER_1HitKill;

public class ConfigSpecials : BasePluginConfig
{
    [JsonPropertyName("PluginEnabled")] public bool PluginEnabled { get; set; } = true;
    [JsonPropertyName("Weapon")] public string Weapon { get; set; } = "weapon_";
    [JsonPropertyName("Damage")] public int Damage { get; set; } = 300;
    [JsonPropertyName("AdminFlagTo1HitKill")] public string AdminFlagTo1HitKill { get; set; } = "@css/root";
}
public class SLAYER_1HitKill : BasePlugin, IPluginConfig<ConfigSpecials>
{
    public override string ModuleName => "SLAYER_1HitKill";
    public override string ModuleVersion => "1.0";
    public override string ModuleAuthor => "SLAYER";
    public override string ModuleDescription => "Kill Player with 1 hit";

    public required ConfigSpecials Config {get; set;}
    public void OnConfigParsed(ConfigSpecials config)
    {
        Config = config;
    }
    

    public override void Load(bool hotReload)
    {
        RegisterEventHandler<EventPlayerHurt>((@event, info) => 
        {
            if(Config.PluginEnabled) // if Plugin is Enabled
            {
                if (!@event.Userid.IsValid)
                {
                    return HookResult.Continue;
                }
                CCSPlayerController attacker = @event.Attacker;

                if (!attacker.IsValid || @event.Userid.TeamNum == attacker.TeamNum && !(@event.DmgHealth > 0 || @event.DmgArmor > 0))
                    return HookResult.Continue;

                // Check if there is any flag requirement
                if(Config.AdminFlagTo1HitKill != "" && !AdminManager.PlayerHasPermissions(attacker, Config.AdminFlagTo1HitKill))
                    return HookResult.Continue;
                
                
                if(Config.Weapon == "" || Config.Weapon == " ") // All Weapons
                {
                    @event.DmgHealth = Config.Damage;
                    @event.Userid.PlayerPawn.Value.Health -= Config.Damage;
                }
                else
                {
                    var ActiveWeaponName = @event.Attacker.PlayerPawn.Value.WeaponServices!.ActiveWeapon.Value.DesignerName;
                    string[] weapons = Config.Weapon.Split(",");
                    foreach (string weapon in weapons)
                    {
                        if(ActiveWeaponName.Contains(weapon))
                        {
                            @event.DmgHealth = Config.Damage;
                            @event.Userid.PlayerPawn.Value.Health -= Config.Damage;
                            break;
                        }
                    }
                    
                }
            }
            return HookResult.Continue;
        });
    }
}
