#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ EpicPirateCave = () => Behav()
        .Init("Jon Bilgewater the Pirate King",
            new State(
                    new DropPortalOnDeath("Glowing Realm Portal", 100, PortalDespawnTimeSec: 360),
                new State("Idle",
                    new PlayerWithinTransition(15, "swiggity")
                ),
                new State("swiggity",
                    new StayCloseToSpawn(1, 7),
                    new Shoot(radius: 8, count: 14, shootAngle: (float)35, projectileIndex: 1, coolDown: 4500, predictive: 0.9),
                    new Shoot(radius: 8, count: 1, projectileIndex: 0, coolDown: 1000, predictive: 0.9),

                        new HpLessTransition(0.3, "Rage")
                         ),
                    new State("Rage",
                        new Prioritize(

                        new Follow(0.4, range: 4, duration: 5000, coolDown: 0)
                        ),
                        new Taunt("CANNON BARRAGE!"),

                    new Shoot(radius: 8, count: 12, shootAngle: (float)35, projectileIndex: 1, coolDown: 4500, predictive: 0.9),
                    new Shoot(radius: 8, count: 5, shootAngle: (float)15, projectileIndex: 0, coolDown: 1000, predictive: 0.9)

                        )
                    
                ),
            new Threshold(0.25,

              new TierLoot(12, ItemType.Weapon, 0.01),
              new TierLoot(11, ItemType.Weapon, 0.05),
              new TierLoot(10, ItemType.Weapon, 0.15),
              new TierLoot(10, ItemType.Armor, 0.2),
              new TierLoot(11, ItemType.Armor, 0.1),
              new TierLoot(12, ItemType.Armor, 0.05),
              new TierLoot(13, ItemType.Armor, 0.01),
              new TierLoot(5, ItemType.Ring, 0.1),
              new ItemLoot("Pirate King's Cutlass", 0.012),
              new ItemLoot("Blood Silk Armor", 0.012),
              new ItemLoot("Robe of the Ice Dragon", 0.012),
                    new ItemLoot("Rich Food", 0.2),
              new ItemLoot("Robe of the Grand Magican", 0.012),
              new ItemLoot("Potion of Mana", 0.5)
            )
            )

          .Init("Deadwater Docks Macaw",
              new State(
                  new Prioritize(
                      new Wander(0.5),
                      new Follow(1, 6, 1, -1, 0)
                      ),
                      new Shoot(radius: 7, projectileIndex: 0, predictive: 1, coolDown: 1500)
                 ),
              new TierLoot(3, ItemType.Weapon, 0.05),
              new TierLoot(2, ItemType.Weapon, 0.15),
              new TierLoot(1, ItemType.Armor, 0.2),
              new TierLoot(1, ItemType.Ring, 0.1),
              new ItemLoot("Pirate Rum", 0.01)
          )
          .Init("Deadwater Docks Captain",
              new State(
                  new Prioritize(
                      new Wander(0.5),
                      new Follow(1, 6, 1, -1, 0)
                      ),
                      new Shoot(radius: 7, projectileIndex: 0, predictive: 1, coolDown: 1500)
                 )
          )
          .Init("Deadwater Docks Admiral",
              new State(
                  new Prioritize(
                      new Wander(0.5)
                      ),
                      new Shoot(radius: 7, projectileIndex: 0, predictive: 1, coolDown: 1500)
                 )
          )
          .Init("Deadwater Docks Brawler",
              new State(
                  new State("that",
                      new Follow(1, 6, 1, -1, 0),
                      new Wander(0.3),
                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 1000)
                      )
                  )
          )
          .Init("Deadwater Docks Sailor",
              new State(
                  new State("booty",
                      new Wander(0.8),
                      new Follow(0.8, 6, 1, -1, 0),
                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 1000)
                      )
                  )
          )
          .Init("Deadwater Docks Veteran",
              new State(
                  new Prioritize(
                      new Wander(0.5)
                      )
                  )
          )

          .Init("Parrot Cage",
              new State(
                  
                  new State("Spawn",

                                 new TossObject("Protection Parrot", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot", 2, 0, coolDown: 9999999, randomToss: true)

                      )
                  )
          )
                  .Init("0A Parrot Cage 1",
              new State(

                  new State("Spawn",

                                 new TossObject("Protection Parrot 2", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot 2", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot 2", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot 2", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot 2", 2, 0, coolDown: 9999999, randomToss: true)

                      )
                  )
          )
                          .Init("0A Parrot Cage 2",
              new State(

                  new State("Spawn",

                                 new TossObject("Protection Parrot 3", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot 3", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot 3", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot 3", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot 3", 2, 0, coolDown: 9999999, randomToss: true)

                      )
                  )
          )
        .Init("0A Parrot Cage 3",
              new State(

                  new State("Spawn",

                                 new TossObject("Protection Parrot 4", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot 4", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot 4", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot 4", 2, 0, coolDown: 9999999, randomToss: true),
                                 new TossObject("Protection Parrot 4", 2, 0, coolDown: 9999999, randomToss: true)

                      )
                  )
          )
          .Init("Protection Parrot",
              new State(
                new State("OrbitCage",

                      new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 2000),
                        new Orbit(.6, 2, target: "Parrot Cage", radiusVariance: 0.5),
                    new TimedTransition(10000, "OrbitBoss")
                    ),
                new State("OrbitBoss",

                      new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Orbit(.6, 2, target : "Jon Bilgewater the Pirate King", radiusVariance: 0.5),

                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 2000),
                    new TimedTransition(10000, "OrbitCage")
                    
                      )
                  )
          )
                  .Init("Protection Parrot 2",
              new State(
                new State("OrbitCage",

                      new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 2000),
                        new Orbit(.6, 2, target: "0A Parrot Cage 1", radiusVariance: 0.5),
                    new TimedTransition(10000, "OrbitBoss")
                    ),
                new State("OrbitBoss",

                      new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Orbit(.6, 5, target: "Jon Bilgewater the Pirate King", radiusVariance: 0.5),

                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 2000),
                    new TimedTransition(10000, "OrbitCage")

                      )
                  )
          )

           .Init("Protection Parrot 3",
              new State(
                new State("OrbitCage",

                      new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 2000),
                        new Orbit(.6, 2, target: "0A Parrot Cage 2", radiusVariance: 0.5),
                    new TimedTransition(10000, "OrbitBoss")
                    ),
                new State("OrbitBoss",

                      new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Orbit(.6, 3, target: "Jon Bilgewater the Pirate King", radiusVariance: 0.5),

                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 2000),
                    new TimedTransition(10000, "OrbitCage")

                      )
                  )
          )
           .Init("Protection Parrot 4",
              new State(
                new State("OrbitCage",

                      new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 2000),
                        new Orbit(.6, 2, target: "0A Parrot Cage 3", radiusVariance: 0.5),
                    new TimedTransition(10000, "OrbitBoss")
                    ),
                new State("OrbitBoss",

                      new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Orbit(.6, 4, target: "Jon Bilgewater the Pirate King", radiusVariance: 0.5),

                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 2000),
                    new TimedTransition(10000, "OrbitCage")

                      )
                  )
          )
          .Init("Deadwater Docks Parrot",
              new State(
                  new Prioritize(
                      new Wander(0.1)
                      ),
                  new State("Shoot",


                      new Shoot(radius: 7, projectileIndex: 0, predictive: 1, coolDown: 1500)
                      )
                  )
          )

          .Init("Deadwater Docks Lieutenant",
              new State(
                  new State("woot",
                      new Follow(1, 6, 1, -1, 0),
                      new Wander(0.8),
                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 1000)
                      )
                  )
          )
          .Init("Deadwater Docks Commander",
              new State(
                  new Prioritize(
                      new Wander(0.5),
                      new Follow(1, 6, 1, -1, 0)
                      ),
                      new Shoot(radius: 7, projectileIndex: 0, predictive: 1, coolDown: 1500)
                 )
          );
    }
}