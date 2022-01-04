using Exiled.API.Features;
using HarmonyLib;
using InventorySystem;
using InventorySystem.Items.Keycards;
using KeyCardPermissions.Utilities;
using System;
using System.Collections.Generic;

namespace KeyCardPermissions.Patches
{

    [HarmonyPatch(typeof(InventoryItemLoader))]
    [HarmonyPatch("ForceReload", MethodType.Normal)]
    class OverrideDefaultItems
    {


        /// <summary>
        /// Patches the keycard object _loadedItems such that after it is loaded, or when forcedReload is called
        /// the object is thereafter changes where all cards are now updated with the permissions listed in the config file
        /// </summary>
        [HarmonyPostfix]
        public static void OverloadForceReloadPost()
        {

            try
            {
                KeyCardPermissions.early_config.ProgramLevel.TryGetValue("Keycard_Config", out bool is_enabled);

                if (!is_enabled)
                {
                    return;
                }

                Dictionary<global::ItemType, InventorySystem.Items.ItemBase> curr_loaded_items =
                    (Dictionary<ItemType, InventorySystem.Items.ItemBase>)Traverse.Create(typeof(InventoryItemLoader)).Field("_loadedItems").GetValue();

                Dictionary<ItemType, string> config_keys = KeyCardPermissions.early_config.CardPermissions;
                if (config_keys == null || config_keys.Count == 0)
                {
                    return;
                }

                foreach (KeyValuePair<ItemType, string> paired_entry in config_keys)
                {
                    ItemType associated_role = paired_entry.Key;
                    if (curr_loaded_items.ContainsKey(associated_role))
                    {
                        KeycardItem current_keycard = (KeycardItem)curr_loaded_items[associated_role];

                        if (!config_keys.TryGetValue(associated_role, out string all_permissions))
                        {
                            continue;
                        }

                        string[] config_perm_arr = all_permissions.Split(',');
                        ushort[] parsed_int_permissions = Array.ConvertAll(config_perm_arr, ushort.Parse);
                        ushort new_permission = 0;
                        for (int pos = 0; pos < parsed_int_permissions.Length; pos++)
                        {
                            new_permission |= parsed_int_permissions[pos];
                        }

                        current_keycard.Permissions = (Interactables.Interobjects.DoorUtils.KeycardPermissions)new_permission;
                        curr_loaded_items[associated_role] = current_keycard;
                    }
                }

                Traverse.Create(typeof(InventoryItemLoader)).Field("_loadedItems").SetInstanceField("_loadedItems", curr_loaded_items);
            }
            catch (Exception harmony_error)
            {
                Log.Error($"OverloadForceReloadPost.OverloadForceReloadPost: {harmony_error}\n{harmony_error.StackTrace}\n{Environment.StackTrace}");
            }


        }



    }

}
