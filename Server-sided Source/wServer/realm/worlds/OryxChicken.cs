#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class OryxChicken : World
    {
        public OryxChicken()
        {
            Name = "Oryx Chicken";
            ClientWorldName = "Oryx Chicken";
            Background = 0;
            AllowTeleport = false;
        }

        public override bool NeedsPortalKey => true;

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.oryxchicken.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new OryxChicken());
        }
    }
}