using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
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



            Dictionary<ItemType, KeycardPermissions[]> config_keys = KeyCardPermissions.Instance.Config.CardPermissions;
            if (config_keys == null || config_keys.Count == 0)
            {
                return false;
            }

            if (curr_config.debug_enabled)
            {
                Log.Info($"We are definitely modifying the card right..");
            }


            if (config_keys.TryGetValue(keycard.Type, out KeycardPermissions[] keycard_perms))
            {


                ushort new_permission = 0;

                for (int pos = 0; pos < keycard_perms.Length; pos++)
                {
                    new_permission |= (ushort)keycard_perms[pos];
                }

                ((Keycard)keycard).Base.Permissions = (Interactables.Interobjects.DoorUtils.KeycardPermissions)new_permission;
            }


            return true;

        }
    }
}
