#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class PacmanWorld : World
    {
        public PacmanWorld()
        {
            Name = "Pacman World";
            ClientWorldName = "Pacman World";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.pacman.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new PacmanWorld());
        }
    }
}