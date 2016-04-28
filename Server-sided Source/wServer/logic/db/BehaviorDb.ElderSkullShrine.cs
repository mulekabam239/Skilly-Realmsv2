

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;



namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ ElderSkullShrine = () => Behav()
           

            .Init("Elder Skull Shrine",
                new State(
                    new DropPortalOnDeath("Glowing Realm Portal", 100, PortalDespawnTimeSec: 360),
                    new Shoot(25, 9, 10, predictive: 1),
                    new Spawn("Elder Red Flaming Skull", 8, coolDown: 5000),
                    new Spawn("Elder Blue Flaming Skull", 10, coolDown: 1000),
                    new Reproduce("Elder Red Flaming Skull", 10, 8, 5000),
                    new Reproduce("Elder Blue Flaming Skull", 10, 10, 1000)
                ),
                new MostDamagers(3,
                    LootTemplates.StatIncreasePotionsLoot()
                ),
                new Threshold(0.05,
                    new TierLoot(9, ItemType.Weapon, 0.2),
                    new TierLoot(10, ItemType.Weapon, 0.03),
                    new TierLoot(11, ItemType.Weapon, 0.02),
                    new TierLoot(12, ItemType.Weapon, 0.01),
                    new TierLoot(5, ItemType.Ring, 0.2),
                    new TierLoot(6, ItemType.Ring, 0.05),
                    new TierLoot(7, ItemType.Ring, 0.01),
                    new TierLoot(9, ItemType.Armor, 0.2),
                    new TierLoot(10, ItemType.Armor, 0.1),
                    new TierLoot(11, ItemType.Armor, 0.03),
                    new TierLoot(12, ItemType.Armor, 0.02),
                    new TierLoot(13, ItemType.Armor, 0.01),
                    new TierLoot(5, ItemType.Ability, 0.1),
                    new ItemLoot("Legendary Food", 0.09),
                    new TierLoot(6, ItemType.Ability, 0.03)
                )
            )
            .Init("Elder Red Flaming Skull",
                new State(


                    new EntityNotExistsTransition("Elder Skull Shrine", 100, "Despawn"),
                    new Prioritize(
                        new Wander(.6),
                        new Follow(.6, 20, 3)
                        ),
                    new State("lol",
                        new State("ntykid",
                    new Shoot(15, 2, 5, 0, predictive: 1, coolDown: 750)
                            )
                ),



                new State("Despawn",
                        new Timed(1000, new Suicide())
                    )
                )
            )


            .Init("Elder Blue Flaming Skull",
                new State(
                    new EntityNotExistsTransition("Elder Skull Shrine", 100, "Despawn"),
                    new Prioritize(
                        new Orbit(1, 20, target: "Skull Shrine", radiusVariance: 0.5),
                        new Wander(.6)
                        ),
                    new State("lol",
                        new State("ntykid",
                    new Shoot(15, 2, 5, 0, predictive: 1, coolDown: 750))
                ),



                new State("Despawn",
                        new Timed(1000, new Suicide())
                    )
                
            
                    
            

           
           
                )
            );
    }
}
