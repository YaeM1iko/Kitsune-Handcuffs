using Exiled.API.Enums;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace Arest2
{
    public class Arest2 : Plugin<Config>
    {
        public static Arest2 Instance { get; } = new Arest2();
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Handlers.Player player;

        private Arest2()
        {

        }

        public override void OnEnabled()
        {
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        private void RegisterEvents()
        {
            player = new Handlers.Player();

            Player.Died += player.OnDied;
        }
        
        private void UnregisterEvents()
        {
            Player.Died -= player.OnDied;

            player = null;
        }
    }
}