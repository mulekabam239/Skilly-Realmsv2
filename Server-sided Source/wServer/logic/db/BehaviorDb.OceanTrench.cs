using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ OceanTrench = () => Behav()
            .Init("Thessal the Mermaid Goddess",
                new State(
                    new DropPortalOnDeath("Glowing Realm Portal", 100, PortalDespawnTimeSec: 360),
                    new State("default",
                        new PlayerWithinTransition(8, "basic")
                        ),
                    new State("basic",
                        new Shoot(10, count: 4, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 0, coolDown: 1700),

                        new Shoot(10, count: 8, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 3, coolDown: 2700),

                        new Shoot(10, count: 12, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 1, coolDown: 3700),

                        new Shoot(10, count: 16, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 2, coolDown: 4700)
                        )

                    ),
                //LootTemplates.DefaultEggLoot(EggRarity.Legendary),
                new MostDamagers(3,
                    new ItemLoot("Potion of Mana", 1.0)

                ),
                new Threshold(0.025,
                    new ItemLoot("Coral Bow", 0.05),

                    new ItemLoot("Coral Venom Trap", 0.08),

                    new ItemLoot("Coral Silk Armor", 0.05),
                    new ItemLoot("Amazonia Quiver", 0.012),
                    new ItemLoot("The Phylactery", 0.003),
                    new ItemLoot("Soulless Robe", 0.003),
                    new ItemLoot("Soul of the Bearer", 0.003),
                    new ItemLoot("Ring of the Covetous Heart", 0.003),
                    new ItemLoot("Ring of Ooze Ring", 0.012),
                    new ItemLoot("Legendary Food", 0.09),
                    new ItemLoot("Crown of Fish Killing", 0.012),

                    new ItemLoot("Coral Ring", 0.08)
                )
            )

            .Init("Deep Sea Beast",
                new State(
                    new Shoot(8, 5, 10, coolDown: 1000)

                    )
            )
            .Init("Fishman",
                new State(
                    new Prioritize(
                        new Follow(1, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, coolDown: 1000)

                    )
            )
            .Init("Sea Horse",
                new State(
                    new Prioritize(
                        new Follow(1, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 1, shootAngle: 10, coolDown: 1000)
                    )
            )
            .Init("Grey Sea Slurp",
                new State(
                    new Prioritize(
                        new Follow(1, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, coolDown: 1000)

                    )
            )
        .Init("Sea Slurp Home",
new State(
                    new State("default",
                        new PlayerWithinTransition(4, "basic")
                        ),
                    new State("basic",
new Reproduce("Grey Sea Slurp", densityMax: 1, spawnRadius: 1, coolDown: 1000)


                    )

                    )
            )
        .Init("Sea Mare",
                new State(
                    new Prioritize(
                        new Follow(1, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, coolDown: 1000),

                    new Shoot(8, 2, shootAngle: 10, projectileIndex: 1, coolDown: 1000)

                    )
            )
            .Init("Ink Bubble",
                new State(
                    new Prioritize(
                        new Follow(1.5, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, coolDown: 500)
                    ),
                new ItemLoot("GoSnoopyHP", 0.1),
                new Threshold(0.1,
                    new ItemLoot("Obsidian Dagger", 0.012),
                    new ItemLoot("Steel Helm", 0.02)
                    )
            )
            .Init("Giant Squid",
                new State(
                    new Prioritize(

                        new Follow(1.5, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, coolDown: 500)
                    
                    )
            )
            ;
    }
}