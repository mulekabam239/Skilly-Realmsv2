#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class WoodlandLabyrinth : World
    {
        public WoodlandLabyrinth()
        {
            Name = "Woodland Labyrinth";
            ClientWorldName = "Woodland Labyrinth";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.epicforestmaze.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new WoodlandLabyrinth());
        }
    }
}