#region

using System.Collections.Generic;
using wServer.realm.entities;
using wServer.realm.entities.player;

#endregion

namespace wServer.realm.worlds
{
    public class DailyQuestRoom : World
    {
        public DailyQuestRoom()
        {
            Name = "Daily Quest Roomsss";
            ClientWorldName = "{nexus.Daily_Quest_Room}";
            Background = 0;
            AllowTeleport = false;
            Difficulty = -1;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.dailyQuest.wmap", MapType.Wmap);
        }


        
    }
}