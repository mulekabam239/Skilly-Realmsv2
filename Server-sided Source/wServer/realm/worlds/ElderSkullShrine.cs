#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class ElderSkull : World
    {
        public ElderSkull()
        {
            Name = "ElderSkull";
            ClientWorldName = "ElderSkull";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.elderskull.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new ElderSkull());
        }
    }
}