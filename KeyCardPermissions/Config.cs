using Exiled.API.Enums;
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
        public Dictionary<ItemType, KeycardPermissions[]> CardPermissions { get; set; } =
            new Dictionary<ItemType, KeycardPermissions[]>
            {
                 { ItemType.KeycardJanitor,  new KeycardPermissions[] {KeycardPermissions.ContainmentLevelOne } },
                { ItemType.KeycardScientist ,  new KeycardPermissions[] { KeycardPermissions.ContainmentLevelOne, KeycardPermissions.ContainmentLevelTwo} },
                { ItemType.KeycardResearchCoordinator ,  new KeycardPermissions[] {KeycardPermissions.Checkpoints, KeycardPermissions.ContainmentLevelOne, KeycardPermissions.ContainmentLevelTwo}},
                { ItemType.KeycardZoneManager , new KeycardPermissions[] {KeycardPermissions.Checkpoints, KeycardPermissions.ContainmentLevelOne } },
                { ItemType.KeycardGuard ,  new KeycardPermissions[] { KeycardPermissions.Checkpoints,KeycardPermissions.ContainmentLevelOne,KeycardPermissions.ArmoryLevelOne } },
                { ItemType.KeycardNTFOfficer ,  new KeycardPermissions[] { KeycardPermissions.Checkpoints,KeycardPermissions.ContainmentLevelOne,KeycardPermissions.ContainmentLevelTwo,KeycardPermissions.ArmoryLevelOne, KeycardPermissions.ArmoryLevelTwo } },
                { ItemType.KeycardContainmentEngineer ,  new KeycardPermissions[] { KeycardPermissions.Checkpoints,KeycardPermissions.ContainmentLevelOne,KeycardPermissions.ContainmentLevelTwo, KeycardPermissions.ContainmentLevelThree } },
                { ItemType.KeycardNTFLieutenant ,  new KeycardPermissions[] { KeycardPermissions.Checkpoints,KeycardPermissions.ExitGates,KeycardPermissions.ContainmentLevelOne,KeycardPermissions.ContainmentLevelTwo,KeycardPermissions.ArmoryLevelOne, KeycardPermissions.ArmoryLevelTwo } },
                { ItemType.KeycardNTFCommander ,  new KeycardPermissions[] { KeycardPermissions.Checkpoints,KeycardPermissions.ExitGates,KeycardPermissions.Intercom,KeycardPermissions.ContainmentLevelOne,KeycardPermissions.ContainmentLevelTwo,KeycardPermissions.ArmoryLevelOne, KeycardPermissions.ArmoryLevelTwo, KeycardPermissions.ArmoryLevelThree } },
                { ItemType.KeycardFacilityManager ,  new KeycardPermissions[] { KeycardPermissions.Checkpoints,KeycardPermissions.ExitGates,KeycardPermissions.Intercom,KeycardPermissions.AlphaWarhead,KeycardPermissions.ContainmentLevelOne,KeycardPermissions.ContainmentLevelTwo, KeycardPermissions.ContainmentLevelThree } },
                { ItemType.KeycardChaosInsurgency ,  new KeycardPermissions[] { KeycardPermissions.Checkpoints,KeycardPermissions.ExitGates,KeycardPermissions.Intercom,KeycardPermissions.ContainmentLevelOne,KeycardPermissions.ContainmentLevelTwo,KeycardPermissions.ArmoryLevelOne, KeycardPermissions.ArmoryLevelTwo, KeycardPermissions.ArmoryLevelThree } },
                { ItemType.KeycardO5 ,  new KeycardPermissions[] { KeycardPermissions.Checkpoints,KeycardPermissions.ExitGates,KeycardPermissions.Intercom,KeycardPermissions.AlphaWarhead,KeycardPermissions.ContainmentLevelOne,KeycardPermissions.ContainmentLevelTwo, KeycardPermissions.ContainmentLevelThree,  KeycardPermissions.ArmoryLevelOne, KeycardPermissions.ArmoryLevelTwo, KeycardPermissions.ArmoryLevelThree } }
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
