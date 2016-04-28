#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class Spongebob : World
    {
        public Spongebob()
        {
            Name = "Spongebob";
            ClientWorldName = "Spongebob";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.spongebob.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new Spongebob());
        }
    }
}