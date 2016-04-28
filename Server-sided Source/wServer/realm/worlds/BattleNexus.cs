#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class BattlefortheNexus : World
    {
        public BattlefortheNexus()
        {
            Name = "Battle for the Nexus";
            ClientWorldName = "Battle for the Nexus";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.battlenexus.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new BattlefortheNexus());
        }
    }
}