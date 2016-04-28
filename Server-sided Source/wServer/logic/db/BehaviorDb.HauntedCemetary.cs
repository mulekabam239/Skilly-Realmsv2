using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Cemetary = () => Behav()
            .Init("Skuld Summoner",
                new State(
                    

                new TransformOnDeath("Ghost of Skuld"),
                    
                    new State("default",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ChangeSize(-20, 100),
                        new PlayerWithinTransition(100, "defaultz")
                        ),
                     new State("defaultz",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ChangeSize(-20, 100),
                        new TimedTransition(5000, "basic")
                        ),
                    new State("basic",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        
                        new Taunt("Welcome to my domain. I challenge you, warrior, to defeat my undead horders and claim your prize..."),
                        new Taunt(1, 7000, "Say, 'READY'when you are ready to face your opponents."),

                        new ChatTransition("state1", "READY"),
                        new ChatTransition("state1", "ready")
                        ),
                    new State("state1",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2500, "state2")
                        ),
                    new State("state2",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                         new TimedTransition(5000, "wait1")

                        
                        ),
                                        new State("wait1",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Skeleton", 6500, "state3")
                        ),
                    new State("state3",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        new Taunt("Next wave shall begin..."),
                        new TimedTransition(5000, "state4")
                        ),
                    new State("state4",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        

                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),

                         new TimedTransition(5000, "wait2")

                        ),
                    new State("wait2",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Skeleton", 6500, "state5")
                        ),
                                        new State("state5",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        

                        new Taunt("Next wave shall begin..."),
                        new TimedTransition(5000, "state6")
                        ),
                                                            new State("state6",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        

                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),

                        new TimedTransition(5000, "wait3")
                        ),
                                                              new State("wait3",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Skeleton", 6500, "state7")
                        ),

                    new State("state7",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        

                        new Taunt("Next wave shall begin..."),
                        new TimedTransition(5000, "state8")
                        ),
                                                                                new State("state8",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        

                                                        new TossObject("Troll 3", 4, 0, coolDown: 9999999, randomToss: true),

                        new TimedTransition(5000, "wait4")
                        ),
                                                                                new State("wait4",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Troll 3", 6500, "state9")
                        ),

                       new State("state9",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        
                        new Taunt("Congratulations making it past the first area, this one won't be as easy!"),

                        new TimedTransition(2000, "state10")

                        ),
                                           new State("state10",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        
                        new Taunt(1, 7000, "Say, 'READY'when you are ready to face your opponents."),
                        new ChatTransition("state11", "READY"),
                        new ChatTransition("state11", "ready")
                        ),
                                                            new State("state11",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),


                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),

                        new TimedTransition(5000, "wait5")

                        ),
                                                            new State("wait5",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Skeleton", 6500, "state12")
                        ),
                                        new State("state12",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        

                        new Taunt("Next wave shall begin..."),
                        new TimedTransition(5000, "state13")
                        ),
                                                                                                    new State("state13",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        

                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),

                        new TimedTransition(5000, "wait6")
                        ),
                                                                                                          new State("wait6",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Skeleton", 6500, "state14")
                        ),
                  new State("state14",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        

                        new Taunt("Next wave shall begin..."),
                        new TimedTransition(5000, "state15")
                        ),
                            new State("state15",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        

                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TimedTransition(5000, "wait7")

                        ),
                            new State("wait7",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Skeleton", 6500, "state16")
                        ),
                                                new State("state16",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        

                        new Taunt("Next wave shall begin..."),
                        new TimedTransition(5000, "state17")
                        ),
                                                                                new State("state17",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        

                                                       new TossObject("Arena Ghost Bride", 4, 0, coolDown: 9999999, randomToss: true),
                        new TimedTransition(5000, "wait8")

                        ),
                                                                                                            new State("wait8",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Ghost Bride", 6500, "state18")
                        ),
new State("state18",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        
                        new Taunt("Well... Quite suprising you got this far."),

                        new TimedTransition(2000, "state19")

                        ),
                                           new State("state19",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        new Taunt(1, 7000, "Say, 'READY'when you are ready to face your opponents."),
                        new ChatTransition("state20", "READY"),
                        new ChatTransition("state20", "ready")
                        ),
                                                            new State("state20",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        

                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),


                        new TimedTransition(5000, "wait9")

                        ),
                                                                                        new State("wait9",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Skeleton", 6500, "state22")
                        ),
                                        new State("state22",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        

                        new Taunt("Next wave shall begin..."),
                        new TimedTransition(5000, "state23")
                        ),
                                                                                                    new State("state23",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),

                        new TimedTransition(5000, "wait10")
                        ),
      new State("wait10",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Skeleton", 6500, "state24")
                        ),
                  new State("state24",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        

                        new Taunt("Next wave shall begin..."),
                        new TimedTransition(5000, "state25")
                        ),
                            new State("state25",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),


                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TimedTransition(5000, "wait11")

                        ),
                                  new State("wait11",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Skeleton", 6500, "state26")
                        ),
                                                new State("state26",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        

                        new Taunt("Next wave shall begin..."),
                        new TimedTransition(5000, "state27")
                        ),
                                                                                new State("state27",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        

                                                       new TossObject("Arena Grave Caretaker", 4, 0, coolDown: 9999999, randomToss: true),

                        new TimedTransition(5000, "wait12")
                        ),
                                                                                 new State("wait12",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Grave Caretaker", 6500, "state28")
                        ),

new State("state28",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        
                        new Taunt("Good achivment, lets see how far you will get on with this one!"),

                        new TimedTransition(2000, "state29")

                        ),
                                           new State("state29",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt(1, 7000, "Say, 'READY'when you are ready to face your opponents."),
                        new ChatTransition("state30", "READY"),
                        new ChatTransition("state30", "ready")
                        ),
                                                            new State("state30",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        

                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),

                        new TimedTransition(5000, "wait13")
                        ),
                                                            new State("wait13",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Skeleton", 6500, "state31")
                        ),
                                        new State("state31",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        

                        new Taunt("Next wave shall begin..."),
                        new TimedTransition(5000, "state32")
                        ),
                                                                                                    new State("state32",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        

                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TimedTransition(5000, "wait14")
                        ),
                                                                                                    new State("wait14",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Skeleton", 6500, "state33")
                        ),
                  new State("state33",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        

                        new Taunt("Next wave shall begin..."),
                        new TimedTransition(5000, "state34")
                        ),
                            new State("state34",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),


                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),
                        new TossObject("Arena Skeleton", 5, 0, coolDown: 9999999, randomToss: true),

                        new TimedTransition(5000, "wait15")
                        ),
                            new State("wait15",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("Arena Skeleton", 6500, "state35")
                        ),

                                                new State("state35",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        

                        new Taunt("Congratulations on your victory, warrior! Your reward shall be..."),
                        new TimedTransition(5000, "state36")
                        ),
                                                                                new State("state36",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        new ChangeSize(35, 125),

                        new Taunt("A SWIFT DEATH!"),

                        new TimedTransition(1250, "suicide")

                        ),

                        new State("suicide",
                        new Suicide()
                                                                                    
                            )
            )

            )
         
   
                    
           .Init("Ghost of Skuld",
            new State(
                    new DropPortalOnDeath("Glowing Realm Portal", 100, PortalDespawnTimeSec: 360),


                new State("Woho",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new ChangeSize(-20, 135),

                        new Shoot(10, count: 4, shootAngle: (float)(180 / 4), predictive: 0.7, projectileIndex: 2, coolDown: 2500),
                        new Shoot(10, count: 14, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 8, shootAngle: (float)30, angleOffset: (float)-45, projectileIndex: 1, coolDown: 5000)
                        )


                    ),
                //LootTemplates.DefaultEggLoot(EggRarity.Legendary),
                new MostDamagers(3,
                    new ItemLoot("Potion of Vitality", 1.0)
                ),
                new MostDamagers(1,
                    new ItemLoot("Potion of Wisdom", 1.0)
                ),
                new Threshold(0.025,
                    new TierLoot(9, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(10, ItemType.Armor, 0.05),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Amulet of Resurrection", 0.012),

                    new ItemLoot("Lime Forged Ring", 0.012),

                    new ItemLoot("Diamond Forged Ring", 0.012),

                    new ItemLoot("Captain America's Ring", 0.012),
                    new ItemLoot("Ultra Dagger", 0.012),
                    new ItemLoot("Plague Poison", 0.012),
                    new ItemLoot("Resurrected Warrior's Armor", 0.007)
                    )
                )
        
        
        .Init("Arena Ghost Bride",
                new State(
                        new Prioritize(
                            new Follow(0.3)
                            ),

                    new State("fight",
                        new ChangeSize(-20, 135),

                        new Shoot(10, count: 2, shootAngle: (float)(180 / 4), predictive: 0.3, projectileIndex: 1, coolDown: 2300),
                        new Shoot(10, count: 14, shootAngle: (float)45, projectileIndex: 0, coolDown: 1110)
                        )
                    ),
                //LootTemplates.DefaultEggLoot(EggRarity.Legendary),
                new MostDamagers(3,
                    new ItemLoot("Potion of Wisdom", 1.0)
                ),
                new MostDamagers(1,
                    new ItemLoot("Potion of Speed", 1.0)
                ),
                new Threshold(0.025,
                    new TierLoot(9, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(10, ItemType.Armor, 0.05),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Nostalgia Tome", 0.012),
                    new ItemLoot("Ender Scepter", 0.012),
                    new ItemLoot("Sky Prism", 0.012),
                    new ItemLoot("Amulet of Resurrection", 0.01)
                    )
            )
                .Init("Arena Grave Caretaker",
                new State(
                        new Prioritize(
                            new Wander(0.2)
                            ),

                    new State("fight",

                        new Shoot(10, count: 1, shootAngle: (float)(180 / 4), predictive: 0.7, projectileIndex: 1, coolDown: 2500),
                        new Shoot(10, count: 3, projectileIndex: 0, coolDown: 890)
                        )
                    ),
                //LootTemplates.DefaultEggLoot(EggRarity.Legendary),
                new MostDamagers(3,
                    new ItemLoot("Potion of Wisdom", 1.0)
                ),
                new MostDamagers(1,
                    new ItemLoot("Potion of Speed", 1.0)
                ),
                new Threshold(0.025,
                    new TierLoot(9, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(10, ItemType.Armor, 0.05),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Medium Food", 0.2),
                    new ItemLoot("Hades Orb", 0.012),
                    new ItemLoot("Limited-Edition Seal", 0.012),
                    new ItemLoot("Golden Poison", 0.012),
                    new ItemLoot("Flame Shield", 0.012),
                    new ItemLoot("Amulet of Resurrection", 0.007)
                    )
            )
        .Init("Troll 3",
                new State(
                        new Prioritize(
                            new Follow(0.1),
                            new Wander(0.2)
                            ),

                    new State("fight",

                        new Shoot(10, count: 2, shootAngle: (float)(180 / 4), predictive: 0.7, projectileIndex: 0, coolDown: 900),
                        new Shoot(10, count: 8, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 1, coolDown: 2500)
                        )
                    ),
                //LootTemplates.DefaultEggLoot(EggRarity.Legendary),
                new MostDamagers(3,
                    new ItemLoot("Potion of Wisdom", 1.0)
                ),
                new MostDamagers(1,
                    new ItemLoot("Potion of Speed", 1.0)
                ),
                new Threshold(0.025,
                    new TierLoot(9, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(10, ItemType.Armor, 0.05),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Hades Helm", 0.012),
                    new ItemLoot("Robotic Spell", 0.012),
                    new ItemLoot("Canna Skull", 0.012),
                    new ItemLoot("Chaos Trap", 0.012),
                    new ItemLoot("Frost Cloak", 0.012),
                    new ItemLoot("Amulet of Resurrection", 0.007)
                    )
            )

                    .Init("Arena Skeleton",
                new State(
                    new Wander(0.875),
                    new Shoot(8, 3, 10, coolDown: 1250)
                    

                    
            
                    )
            )
            ;
    }
}