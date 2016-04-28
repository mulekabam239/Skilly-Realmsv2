#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class PuppetMastersTheatre : World
    {
        public PuppetMastersTheatre()
        {
            Name = "Puppet Master's Theatre";
            ClientWorldName = "Puppet Master's Theatre";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.puppet.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new PuppetMastersTheatre());
        }
    }
}