using Exiled.Events.EventArgs;
using KeyCardPermissions.Extensions;
using Players = Exiled.Events.Handlers.Player;
namespace KeyCardPermissions.Handlers
{
    public class EventsHandler
    {
        private readonly Config config;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsHandler"/> class.
        /// </summary>
        /// <param name="config">The <see cref="Config"/> settings that will be used.</param>
        public EventsHandler(Config config) => this.config = config;

        /// <summary>
        /// Registers all events used.
        /// </summary>
        internal void Start()
        {
            this.config.ProgramLevel.TryGetValue("Spawn_Config", out bool is_enabled);
            if (!is_enabled)
            {
                return;
            }
            Players.Spawning += OnRespawn;
            Players.PickingUpItem += OnPickup;
        }

        /// <summary>
        /// Unregisters all events used.
        /// </summary>
        public void Stop()
        {
            this.config.ProgramLevel.TryGetValue("Spawn_Config", out bool is_enabled);
            if (!is_enabled)
            {
                return;
            }
            Players.Spawning -= OnRespawn;
            Players.PickingUpItem -= OnPickup;
        }

        private void OnPickup(PickingUpItemEventArgs ev)
        {
            ev.Player.ModifyKeycardPermissions(this.config);
        }

        private void OnRespawn(SpawningEventArgs ev)
        {
            ev.Player.ModifyKeycardPermissions(this.config);
        }




    }
}
