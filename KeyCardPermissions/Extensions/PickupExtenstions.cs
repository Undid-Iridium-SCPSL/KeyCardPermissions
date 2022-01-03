using Exiled.API.Features;
using Exiled.API.Features.Items;
using System;
using System.Collections.Generic;

namespace KeyCardPermissions.Extensions
{
    public static class PickupExtenstions
    {
        /// <summary>
        /// Modifys keycard permission upon pickup
        /// </summary>
        /// <param name="player"><see cref="Player"/> trying to interact.</param>
        /// <param name="permissions">The permission that's gonna be searched for.</param>
        /// <param name="requiresAllPermissions">Whether all permissions are required.</param>
        /// <returns>Whether the player has the required keycard.</returns>
        public static bool ModifyKeycardPermissions(this Item keycard, Config curr_config)
        {



            Dictionary<ItemType, string> config_keys = KeyCardPermissions.early_config.CardPermissions;
            if (config_keys == null || config_keys.Count == 0)
            {
                return false;
            }

            if (curr_config.debug_enabled)
            {
                Log.Info($"We are definitely modifying the card right..");
            }


            if (config_keys.TryGetValue(keycard.Type, out string keycard_perms))
            {
                string[] config_perm_arr = keycard_perms.Split(',');
                ushort[] parsed_int_permissions = Array.ConvertAll(config_perm_arr, ushort.Parse);
                ushort new_permission = 0;

                for (int pos = 0; pos < parsed_int_permissions.Length; pos++)
                {
                    new_permission |= parsed_int_permissions[pos];
                }

                ((Keycard)keycard).Base.Permissions = (Interactables.Interobjects.DoorUtils.KeycardPermissions)new_permission;
            }


            return true;

        }
    }
}
