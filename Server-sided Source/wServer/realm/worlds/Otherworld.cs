#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class OtherWorld : World
    {
        public OtherWorld()
        {
            Name = "Other World";
            ClientWorldName = "Other World";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.otherworld.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new OtherWorld());
        }
    }
}