using Exiled.API.Features;
using Exiled.API.Features.Items;
using System;
using System.Collections.Generic;
namespace KeyCardPermissions.Extensions
{
    /// <summary>
    /// A set of extensions used in this plugin.
    /// </summary>
    public static class PlayerExtensions
    {
        /// <summary>
        /// Checks whether the player has a keycard of a specific permission.
        /// </summary>
        /// <param name="player"><see cref="Player"/> trying to interact.</param>
        /// <param name="permissions">The permission that's gonna be searched for.</param>
        /// <param name="requiresAllPermissions">Whether all permissions are required.</param>
        /// <returns>Whether the player has the required keycard.</returns>
        public static bool ModifyInventoryKeycardPermissions(this Player player, Config curr_config)
        {
            Dictionary<ItemType, string> config_keys = KeyCardPermissions.early_config.CardPermissions;
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

                    if (config_keys.TryGetValue(player_item.Type, out string all_permissions))
                    {

                        string[] config_perm_arr = all_permissions.Split(',');
                        ushort[] parsed_int_permissions = Array.ConvertAll(config_perm_arr, ushort.Parse);
                        ushort new_permission = 0;

                        for (int pos = 0; pos < parsed_int_permissions.Length; pos++)
                        {
                            new_permission |= parsed_int_permissions[pos];
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
