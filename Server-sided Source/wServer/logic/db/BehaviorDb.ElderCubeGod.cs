using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        _ ElderCubeGod = () => Behav()
            .Init("Elder Cube God",
                new State(
                    new DropPortalOnDeath("Glowing Realm Portal", 100, PortalDespawnTimeSec: 360),
                    new StayCloseToSpawn(0.3, range: 7),
                           new Wander(0.5),
                             new Shoot(10, count: 9, predictive: 0.9, shootAngle: 6.5, coolDown: 1000),
                             new Spawn("Elder Cube Overseer", maxChildren: 5, initialSpawn: 3, coolDown: 100000),
                             new Spawn("Elder Cube Defender", maxChildren: 5, initialSpawn: 5, coolDown: 100000),
                             new Spawn("Elder Cube Blaster", maxChildren: 5, initialSpawn: 5, coolDown: 100000)
                ),
                new Threshold(1.0,
                    new TierLoot(9, ItemType.Weapon, 0.2),
                    new TierLoot(10, ItemType.Weapon, 0.03),
                    new TierLoot(11, ItemType.Weapon, 0.02),
                    new TierLoot(12, ItemType.Weapon, 0.01),
                    new TierLoot(5, ItemType.Ring, 0.2),
                    new TierLoot(6, ItemType.Ring, 0.05),
                    new TierLoot(7, ItemType.Ring, 0.01),
                    new TierLoot(9, ItemType.Armor, 0.2),
                    new TierLoot(10, ItemType.Armor, 0.1),
              new ItemLoot("Sword of Split Reality", 0.012),
              new ItemLoot("Shield of Conflicting Universe", 0.012),
              new ItemLoot("Ring of Everlasting Evolution", 0.012),
              new ItemLoot("Armour of Smited Souls", 0.012),
                    new ItemLoot("Legendary Food", 0.09),
                    new TierLoot(11, ItemType.Armor, 0.03),
                    new TierLoot(12, ItemType.Armor, 0.02),
                    new TierLoot(13, ItemType.Armor, 0.01),
                    new TierLoot(5, ItemType.Ability, 0.1),
                    new TierLoot(6, ItemType.Ability, 0.03)
                )
            )
            .Init("Elder Cube Overseer",
                new State(
                    new EntityNotExistsTransition("Elder Cube God", 100, "Despawn"),
                    new StayCloseToSpawn(0.3, range: 7),
                    new State("lol",
                        new State("ntykid",
                             new Wander(1),
                             new Shoot(10, count: 4, predictive: 0.9, projectileIndex: 0, coolDown: 1250))

                    ),



                new State("Despawn",
                        new Timed(1000, new Suicide())
                    )
                )
            )
            .Init("Elder Cube Defender",
                new State(
                    new EntityNotExistsTransition("Elder Cube God", 100, "Despawn"),
                    new Wander(0.5),
                    new State("lol",
                        new State("ntykid",
                             new StayCloseToSpawn(0.03, range: 7),
                             new Follow(0.4, acquireRange: 9, range: 2),
                             new Shoot(10, count: 1, coolDown: 1000, predictive: 0.9, projectileIndex: 0))

                    ),



                new State("Despawn",
                        new Timed(1000, new Suicide())
                    )
                )
            )
            .Init("Elder Cube Blaster",
                new State(
                    new EntityNotExistsTransition("Elder Cube God", 100, "Despawn"),
                    new Wander(0.5),
                    new State("lol",
                        new State("ntykid",
                             new StayCloseToSpawn(0.03, range: 7),
                             new Follow(0.4, acquireRange: 9, range: 2),
                             new Shoot(10, count: 2, predictive: 0.9, projectileIndex: 0, coolDown: 1500),
                             new Shoot(10, count: 1, predictive: 0.9, projectileIndex: 0, coolDown: 1500))

                    ),



                new State("Despawn",
                        new Timed(1000, new Suicide())
                    )
                )
            );
    }
}
