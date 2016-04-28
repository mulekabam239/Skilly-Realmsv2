using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Pacman = () => Behav()
.Init("0B PacMan3",
                new State(
                    new DropPortalOnDeath("Glowing Realm Portal", 100, PortalDespawnTimeSec: 360),
                      new Prioritize(
                            new Follow(1.2, 14, 1)
                            ),
                    new State("default",
                        new PlayerWithinTransition(8, "basic")
                        ),
                    new State("basic",
                        new Shoot(25, projectileIndex: 0, coolDown: 900),
                        new Shoot(25, 2, projectileIndex: 1, coolDown: 1350),
                        new Shoot(25, 2, predictive: 1, projectileIndex: 2, coolDown: 1350)
                        )
                    ),
                //LootTemplates.DefaultEggLoot(EggRarity.Legendary),
               
                new Threshold(0.025,
                    new TierLoot(12, ItemType.Weapon, 0.1),
                    new TierLoot(6, ItemType.Ability, 0.1),
                    new TierLoot(12, ItemType.Armor, 0.1),
                    new TierLoot(6, ItemType.Ring, 0.05),
                    new TierLoot(13, ItemType.Armor, 0.05),
                    new TierLoot(12, ItemType.Weapon, 0.05),
                    new TierLoot(7, ItemType.Ring, 0.025),
                    new ItemLoot("Pacman Spell", 0.012),
                    new ItemLoot("Legendary Food", 0.09),
                    new ItemLoot("Pac Face", 0.007)
                )
            )
        .Init("0B PacMan2",
                  new State(
                       new Prioritize(
                            new Follow(1.2, 14, 1)
                            ),
                    new State("default",
                        new PlayerWithinTransition(8, "basic")
                        ),
                    new State("basic",

                        new Shoot(25, projectileIndex: 0, coolDown: 1250)
                )
            )
            )
                .Init("0B PacMan1",
                new State(
                       new Prioritize(
                            new Follow(1.2, 14, 1)
                            ),
                    new State("default",
                        new PlayerWithinTransition(8, "basic")
                        ),
                    new State("basic",

                        new Shoot(25, projectileIndex: 0, coolDown: 1250)


            )
          
                    )
            )
            ;
    }
}