#region

using System.Collections.Generic;
using System.IO;
using wServer.realm.entities;
using wServer.realm.entities.player;
using wServer.realm.terrain;

#endregion

namespace wServer.realm.worlds
{
    public class Nexus : World
    {
        public const string WEIRD_RESOURCE = "wServer.realm.worlds.maps.necus1.jm";
        public const string DESERT_RESOURCE = "wServer.realm.worlds.maps.desertnexus.jm";
        public const string CANDY_RESOURCE = "wServer.realm.worlds.maps.candynexus.jm";
        public const string EARTH_RESOURCE = "wServer.realm.worlds.maps.earthnexus.jm";
        public const string RAINBOW_RESOURCE = "wServer.realm.worlds.maps.rainbownexus.jm";
        public const string BADASS_RESOURCE = "wServer.realm.worlds.maps.badassnexus.jm";
        public const string CUSTOM_RESOURCE = "wServer.realm.worlds.maps.customnexus.jm";

        public Nexus()
        {
            Id = NEXUS_ID;
            Name = "Nexus";
            ClientWorldName = "Skilly's Nexus";
            Background = 2;
            AllowTeleport = false;
            Difficulty = 5;
        }

        protected override void Init()
        {
            LoadMap(CUSTOM_RESOURCE, MapType.Json);
        }

        public override void Tick(RealmTime time)
        {
            base.Tick(time); //normal world tick

            CheckDupers();
            UpdatePortals();
        }

        private void CheckDupers()
        {
            foreach (KeyValuePair<int, World> w in Manager.Worlds)
            {
                foreach (KeyValuePair<int, World> x in Manager.Worlds)
                {
                    foreach (KeyValuePair<int, Player> y in w.Value.Players)
                    {
                        foreach (KeyValuePair<int, Player> z in x.Value.Players)
                        {
                            if (y.Value.AccountId == z.Value.AccountId && y.Value != z.Value)
                            {
                                y.Value.Client.Disconnect();
                                z.Value.Client.Disconnect();
                            }
                        }
                    }
                }
            }
        }

        private void UpdatePortals()
        {
            foreach (var i in Manager.Monitor.portals)
            {
                foreach (var j in RealmManager.CurrentRealmNames)
                {
                    if (i.Value.Name.StartsWith(j))
                    {
                        if (i.Value.Name == j) (i.Value as Portal).PortalName = i.Value.Name;
                        i.Value.Name = j + " (" + i.Key.Players.Count + "/" + RealmManager.MAX_REALM_PLAYERS + ")";
                        i.Value.UpdateCount++;
                        break;
                    }
                }
            }
        }
    }
}