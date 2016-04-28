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
        private _ CandyLand = () => Behav()
        .Init("Candy Gnome",
            new State(
                new DropPortalOnDeath("Candyland Portal", percent: 50, PortalDespawnTimeSec: 120),
                new Prioritize(
                    new StayBack(1.5, 55),
                    new Wander(1.4)
                    )
                ),
            new Threshold(0.18,
                new ItemLoot("Red Gumball", 0.5),
                new ItemLoot("Purple Gumball", 0.5),
                new ItemLoot("Blue Gumball", 0.5),
                new ItemLoot("Green Gumball", 0.5),
                new ItemLoot("Yellow Gumball", 0.5)
                )
            )
            .Init("Desire Troll",
                new State(
                    new Wander(0.5),
                    new Grenade(6, 200, range: 8, coolDown: 3000),
                    new Shoot(15, 3, 5, angleOffset: 30 / 3, projectileIndex: 0, coolDown: 2100),
                    new Shoot(15, 5, 10, angleOffset: 60 / 3, projectileIndex: 2, coolDown: 1950),
                    new Shoot(15, 1, 0, angleOffset: 30 / 3, projectileIndex: 1, coolDown: 1950)
                ),
                new TierLoot(6, ItemType.Weapon, 0.04),
                new TierLoot(7, ItemType.Weapon, 0.02),
                new TierLoot(8, ItemType.Weapon, 0.01),
                new TierLoot(7, ItemType.Armor, 0.04),
                new TierLoot(8, ItemType.Armor, 0.02),
                new TierLoot(9, ItemType.Armor, 0.01),
                new TierLoot(3, ItemType.Ring, 0.015),
                new TierLoot(4, ItemType.Ring, 0.005),
                new Threshold(0.18,
                    new ItemLoot("Potion of Defense", 0.012),
                    new ItemLoot("Potion of Attack", 0.012),
                    new ItemLoot("Yellow Gumball", 0.3),
                    new ItemLoot("Green Gumball", 0.3),
                    new ItemLoot("Blue Gumball", 0.3),
                    new ItemLoot("Red Gumball", 0.3),
                    new ItemLoot("Blue Gumball", 0.3),
                    new ItemLoot("Fairy Plate", 0.009),
                    new ItemLoot("Rich Food", 0.2),
                    new ItemLoot("Pixie-Enchanted Sword", 0.009),
                    new ItemLoot("Seal of the Enchanted Forest", 0.009),
                    new ItemLoot("Candy-Coated Armor", 0.01),
                    new ItemLoot("Wine Cellar Incantation", 0.01),
                    new ItemLoot("Ring of Pure Wishes", 0.009),
                    new ItemLoot("Potion of Attack", 0.005),
                    new ItemLoot("Potion of Wisdom", 0.005)
                )
            )
            .Init("Gigacorn",
                new State(
                    new Wander(0.5),
                    new Charge(2.0, 10f, 4000),
                    new Shoot(20, 1, 40, angleOffset: 60 / 3, projectileIndex: 0, coolDown: 2100),
                    new Shoot(20, 1, 40, angleOffset: 60 / 3, projectileIndex: 0, coolDown: 2200),
                    new Shoot(20, 1, 40, angleOffset: 60 / 3, projectileIndex: 0, coolDown: 2300),
                    new Shoot(20, 1, 40, angleOffset: 60 / 3, projectileIndex: 0, coolDown: 2400),
                    new Shoot(20, 3, 15, angleOffset: 40 / 3, projectileIndex: 1, coolDown: 4000),
                    new Shoot(20, 3, 15, angleOffset: 20 / 3, projectileIndex: 1, coolDown: 2000)
                ),
                new TierLoot(6, ItemType.Weapon, 0.04),
                new TierLoot(7, ItemType.Weapon, 0.02),
                new TierLoot(8, ItemType.Weapon, 0.01),
                new TierLoot(7, ItemType.Armor, 0.04),
                new TierLoot(8, ItemType.Armor, 0.02),
                new TierLoot(9, ItemType.Armor, 0.01),
                new TierLoot(3, ItemType.Ring, 0.015),
                new TierLoot(4, ItemType.Ring, 0.005),
                new Threshold(0.18,
                    new ItemLoot("Potion of Defense", 0.012),
                    new ItemLoot("Potion of Attack", 0.012),
                    new ItemLoot("Yellow Gumball", 0.3),
                    new ItemLoot("Green Gumball", 0.3),
                    new ItemLoot("Blue Gumball", 0.3),
                    new ItemLoot("Red Gumball", 0.3),
                    new ItemLoot("Rich Food", 0.2),
                    new ItemLoot("Blue Gumball", 0.3),
                    new ItemLoot("Fairy Plate", 0.012),
                    new ItemLoot("Pixie-Enchanted Sword", 0.012),
                    new ItemLoot("Seal of the Enchanted Forest", 0.012),
                    new ItemLoot("Candy-Coated Armor", 0.012),
                    new ItemLoot("Wine Cellar Incantation", 0.01),
                    new ItemLoot("Ring of Pure Wishes", 0.012),
                    new ItemLoot("Potion of Defense", 0.005)
                )
            )
                .Init("Unicorn",
                new State(
                    new Wander(0.5),
                    new Charge(2.0, 10f, 4000),
                    new Shoot(20, 1, 40, angleOffset: 60 / 3, projectileIndex: 0, coolDown: 2100),
                    new Shoot(20, 1, 40, angleOffset: 60 / 3, projectileIndex: 0, coolDown: 2300),
                    new Shoot(20, 1, 40, angleOffset: 60 / 3, projectileIndex: 0, coolDown: 2400),
                    new Shoot(20, 3, 15, angleOffset: 40 / 3, projectileIndex: 1, coolDown: 4000)
                
                )
            )
            .Init("Spoiled Creampuff",
                new State(
                    new Shoot(20, 2, 40, angleOffset: 60 / 3, projectileIndex: 0, coolDown: 1500),
                    new Shoot(20, 4, 15, angleOffset: 40 / 3, projectileIndex: 1, coolDown: 1000),
                    new Spawn("Big Creampuff", maxChildren: 2, initialSpawn: 2, coolDown: 5000)
                ),
                new TierLoot(6, ItemType.Weapon, 0.04),
                new TierLoot(7, ItemType.Weapon, 0.02),
                new TierLoot(8, ItemType.Weapon, 0.01),
                new TierLoot(7, ItemType.Armor, 0.04),
                new TierLoot(8, ItemType.Armor, 0.02),
                new TierLoot(9, ItemType.Armor, 0.01),
                new TierLoot(3, ItemType.Ring, 0.015),
                new TierLoot(4, ItemType.Ring, 0.005),
                new Threshold(0.18,
                    new ItemLoot("Potion of Defense", 0.012),
                    new ItemLoot("Potion of Attack", 0.012),
                    new ItemLoot("Yellow Gumball", 0.3),
                    new ItemLoot("Rich Food", 0.2),
                    new ItemLoot("Green Gumball", 0.3),
                    new ItemLoot("Blue Gumball", 0.3),
                    new ItemLoot("Red Gumball", 0.3),
                    new ItemLoot("Blue Gumball", 0.3),
                    new ItemLoot("Fairy Plate", 0.009),
                    new ItemLoot("Pixie-Enchanted Sword", 0.009),
                    new ItemLoot("Seal of the Enchanted Forest", 0.009),
                    new ItemLoot("Candy-Coated Armor", 0.01),
                    new ItemLoot("Ring of Pure Wishes", 0.009),
                    new ItemLoot("Potion of Defense", 0.005)
                )
            )
        .Init("Big Creampuff",
                new State(
                    new EntityNotExistsTransition("Unicorn", 100, "Despawn"),
                    new State("lol",
                        new State("ntykid",
                             new Wander(0.5),

                    new Spawn("Small Creampuff", maxChildren: 2, initialSpawn: 0.5, coolDown: 5000),
                    new Shoot(20, 1, 0, angleOffset: 40 / 3, projectileIndex: 0, coolDown: 1000))

                    ),



                new State("Despawn",
                        new Timed(1000, new Suicide())
                    )
                )
            )

        .Init("Cupcake",
                new State(
                    new Wander(0.2),
                    new Shoot(20, 4, 0, angleOffset: 40 / 3, projectileIndex: 0, coolDown: 2500)
                )
            )
                 .Init("0CCANDYSPAWNERMINION",
            new State(
                new State("OneMinute",
                    new TimedTransition(2000, "waiting")
                    ),

                new State("waiting",

                   new EntitiesNotExistsTransition(1000, "2min", "Desire Troll", "Gigacorn", "Spoiled Creampuff")
                    ),
                new State("2min",
                    new TimedTransition(1000, "NaeNae")
                    ),

                new State("NaeNae",
                   
                        new InvisiToss("Unicorn", 2, 350, coolDown: 9999999),
                        new InvisiToss("Tiny Rototo", 2, 250, coolDown: 9999999),
                        new InvisiToss("Big Creampuff", 2, 250, coolDown: 9999999),
                    new TimedTransition(1000, "FORREAL")
                    ),
                new State("FORREAL",
                    

                    new EntityNotExistsTransition("Unicorn", 1000, "ORDERITNOW")
                        ),
                    new State("ORDERITNOW",
                        new Order(1000, "0CCANDYSPAWNERBOSS", "BOSS1"),
                        new TimedTransition(0, "huehue")
                        ),
                    new State("huehue",
                        new InvisiToss("Unicorn", 2, 350, coolDown: 9999999),
                        new InvisiToss("Tiny Rototo", 2, 250, coolDown: 9999999),
                        new InvisiToss("Big Creampuff", 2, 250, coolDown: 9999999),
                    new TimedTransition(1000, "FORREAL2")
                        ),
                    new State("FORREAL2",

                    new EntityNotExistsTransition("Unicorn", 1000, "ORDERITNOW2")
                        ),
                        new State("ORDERITNOW2",
                        new Order(1000, "0CCANDYSPAWNERBOSS", "BOSS2"),
                        new TimedTransition(0, "huehue2")
                            ),
                         new State("huehue2",
                        new InvisiToss("Unicorn", 2, 350, coolDown: 9999999),
                        new InvisiToss("Tiny Rototo", 2, 250, coolDown: 9999999),
                        new InvisiToss("Big Creampuff", 2, 250, coolDown: 9999999),
                    new TimedTransition(1000, "FORREAL3")
                             ),

                    new State("FORREAL3",

                    new EntityNotExistsTransition("Unicorn", 1000, "ORDERITNOW3")
                        ),
                     new State("ORDERITNOW3",
                        new Order(1000, "0CCANDYSPAWNERBOSS", "BOSS3"),
                        new TimedTransition(0, "OneMinute")
                            

                        )

                    
                
            )
                )
          .Init("0CCANDYSPAWNERBOSS",
            new State(
                new State("IDLE",
                    new TimedTransition(2500, "IDLE")
                    ),
                new State("BOSS1",
                    
                        new InvisiToss("Gigacorn", 0, 250, coolDown: 9999999),
                    new TimedTransition(1000, "IDLE")
                    ),
                new State("BOSS2",
                        new InvisiToss("Desire Troll", 0, 250, coolDown: 9999999),
                    new TimedTransition(1000, "IDLE")
                    ),
                new State("BOSS3",
                        new InvisiToss("Spoiled Creampuff", 0, 250, coolDown: 9999999),
                    new TimedTransition(1000, "IDLE")


                    )

            )
                )

                       .Init("Tiny Rototo",
                new State(
                    new EntityNotExistsTransition("Unicorn", 100, "Despawn"),
                    new State("lol",
                        new State("ntykid",
                             new Wander(0.4),
                    new Shoot(20, 2, 0, angleOffset: 40 / 3, projectileIndex: 0, coolDown: 1900))

                    ),



                new State("Despawn",
                        new Timed(1000, new Suicide())
                    )
                )
            )
        .Init("Small Creampuff",
                new State(
                    new EntityNotExistsTransition("Unicorn", 100, "Despawn"),
                    new State("lol",
                        new State("ntykid",
                             new Wander(0.3),

                    new Shoot(20, 3, 30, angleOffset: 40 / 3, projectileIndex: 1, coolDown: 1400))

                    ),



                new State("Despawn",
                        new Timed(1000, new Suicide())
                    )
                )
            );
    }
}
