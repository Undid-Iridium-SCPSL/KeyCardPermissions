using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using KeyCardPermissions.Handlers;
using System;

namespace KeyCardPermissions
{
    public class KeyCardPermissions : Plugin<Config>
    {


        private Harmony harmony;

        /// <summary>
        /// Gets a static instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static KeyCardPermissions Instance { get; private set; }

        /// <inheritdoc />
        public override string Author => "Undid-Iridium";

        /// <inheritdoc />
        public override string Name => "KeyCardPermissions";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 1, 3);

        /// <inheritdoc />
        public override Version Version { get; } = new Version(1, 1, 4);


        /// <summary>
        /// Entrance function called through Exile
        /// </summary>
        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            harmony = new Harmony($"com.Undid-Iridium.KeyCardPermissions.{DateTime.UtcNow.Ticks}");
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
            Instance = null;
            base.OnDisabled();
        }


        /// <inheritdoc cref="EventsHandler"/>
        public EventsHandler Handler { get; private set; }

        /// <summary>
        /// Registers events for EXILE to hook unto with cororotines (I think?)
        /// </summary>
        public void RegisterEvents()
        {

            Handler = new EventsHandler(KeyCardPermissions.Instance.Config);
            Handler.Start();

            Log.Info("KeyCardPermissions has been loaded");

        }
        /// <summary>
        /// Unregisters the events defined in RegisterEvents, recommended that everything created be destroyed if not reused in some way.
        /// </summary>
        public void UnRegisterEvents()
        {
            Log.Info("KeyCardPermissions has been unloaded");
        }
    }
}
