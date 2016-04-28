#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class MiniRealmWorld : World
    {
        public MiniRealmWorld()
        {
            Name = "MiniRealm World";
            ClientWorldName = "MiniRealm World";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.minirealm.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new MiniRealmWorld());
        }
    }
}