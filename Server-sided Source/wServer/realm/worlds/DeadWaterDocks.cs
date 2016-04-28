#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class DeadwaterDocks : World
    {
        public DeadwaterDocks()
        {
            Name = "Deadwater Docks";
            ClientWorldName = "Deadwater Docks";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.deadwater.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new DeadwaterDocks());
        }
    }
}