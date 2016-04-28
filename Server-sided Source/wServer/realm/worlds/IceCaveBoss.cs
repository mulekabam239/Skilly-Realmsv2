#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class TheInnerSanctum : World
    {
        public TheInnerSanctum()
        {
            Name = "The Inner Sanctum";
            ClientWorldName = "The Inner Sanctum";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.icecaveboss.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new TheInnerSanctum());
        }
    }
}