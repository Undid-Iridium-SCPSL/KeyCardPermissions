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
        public Dictionary<string, string> CardPermissions { get; set; } =
            new Dictionary<string, string>
            {
                { "KeycardJanitor" ,  "16" },
                { "KeycardScientist" ,  "16,32" },
                { "KeycardResearchCoordinator" ,  "1,16,32" },
                { "KeycardZoneManager" ,  "1,16" },
                { "KeycardGuard" ,  "1,16,128" },
                { "KeycardNTFOfficer" ,  "1,16,32,128,256" },
                { "KeycardContainmentEngineer" ,  "1,16,32,64" },
                { "KeycardNTFLieutenant" ,  "1,2,16,32,128,256" },
                { "KeycardNTFCommander" ,  "1,2,4,16,32,128,256,512" },
                { "KeycardFacilityManager" ,  "1,2,4,8,16,32,64" },
                { "KeycardChaosInsurgency" ,  "1,2,4,16,32,128,256,512" },
                { "KeycardO5" ,  "1,2,4,8,16,32,64,128,256,512" }
            };

        [Description("Gives logic choice behavior based on what you set.")]
        public Dictionary<string, bool> ProgramLevel { get; set; } =
            new Dictionary<string, bool>
            {
                { "Keycard_Config", true },
                { "Door_Config", false },
                { "Spawn_Config", false }
            };

    }

}
