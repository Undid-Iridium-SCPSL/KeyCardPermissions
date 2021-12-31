using BroadcastForScps.Utilities;
using Exiled.API.Features;
using HarmonyLib;
using InventorySystem;
using InventorySystem.Items.Keycards;
using System;
using System.Collections.Generic;

namespace KeyCardPermissions.Patches
{

    [HarmonyPatch(typeof(InventoryItemLoader))]
    [HarmonyPatch("ForceReload", MethodType.Normal)]
    class OverrideDefaultItems
    {

        [HarmonyPrefix]
        public static bool OverloadForceReloadPre(        /*ScpVoiceProfile __instance*/)
        {
            return true;

        }

        [HarmonyPostfix]
        public static void OverloadForceReloadPost(/*ref ScpVoiceProfile __instance*/)
        {

            try
            {
                KeyCardPermissions.early_config.ProgramLevel.TryGetValue("Keycard_Config", out bool is_enabled);

                if (!is_enabled)
                {
                    return;
                }
                bool myvalue = (bool)Traverse.Create(typeof(InventoryItemLoader)).Field("_loaded").GetValue();
                Dictionary<global::ItemType, InventorySystem.Items.ItemBase> curr_loaded_items =
                    (Dictionary<ItemType, InventorySystem.Items.ItemBase>)Traverse.Create(typeof(InventoryItemLoader)).Field("_loadedItems").GetValue();

                Dictionary<string, string> config_keys = KeyCardPermissions.early_config.CardPermissions;
                List<string> keyList = new List<string>(config_keys.Keys);
                List<KeyValuePair<global::ItemType, InventorySystem.Items.ItemBase>> items_to_replace = new List<KeyValuePair<global::ItemType, InventorySystem.Items.ItemBase>>();
                foreach (KeyValuePair<global::ItemType, InventorySystem.Items.ItemBase> entry in curr_loaded_items)
                {
                    string card_name = entry.Key.ToString();
                    if (config_keys.ContainsKey(card_name))
                    {
                        List<int> permissions_to_add = new List<int>();


                        config_keys.TryGetValue(card_name, out string all_permissions);
                        string[] config_perm_arr = all_permissions.Split(',');
                        int[] parsed_int_permissions = Array.ConvertAll(config_perm_arr, int.Parse);
                        Interactables.Interobjects.DoorUtils.KeycardPermissions item = ((KeycardItem)entry.Value).Permissions;

                        int new_permission = 0;

                        for (int pos = 0; pos < parsed_int_permissions.Length; pos++)
                        {
                            new_permission |= parsed_int_permissions[pos];
                        }
                        //https://stackoverflow.com/questions/7334832/are-addition-and-bitwise-or-the-same-in-this-case 
                        //This is, as the stack post shows, a risky and stupid thing to do but that's how northwood did it 
                        //and I don't intend to break things. 
                        //item = (Interactables.Interobjects.DoorUtils.KeycardPermissions)(16 | 32 | 64 | 128 | 256);
                        item = (Interactables.Interobjects.DoorUtils.KeycardPermissions)(new_permission);
                        ((KeycardItem)entry.Value).Permissions = item;
                        items_to_replace.Add(new KeyValuePair<global::ItemType, InventorySystem.Items.ItemBase>(entry.Key, entry.Value));

                    }

                }

                foreach (KeyValuePair<global::ItemType, InventorySystem.Items.ItemBase> paired_data in items_to_replace)
                {
                    curr_loaded_items[paired_data.Key] = paired_data.Value;
                }

                Traverse.Create(typeof(InventoryItemLoader)).Field("_loadedItems").SetInstanceField("_loadedItems", curr_loaded_items);
            }
            catch (System.Exception e)
            {
                //Log.Error($"OverloadForceReloadPost.OverloadForceReloadPost: {e}\n{e.StackTrace}\n{System.Environment.StackTrace}");
                Log.Info($"OverloadForceReloadPost.OverloadForceReloadPost: {e}\n{e.StackTrace}\n{System.Environment.StackTrace}");
            }


        }



    }

}
