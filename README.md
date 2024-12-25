# Donation
<a href="https://www.buymeacoffee.com/slayer47" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;" ></a>

## Description:
This simple plugin allows players to kill others in 1 Hit. Ported this plugin [1 Hit Kill](https://forums.alliedmods.net/showthread.php?p=2569642)

## Installation:
**1.** Upload files to your server.

**2.** Edit **configs/plugins/SLAYER_1HitKill/SLAYER_1HitKill.json** if you want to change the settings.

**3.** Change the Map **or** Restart the Server **or** Load the Plugin.

## Features:
**1.** You can add multiple guns

**2.** You can set the damage of 1 hit


## Configuration:
```json
{
  "PluginEnabled": true,                 // Enable/Disable Plugin
  "Weapon": "awp,ssg08",                 // Make sure there are no spaces in this string | Empty String means all weapons
  "Damage": 300,                         // Damage given to player with 1 hit
  "AdminFlagTo1HitKill": "@css/root",    // Admin Flag require to 1 Hit kill | Empty means all players can 1 Hit kill
  "ConfigVersion": 1                     // Don't Change this
}
```


