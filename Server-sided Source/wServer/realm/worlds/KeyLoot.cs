#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class KeyLootChest : World
    {
        public KeyLootChest()
        {
            Name = "Key Loot Chest";
            ClientWorldName = "Key Loot Chest";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.keyloot.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new KeyLootChest());
        }
    }
}