#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class XPGift : World
    {
        private readonly bool isLimbo;

        public XPGift(bool isLimbo)
        {
            Id = XP_ID;
            Name = "XPGift";
            ClientWorldName = "Experience Chicks!";
            Background = 0;
            this.isLimbo = isLimbo;
        }

        protected override void Init()
        {
            if (!(IsLimbo = isLimbo))
            {
                LoadMap("wServer.realm.worlds.maps.xpgift.jm", MapType.Json);
            }
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new XPGift(false));
        }
    }
}