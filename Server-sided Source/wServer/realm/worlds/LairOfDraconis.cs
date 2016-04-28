#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class LairofDraconis : World
    {
        public LairofDraconis()
        {
            Name = "Lair of Draconis";
            ClientWorldName = "Lair of Draconis";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.lairofdraconis.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new LairofDraconis());
        }
    }
}