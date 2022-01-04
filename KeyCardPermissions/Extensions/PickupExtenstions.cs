using Exiled.API.Features;
using Exiled.API.Features.Items;
using System;
using System.Collections.Generic;

namespace KeyCardPermissions.Extensions
{
    public static class PickupExtenstions
    {
        /// <summary>
        /// Modifys an individual card's permission. Is not truly used currently. 
        /// </summary>
        /// <param name="keycard"> <see cref="Item"></see></param>
        /// <param name="curr_config"> <see cref="Config"></see></param>
        /// <returns></returns>
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
