#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class ForbiddenJungle : World
    {
        public ForbiddenJungle()
        {
            Name = "Forbidden Jungle";
            ClientWorldName = "Forbidden Jungle";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.jungle.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new ForbiddenJungle());
        }
    }
}