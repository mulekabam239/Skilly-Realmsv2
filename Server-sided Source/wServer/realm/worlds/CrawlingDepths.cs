#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class TheCrawlingDepths : World
    {
        public TheCrawlingDepths()
        {
            Name = "The Crawling Depths";
            ClientWorldName = "The Crawling Depths";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.crawlingdepths.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new TheCrawlingDepths());
        }
    }
}