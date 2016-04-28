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

        private _ LairofDraconisREd = () => Behav()
            .Init("NM Red Dragon God",
                new State(
                    new DropPortalOnDeath("Glowing Realm Portal", 100, PortalDespawnTimeSec: 360),

                    new OnDeathBehavior(new ApplySetpiece("RedDragonDeath")),
                    new TransformOnDeath("lod Red Loot Balloon", returnToSpawn: true),
                    new CopyDamageOnDeath("lod Red Loot Balloon"),
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
                        new TimedTransition(5000, "trlllll")
                            ),
                        new State("trlllll",


                        new Taunt("Ahh... Scrubs... You want to fight ME? Cute joke. Oh KAY!"),
                        new Shoot(10, count: 12, shootAngle: (float)(180 / 4), predictive: 0.7, coolDown: 1000),
                            
                        new Shoot(10, count: 12, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 16, shootAngle: (float)30, angleOffset: (float)-45, projectileIndex: 9, coolDown: 1000),
                        new Shoot(10, count: 6, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 0, coolDown: 1690),
                        new Shoot(10, count: 4, shootAngle: (float)30, angleOffset: (float)-45, projectileIndex: 9, coolDown: 2500),
                        new Shoot(10, count: 2, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 0, coolDown: 1255),
                        new Shoot(10, count: 8, shootAngle: (float)30, angleOffset: (float)-45, projectileIndex: 9, coolDown: 1255),
                        new HpLessTransition(0.9, "Ring_Attack")
                    ),
                    new State("Ring_Attack",
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 10)
                        ),
                        new Shoot(10, count: 5, projectileIndex: 5, coolDown: 5000),
                        new Shoot(10, count: 2, projectileIndex: 5, coolDown: 5000),
                        new Shoot(10, count: 9, projectileIndex: 10, coolDown: 3000),
                        new HpLessTransition(0.4, "StartTheFun")

                        
                    ),
                    new State("StartTheFun",

                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(true, 0, "I mean... Look... it was nice meeting you."),
                            
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
                                new Shoot(0, projectileIndex: 1, fixedAngle: 45),
                                new Shoot(0, projectileIndex: 2, fixedAngle: 135),
                            
                                new Shoot(0, projectileIndex: 3, fixedAngle: 225),
                                new Shoot(0, projectileIndex: 4, fixedAngle: 315),

                                new Shoot(0, projectileIndex: 5, fixedAngle: 60),
                                new Shoot(0, projectileIndex: 4, fixedAngle: 315),

                                new Shoot(0, projectileIndex: 5, fixedAngle: 60),

                                new Shoot(0, projectileIndex: 6, fixedAngle: 150),

                                new Shoot(0, projectileIndex: 6, fixedAngle: 150),
                                new TimedTransition(800, "shoot2")
                            ),
                            new State("shoot2",

                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                new HpLessTransition(0.2, "OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven"),
                                new Shoot(0, 6, shootAngle: 10, projectileIndex: 3, fixedAngle: 45),
                                new Shoot(0, 4, shootAngle: 10, projectileIndex: 10, fixedAngle: 135),
                                new Shoot(0, 8, shootAngle: 10, projectileIndex: 4, fixedAngle: 225),
                                new Shoot(0, 8, shootAngle: 10, projectileIndex: 4, fixedAngle: 225),
                                new Shoot(0, 12, shootAngle: 10, projectileIndex: 7, fixedAngle: 315),
                                new Shoot(0, 12, shootAngle: 10, projectileIndex: 7, fixedAngle: 315),
                                new TimedTransition(800, "shoot3")
                            ),
                            new State("shoot3",

                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                new HpLessTransition(0.2, "OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven"),
                                new Shoot(0, 5, shootAngle: 15, projectileIndex: 8, fixedAngle: 50),
                                new Shoot(0, 5, shootAngle: 15, projectileIndex: 10, fixedAngle: 40),
                                new Shoot(0, 5, shootAngle: 15, projectileIndex: 1, fixedAngle: 30),
                                new Shoot(0, 5, shootAngle: 15, projectileIndex: 1, fixedAngle: 30),
                                new Shoot(0, 5, shootAngle: 15, projectileIndex: 2, fixedAngle: 170),
                                new Shoot(0, 5, shootAngle: 15, projectileIndex: 2, fixedAngle: 170),
                                new TimedTransition(800, "shoot1")
                            )
                        )
                    ),
                    new State("OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven",
                        new Taunt(1, true, "So... Yeah... As I was saying... READY? FIRE!"),
                        new Shoot(10, count: 3, shootAngle: 15, predictive: 0.7, coolDown: 1000),
                        new State("shoot1",
                            new Shoot(0, 2, projectileIndex: 1, fixedAngle: 45),
                            new Shoot(0, 8,  projectileIndex: 1, fixedAngle: 135),
                            new Shoot(0, 10,  projectileIndex: 2, fixedAngle: 225),
                            new Shoot(0, 10, projectileIndex: 2, fixedAngle: 225),
                            new Shoot(0, 6, projectileIndex: 2, fixedAngle: 315),
                            new Shoot(0, 6, projectileIndex: 2, fixedAngle: 315),
                            new TimedTransition(1000, "shoot2")
                        ),
                        new State("shoot2",

                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, 4, shootAngle: 0, projectileIndex: 10, fixedAngle: 45),
                            new Shoot(0, 2, shootAngle: 15, projectileIndex: 10, fixedAngle: 135),
                            new Shoot(0, 8, shootAngle: 40, projectileIndex: 7, fixedAngle: 225),
                            new Shoot(0, 2, shootAngle: 15, projectileIndex: 7, fixedAngle: 315),
                            new Shoot(0, 8, shootAngle: 40, projectileIndex: 7, fixedAngle: 225),
                            new Shoot(0, 2, shootAngle: 15, projectileIndex: 7, fixedAngle: 315),
                            new TimedTransition(1000, "shoot1")
                        )
                    )
                )
            )
            
            .Init("lod Red Loot Balloon",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new Threshold(0.1,
                    new ItemLoot("Fire Dragon Battle Armor", 0.012),
                    new ItemLoot("Potion of Life", 0.3),
                    new ItemLoot("Potion of Defense", 0.3),
                    new ItemLoot("Potion of Vitality", 0.3), 
                    new ItemLoot("Wonderful Spined Knife", 0.012),
                    new ItemLoot("Chaotic Thunderous Sword", 0.012),
                    new ItemLoot("Abyssimal Glowing Hatchet", 0.012),
                    new ItemLoot("Rich Food", 0.2),
                    new ItemLoot("Potion of Attack", 0.3),
                    new ItemLoot("Midnight Star", 0.007)
                )
            );
    }
}
