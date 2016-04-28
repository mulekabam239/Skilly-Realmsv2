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

        private _ ChaosOverlord = () => Behav()
            .Init("0A Overlord",
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
                        new TimedTransition(5000, "trlllll")
                            ),
                        new State("trlllll",

                        new Taunt("Welcome champion, you should face your worse fears..."),
                        

                            new Shoot(12, count: 5, shootAngle: (float)(180 / 4), predictive: 0.7, coolDown: 1500),
                        new Shoot(12, count: 3, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 3, coolDown: 1000),
                        new Shoot(12, count: 4, shootAngle: (float)(90 / 4), predictive: 0.7, coolDown: 1000),
                        new Shoot(12, count: 2, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 3, coolDown: 1000),
                        new Shoot(12, count: 2, shootAngle: (float)30, angleOffset: (float)-45, projectileIndex: 4, coolDown: 1000),
                        new HpLessTransition(0.9, "Ring_Attack")
                    ),
                    new State("Ring_Attack",
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 10)
                        ),
                        
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 5000),
                        new Shoot(10, count: 2, projectileIndex: 0, coolDown: 3000),
                        new Shoot(12, count: 3, shootAngle: (float)(180 / 4), predictive: 0.7, coolDown: 1500),
                        new Shoot(12, count: 4, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 3, coolDown: 1000),
                        new Shoot(12, count: 5, shootAngle: (float)(90 / 4), predictive: 0.7, coolDown: 1000),
                        new Shoot(12, count: 4, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 3, coolDown: 1000),
                        new Shoot(12, count: 3, shootAngle: (float)30, angleOffset: (float)-45, projectileIndex: 4, coolDown: 1000),
                        new HpLessTransition(0.4, "StartTheFun")


                    ),
                    new State("StartTheFun",
                        
                        new Taunt(true, 0, "You shall not fear, come with me hero, come closer."),
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
                                new Shoot(12, 2, projectileIndex: 1, fixedAngle: 45),
                                new Shoot(12, 4, projectileIndex: 1, fixedAngle: 135),
                                
                                new Shoot(12, 2, projectileIndex: 4, fixedAngle: 90),
                                new Shoot(12, 3, projectileIndex: 1, fixedAngle: 135),
                                new Shoot(12, 2, projectileIndex: 4, fixedAngle: 90),
                                new Shoot(12, 6, projectileIndex: 1, fixedAngle: 315),
                                new TimedTransition(800, "shoot2")
                            ),
                            new State("shoot2",

                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                new HpLessTransition(0.2, "OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven"),
                                new Shoot(12, 3, shootAngle: 10, projectileIndex: 3, fixedAngle: 45),
                                new Shoot(12, 2, shootAngle: 10, projectileIndex: 5, fixedAngle: 135),
                                new Shoot(12, 3, shootAngle: 10, projectileIndex: 0, fixedAngle: 225),
                                new Shoot(12, 2, projectileIndex: 1, fixedAngle: 135),
                                new Shoot(12, 3, projectileIndex: 4, fixedAngle: 90),
                                new Shoot(12, 1, shootAngle: 10, projectileIndex: 5, fixedAngle: 80),
                                new TimedTransition(800, "shoot3")
                            ),
                            new State("shoot3",

                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                new HpLessTransition(0.2, "OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven"),
                                new Shoot(12, 4, shootAngle: 15, projectileIndex: 3, fixedAngle: 45),
                                new Shoot(12, 3, projectileIndex: 1, fixedAngle: 135),
                                new Shoot(12, 4, projectileIndex: 4, fixedAngle: 90),
                                new Shoot(12, 3, shootAngle: 15, projectileIndex: 2, fixedAngle: 135),
                                new Shoot(12, 4, shootAngle: 15, projectileIndex: 4, fixedAngle: 225),
                                
                                new Shoot(0, 4, shootAngle: 15, projectileIndex: 4, fixedAngle: 55),
                                new TimedTransition(800, "shoot1")
                            )
                        )
                    ),
                    new State("OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven",
                        new Taunt(1, true, "You will be sorry, sorry!"),
                        new Shoot(10, count: 3, shootAngle: 15, predictive: 0.7, coolDown: 1000),
                        new State("shoot1",
                            new Shoot(12, projectileIndex: 0, fixedAngle: 45),
                            new Shoot(12, projectileIndex: 2, fixedAngle: 135),
                                new Shoot(0, 5, projectileIndex: 1, fixedAngle: 135),
                                new Shoot(12, 2, projectileIndex: 4, fixedAngle: 90),
                            new Shoot(0, projectileIndex: 3, fixedAngle: 225),
                            
                            new Shoot(12, projectileIndex: 2, fixedAngle: 315),
                            new TimedTransition(1000, "shoot2")
                        ),
                        new State("shoot2",

                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(12, 3, shootAngle: 0, projectileIndex: 5, fixedAngle: 35),
                            new Shoot(0, 6, shootAngle: 15, projectileIndex: 0, fixedAngle: 45),
                                new Shoot(0, 5, projectileIndex: 1, fixedAngle: 135),
                                new Shoot(12, 2, projectileIndex: 4, fixedAngle: 90),
                            new Shoot(12, 3, shootAngle: 40, projectileIndex: 5, fixedAngle: 65),
                            new Shoot(0, 8, shootAngle: 15, projectileIndex: 0, fixedAngle: 75),
                            new TimedTransition(1000, "shoot1")
                             )
                                )
                    ),

                new Threshold(0.025,
                    new ItemLoot("Wonderful Spined Knife", 0.012),
                    new ItemLoot("Chaotic Thunderous Sword", 0.012),
                    new ItemLoot("Legendary Food", 0.09),
                    new ItemLoot("Abyssimal Glowing Hatchet", 0.007)


                    )
                   
                
        
                        
            

        
                    
            
                
            
            
        

                
            );
    }
}
