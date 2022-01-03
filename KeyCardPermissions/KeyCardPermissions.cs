using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using KeyCardPermissions.Handlers;

namespace KeyCardPermissions
{
    public class KeyCardPermissions : Plugin<Config>
    {


        public static Config early_config;

        /// <summary>
        /// Medium priority, lower prioritys mean faster loadin
        /// </summary>
        public override PluginPriority Priority { get; } = PluginPriority.Medium;



        private Harmony harmony;
        private string harmony_id = "com.Undid-Iridium.KeyCardPermissions";




        /// <summary>
        /// Entrance function called through Exile
        /// </summary>
        public override void OnEnabled()
        {
            RegisterEvents();
            harmony = new Harmony(harmony_id);
            harmony.PatchAll();
            base.OnEnabled();

        }
        /// <summary>
        /// Destruction function called through Exile
        /// </summary>
        public override void OnDisabled()
        {
            UnRegisterEvents();
            harmony.UnpatchAll(harmony.Id);
            harmony = null;
            base.OnDisabled();
        }


        /// <inheritdoc cref="EventsHandler"/>
        public EventsHandler Handler { get; private set; }

        /// <summary>
        /// Registers events for EXILE to hook unto with cororotines (I think?)
        /// </summary>
        public void RegisterEvents()
        {
            // Register the event handler class. And add the event,
            // to the EXILED_Events event listener so we get the event.
            if (!Config.IsEnabled)
            {
                return;
            }
            early_config = Config;

            Handler = new EventsHandler(Config);
            Handler.Start();

            //currentSpectator = new Handlers.SpectatorMonitor();

            //if (Config.ForceConstantUpdates)
            //{
            //    eventHandler = new Handlers.ForcedEventHandlers();
            //    PlayerEvents.ChangingRole += eventHandler.OnRoleChange;
            //}
            //else
            //{

            //    PlayerEvents.Died += currentSpectator.OnDeath;
            //    PlayerEvents.Spawning += currentSpectator.OnRespawn;
            //    PlayerEvents.ChangingRole += currentSpectator.OnChanginRole;

            //    ServerEvents.EndingRound += currentSpectator.OnRoundEnd;
            //    ServerEvents.RestartingRound += currentSpectator.OnRoundRestart;
            //    ServerEvents.WaitingForPlayers += currentSpectator.OnRoundRestart;
            //    ServerEvents.RespawningTeam += currentSpectator.OnTeamSpawn;
            //}


            Log.Info("KeyCardPermissions has been loaded");

        }
        /// <summary>
        /// Unregisters the events defined in RegisterEvents, recommended that everything created be destroyed if not reused in some way.
        /// </summary>
        public void UnRegisterEvents()
        {
            // Make it dynamically updatable.
            // We do this by removing the listener for the event and then nulling the event handler.
            // This process must be repeated for each event.
            //if (Config.ForceConstantUpdates)
            //{
            //    eventHandler = null;
            //    PlayerEvents.ChangingRole -= eventHandler.OnRoleChange;
            //}
            //else
            //{
            //    PlayerEvents.Died -= currentSpectator.OnDeath;
            //    PlayerEvents.Spawning -= currentSpectator.OnRespawn;
            //    PlayerEvents.ChangingRole -= currentSpectator.OnChanginRole;

            //    ServerEvents.EndingRound -= currentSpectator.OnRoundEnd;
            //    ServerEvents.RestartingRound -= currentSpectator.OnRoundRestart;
            //    ServerEvents.WaitingForPlayers -= currentSpectator.OnRoundRestart;
            //    ServerEvents.RespawningTeam -= currentSpectator.OnTeamSpawn;
            //}
            //currentSpectator = null;

            Log.Info("KeyCardPermissions has been unloaded");
        }
    }
}
