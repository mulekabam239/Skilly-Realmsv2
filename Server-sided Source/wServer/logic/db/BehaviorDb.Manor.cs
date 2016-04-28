using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {

        private _ Manor = () => Behav()
            .Init("Lord Ruthven",
                new State(
                    new DropPortalOnDeath("Glowing Realm Portal", 100, PortalDespawnTimeSec: 360),
                    //new Taunt(new string[3]
                    //{
                    //    "Start",
                    //    "Ring_Attack",
                    //    "Ring_Attack2"
                    //},
                    //text: "You are nothing more than nutiment for my roots.", cooldown: 15000),

                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(8, "Start")
                    ),
                    new State("Start",
                        new Taunt("come closer kids."),
                        new Shoot(16, count: 12, shootAngle: (float)(180 / 4), predictive: 0.7, coolDown: 1500),
                        new Shoot(16, count: 6, shootAngle: (float)60, angleOffset: (float)45, projectileIndex: 0, coolDown: 1000),
                        new Shoot(16, count: 14, shootAngle: (float)25, angleOffset: (float)-45, projectileIndex: 1, coolDown: 2000)
                    
                    
                        )
                ),
                 new Threshold(0.1,
              new TierLoot(12, ItemType.Weapon, 0.01),
              new TierLoot(11, ItemType.Weapon, 0.05),
              new TierLoot(10, ItemType.Weapon, 0.15),
              new TierLoot(10, ItemType.Armor, 0.2),
              new TierLoot(11, ItemType.Armor, 0.1),
              new TierLoot(12, ItemType.Armor, 0.05),
              new TierLoot(13, ItemType.Armor, 0.01),
              new TierLoot(5, ItemType.Ring, 0.1),
              new ItemLoot("Ring of Divine Faith", 0.012),
              new ItemLoot("Tome of Purification", 0.012),
              new ItemLoot("St. Abraham's Wand", 0.012),
              new ItemLoot("Chasuble of Holy Light", 0.012),
              new ItemLoot("Bone Dagger", 0.012),

              new ItemLoot("Potion of Attack", 1.0)
            
                        
                     )
                
            );
    }
}
