#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class Eventspawner : World
    {
        public Eventspawner()
        {
            Name = "Eventspawner";
            ClientWorldName = "Eventspawner";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.eventarena.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new Eventspawner());
        }
    }
}