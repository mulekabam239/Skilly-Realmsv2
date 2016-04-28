#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class ElderCube : World
    {
        public ElderCube()
        {
            Name = "ElderCube";
            ClientWorldName = "ElderCube";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.eldercube.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new ElderCube());
        }
    }
}