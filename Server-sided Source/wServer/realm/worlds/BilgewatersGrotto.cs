#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class BilgewatersGrotto : World
    {
        public BilgewatersGrotto()
        {
            Name = "Bilgewater's Grotto";
            ClientWorldName = "Bilgewater's Grotto";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.deadwaterboss.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new BilgewatersGrotto());
        }
    }
}