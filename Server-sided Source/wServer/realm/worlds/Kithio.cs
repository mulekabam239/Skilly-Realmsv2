#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class KithioWorld : World
    {
        public KithioWorld()
        {
            Name = "Kithio World";
            ClientWorldName = "Kithio World";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.Kithio.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new KithioWorld());
        }
    }
}