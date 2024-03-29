﻿using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using System.Collections.Generic;
namespace KeyCardPermissions.Extensions
{
    /// <summary>
    /// A set of extensions used in this plugin.
    /// </summary>
    public static class PlayerExtensions
    {
        /// <summary>
        /// Checks whether the player has a keycard and updates the permissions
        /// </summary>
        /// <param name="player"> Player object</param>
        /// <param name="curr_config"> IConfig reference </param>
        /// <returns></returns>
        public static bool ModifyInventoryKeycardPermissions(this Player player, Config curr_config)
        {
            Dictionary<ItemType, KeycardPermissions[]> config_keys = KeyCardPermissions.Instance.Config.CardPermissions;
            if (config_keys == null || config_keys.Count == 0)
            {
                return false;
            }



            if (curr_config.debug_enabled)
            {
                Log.Info($"We are definitely modifying the player inventory card right..");
            }

            foreach (Item player_item in player.Items)
            {
                if (player_item is Keycard keycard)
                {

                    if (config_keys.TryGetValue(player_item.Type, out KeycardPermissions[] all_permissions))
                    {
                        ushort new_permission = 0;

                        for (int pos = 0; pos < all_permissions.Length; pos++)
                        {
                            new_permission |= (ushort)all_permissions[pos];
                        }

                        ((Keycard)player_item).Base.Permissions = ((Interactables.Interobjects.DoorUtils.KeycardPermissions)(new_permission));

                        if (curr_config.debug_enabled)
                        {
                            Log.Info($"Current keycard permissions { ((Keycard)player_item).Base.Permissions}");
                        }

                    }

                }

            }

            return true;
        }
    }
}
