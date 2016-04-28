#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class IceCave : World
    {
        public IceCave()
        {
            Name = "Ice Cave";
            ClientWorldName = "Ice Cave";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.icecave.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new IceCave());
        }
    }
}