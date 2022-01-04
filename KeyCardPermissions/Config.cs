using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
namespace KeyCardPermissions
{
    public sealed class Config : IConfig
    {
        //public bool IsEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Description("Whether to enable or disable plugin")]
        public bool IsEnabled { get; set; } = true;

        [Description("Gives access to the keycards you set per class.")]
        public Dictionary<ItemType, string> CardPermissions { get; set; } =
            new Dictionary<ItemType, string>
            {
                 { ItemType.KeycardJanitor,  "16" },
                { ItemType.KeycardScientist ,  "16,32" },
                { ItemType.KeycardResearchCoordinator ,  "1,16,32" },
                { ItemType.KeycardZoneManager ,  "1,16" },
                { ItemType.KeycardGuard ,  "1,16,128" },
                { ItemType.KeycardNTFOfficer ,  "1,16,32,128,256" },
                { ItemType.KeycardContainmentEngineer ,  "1,16,32,64" },
                { ItemType.KeycardNTFLieutenant ,  "1,2,16,32,128,256" },
                { ItemType.KeycardNTFCommander ,  "1,2,4,16,32,128,256,512" },
                { ItemType.KeycardFacilityManager ,  "1,2,4,8,16,32,64" },
                { ItemType.KeycardChaosInsurgency ,  "1,2,4,16,32,128,256,512" },
                { ItemType.KeycardO5 ,  "1,2,4,8,16,32,64,128,256,512" }
            };





        [Description("Gives logic choice behavior based on what you set.")]
        public Dictionary<string, bool> ProgramLevel { get; set; } =
            new Dictionary<string, bool>
            {
                { "Keycard_Config", true },
                { "Spawn_Config", false }
            };

        [Description("Debug flag.")]
        public bool debug_enabled { get; set; } = false;
    }

}
