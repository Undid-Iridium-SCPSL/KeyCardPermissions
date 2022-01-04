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
        public Dictionary<ItemType, ushort[]> CardPermissions { get; set; } =
            new Dictionary<ItemType, ushort[]>
            {
                 { ItemType.KeycardJanitor,  new ushort[] {16} },
                { ItemType.KeycardScientist ,  new ushort[] {16, 32} },
                { ItemType.KeycardResearchCoordinator ,  new ushort[] {1,16,32}},
                { ItemType.KeycardZoneManager , new ushort[] {1,16 } },
                { ItemType.KeycardGuard ,  new ushort[] { 1, 16, 128 } },
                { ItemType.KeycardNTFOfficer ,  new ushort[] { 1, 16, 32, 128, 256 } },
                { ItemType.KeycardContainmentEngineer ,  new ushort[] { 1, 16, 32, 64 } },
                { ItemType.KeycardNTFLieutenant ,  new ushort[] { 1, 2, 16, 32, 128, 256 } },
                { ItemType.KeycardNTFCommander ,  new ushort[] { 1, 2, 4, 16, 32, 128, 256, 512 } },
                { ItemType.KeycardFacilityManager ,  new ushort[] { 1, 2, 4, 8, 16, 32, 64 } },
                { ItemType.KeycardChaosInsurgency ,  new ushort[] { 1, 2, 4, 16, 32, 128, 256, 512 } },
                { ItemType.KeycardO5 ,  new ushort[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 } }
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
