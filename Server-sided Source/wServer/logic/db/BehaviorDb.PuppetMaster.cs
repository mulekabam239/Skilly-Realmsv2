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

        private _ PuppetMaster = () => Behav()
            .Init("The Puppet Master",
                new State(
                    new DropPortalOnDeath("Glowing Realm Portal", 100, PortalDespawnTimeSec: 360),
                                         new Prioritize(
                            new Follow(.4, 14, 1)
                            ),
                    new TransformOnDeath("Puppet Loot Chest", returnToSpawn: true),
                    new CopyDamageOnDeath("Puppet Loot Chest"),
                    //new Taunt(new string[3]
                    //{
                    //    "Start",
                    //    "Ring_Attack",
                    //    "Ring_Attack2"
                    //},
                    //text: "You are nothing more than nutiment for my roots.", cooldown: 15000),

                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(8, "Idle2")
                    ),
                    new State("Idle2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Well Well... You caught me..."),

                        new TimedTransition(5000, "Idle3")
                    ), 
                    new State("Idle3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("What now?"),

                        new TimedTransition(5000, "Idle4")
                    ), 
                    new State("Idle4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Oh well... It's time for you too..."),

                        new TimedTransition(5000, "Start")
                    ),
                    new State("Start",


                        new Taunt("DIEEE"),
                        new Shoot(10, count: 12, shootAngle: (float)(180 / 4), predictive: 0.7, coolDown: 1000),
                        new Shoot(10, count: 7, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 1, coolDown: 1000),
                        new Shoot(10, count: 16, shootAngle: (float)30, angleOffset: (float)-45, projectileIndex: 2, coolDown: 1000),
                        new HpLessTransition(0.9, "Ring_Attack")
                    ),
                    new State("Ring_Attack",
                        new Shoot(10, count: 12, projectileIndex: 1, coolDown: 5000),
                        new Shoot(10, count: 12, projectileIndex: 3, coolDown: 3000),
                        new HpLessTransition(0.4, "StartTheFun")

                        
                    ),
                    new State("StartTheFun",
                        new Taunt(true, 0, "You will be avenged..."),
                        new ReturnToSpawn(speed: 1),
                        new TimedTransition(5000, "RAGE_MODE")
                    ),
                    new State("RAGE_MODE",
                        new State("Everything_is_cool",
                            new State("spawn_minions",
                                new HpLessTransition(0.2, "OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven"),
                              
                                new TimedTransition(0, "shoot1")
                            ),
                            new State("shoot1",
                                new HpLessTransition(0.2, "OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven"),
                                new Shoot(10, projectileIndex: 3, fixedAngle: 45),
                                new Shoot(8, projectileIndex: 0, fixedAngle: 135),
                                new Shoot(10, projectileIndex: 2, fixedAngle: 225),
                                new Shoot(10, projectileIndex: 1, fixedAngle: 315),
                                new TimedTransition(800, "shoot2")
                            ),
                            new State("shoot2",
                                new HpLessTransition(0.2, "OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven"),
                                new Shoot(10, 3, shootAngle: 10, projectileIndex: 3, fixedAngle: 45),
                                new Shoot(10, 2, shootAngle: 10, projectileIndex: 2, fixedAngle: 135),
                                new Shoot(10, 4, shootAngle: 10, projectileIndex: 1, fixedAngle: 225),
                                new Shoot(10, 6, shootAngle: 10, projectileIndex: 3, fixedAngle: 315),
                                new TimedTransition(800, "shoot3")
                            ),
                            new State("shoot3",
                                new HpLessTransition(0.2, "OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven"),
                                new Shoot(10, 6, shootAngle: 15, projectileIndex: 3, fixedAngle: 45),
                                new Shoot(10, 2, shootAngle: 15, projectileIndex: 0, fixedAngle: 135),
                                new Shoot(10, 6, shootAngle: 15, projectileIndex: 0, fixedAngle: 225),
                                new Shoot(10, 13, shootAngle: 15, projectileIndex: 2, fixedAngle: 315),
                                new TimedTransition(800, "shoot1")
                            )
                        )
                    ),
                    new State("OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven",
                        new Taunt(1, true, "By my encore!"),
                        new Shoot(10, count: 3, shootAngle: 15, predictive: 0.7, coolDown: 1000),
                        new State("shoot1",
                            new Shoot(0, projectileIndex: 1, fixedAngle: 45),
                            new Shoot(0, projectileIndex: 2, fixedAngle: 135),
                            new Shoot(0, projectileIndex: 3, fixedAngle: 225),
                            new Shoot(0, projectileIndex: 2, fixedAngle: 315),
                            new TimedTransition(1000, "shoot2")
                        ),
                        new State("shoot2",
                            new Shoot(0, 4, shootAngle: 0, projectileIndex: 3, fixedAngle: 45),
                            new Shoot(0, 1, shootAngle: 15, projectileIndex: 0, fixedAngle: 135),
                            new Shoot(0, 3, shootAngle: 40, projectileIndex: 3, fixedAngle: 225),
                            new Shoot(0, 1, shootAngle: 15, projectileIndex: 0, fixedAngle: 315),
                            new TimedTransition(1000, "shoot1")
                        )
                    )
                )
            )
            
            .Init("Puppet Loot Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new Threshold(0.1,
                    new ItemLoot("Prism Of Dancing Swords", 0.4),
                    new ItemLoot("Potion of Attack", 1.0),
                    new ItemLoot("Cudgel of Secrecy", 0.012),
                    new ItemLoot("Spectral Focus", 0.012),
                    new ItemLoot("Wand of Rosewood", 0.012),
                    new ItemLoot("Rich Food", 0.05),
                    new ItemLoot("Etherite Dagger", 0.003),
                    new ItemLoot("Ghastly Drape", 0.003),
                    new ItemLoot("Mantle of Skuld", 0.003),
                    new ItemLoot("Spectral Ring of Horrors", 0.003),
                    new ItemLoot("Possessed Chalice", 0.012),
                    new ItemLoot("Harlequin Armor", 0.007)
                )
            );
    }
}
