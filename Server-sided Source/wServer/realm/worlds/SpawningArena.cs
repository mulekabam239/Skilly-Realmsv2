#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class SpawningArena : World
    {
        public SpawningArena()
        {
            Name = "SpawningArena";
            ClientWorldName = "SpawningArena";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.spawningarena.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new SpawningArena());
        }
    }
}