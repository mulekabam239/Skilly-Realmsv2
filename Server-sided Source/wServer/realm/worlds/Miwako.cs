#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class MiwakoDungeon : World
    {
        public MiwakoDungeon()
        {
            Name = "Miwako Dungeon";
            ClientWorldName = "Miwako Dungeon";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.miwako.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new MiwakoDungeon());
        }
    }
}