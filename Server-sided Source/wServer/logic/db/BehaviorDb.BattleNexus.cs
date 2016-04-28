#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ BattleNexus = () => Behav()
        .Init("0A Battle Nexus 1",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("waiting",
                    new PlayerWithinTransition(1000, ":)")
                    ),
                new State(":)",
                    new Spawn("Lord Ruthven Deux", 1, coolDown: 9000),
                    new TimedTransition(12500, "suicide2")
                    ),
                new State("suicide",
                    new TimedTransition(0, "suicide2")
                    ),
                new State("suicide2"
                    )
                )
            )
               .Init("0A Battle Nexus 2",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("OneMinute",
                    new TimedTransition(12500, "waiting")
                    ),

                new State("waiting",

                    new EntitiesNotExistsTransition(1000, ":)", "Lord Ruthven Deux")
                    ),
                new State(":)",
                    new Spawn("NM Green Dragon God Deux", 1, coolDown: 9000),
                    new TimedTransition(12500, "suicide2")
                    ),
                new State("suicide",
                    new TimedTransition(0, "suicide2")
                    ),
                new State("suicide2"
                    )
                )
            )
                       .Init("0A Battle Nexus 3",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("OneMinute",
                    new TimedTransition(12500, "waiting")
                    ),

                new State("waiting",

                   new EntitiesNotExistsTransition(1000, "2min", "Lord Ruthven Deux")
                    ),
                new State("2min",
                    new TimedTransition(12500, "NaeNae")
                    ),
                
                new State("NaeNae",
                   new EntitiesNotExistsTransition(1000, ":)", "NM Green Dragon God Deux")
                    ),
                new State(":)",
                    new Spawn("Oryx the Mad God Deux", 1, coolDown: 9000),
                    new TimedTransition(12500, "suicide2")
                    ),
                new State("suicide",
                    new TimedTransition(0, "suicide2")
                    ),
                new State("suicide2"
                    )
                )
            )
            .Init("Oryx the Mad God Deux",
                new State(
                    new DropPortalOnDeath("Glowing Realm Portal", 100, PortalDespawnTimeSec: 360),
                     new State("Ideeeeee",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(4, "basic")
                        ),
                                    new State("basic",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        new Taunt(1, 7000, "Say 'FIGHT' or I ain't fighting!"),

                        new ChatTransition("Attack", "FIGHT"),
                        new ChatTransition("Attack", "fight")
                        ),
                    new State("Attack",

                        new Wander(.05),
                        new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 45, coolDown: 1500, coolDownOffset: 1500),
                        new Shoot(25, projectileIndex: 1, count: 3, shootAngle: 10, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 3, shootAngle: 10, predictive: 0.2, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 3, count: 2, shootAngle: 10, predictive: 0.4, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 4, count: 3, shootAngle: 10, predictive: 0.6, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 5, count: 2, shootAngle: 10, predictive: 0.8, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 6, count: 3, shootAngle: 10, predictive: 1, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Taunt(1, 6000, "Puny mortals! My {HP} HP will annihilate you!"),
                        new HpLessTransition(.2, "prepareRage")
                    ),
                    new State("prepareRage",
                        new Follow(.1, 15, 3),
                        new Taunt("Can't... keep... henchmen... alive... anymore! ARGHHH!!!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, 30, fixedAngle: 0, projectileIndex: 7, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(25, 30, fixedAngle: 30, projectileIndex: 8, coolDown: 4000, coolDownOffset: 4000),
                        new TimedTransition(10000, "rage")
                    ),
                    new State("rage",
                        new Follow(.1, 15, 3),
                        new Shoot(25, 30, projectileIndex: 7, coolDown: 90000001, coolDownOffset: 8000),
                        new Shoot(25, 30, projectileIndex: 8, coolDown: 90000001, coolDownOffset: 8500),
                        new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 45, coolDown: 1500, coolDownOffset: 1500),
                        new Shoot(25, projectileIndex: 1, count: 3, shootAngle: 10, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 3, shootAngle: 10, predictive: 0.2, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 3, count: 2, shootAngle: 10, predictive: 0.4, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 4, count: 3, shootAngle: 10, predictive: 0.6, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 5, count: 2, shootAngle: 10, predictive: 0.8, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 6, count: 3, shootAngle: 10, predictive: 1, coolDown: 1000,
                            coolDownOffset: 1000),
                        //new TossObject("Monstrosity Scarab", 7, 0, coolDown: 1000, randomToss: true),
                        new Taunt(1, 6000, "Puny mortals! My {HP} HP will annihilate you!")
                    )
                ),
                new MostDamagers(3,
                    new ItemLoot("Potion of Wisdom", 1)
                ),
                new Threshold(0.05,
                    new ItemLoot("Potion of Attack", 0.3),
                    new ItemLoot("Rich Food", 0.2),
                    new ItemLoot("Potion of Defense", 0.3),
                    new ItemLoot("Potion of Dexterity", 0.3)
                ),
                new Threshold(0.35,

                    new ItemLoot("Sunshine Shiv", 0.3),
                    new ItemLoot("Robobow", 0.3),
                    new ItemLoot("KoalaPOW", 0.3),
                    new ItemLoot("Spicy Wand of Spice", 0.3),
                    new ItemLoot("Doctor Swordsworth", 0.3),
                    new ItemLoot("Arbiter's Wrath", 0.3)
                    )
            )
                   .Init("NM Green Dragon God Deux",
                new State(
                    new State("Ideeeeee",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(4, "basic")
                        ),
                                    new State("basic",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        new Taunt(1, 7000, "Say 'FIGHT' or I ain't fighting!"),

                        new ChatTransition("Idle", "FIGHT"),
                        new ChatTransition("Idle", "fight")
                        ),
                    //new Taunt(new string[3]
                    //{
                    //    "Start",
                    //    "Ring_Attack",
                    //    "Ring_Attack2"
                    //},
                    //text: "You are nothing more than nutiment for my roots.", cooldown: 15000),

                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(16, "Start")
                    ),
                    new State("Start",

                        
                        new Shoot(12, count: 5, shootAngle: (float)(180 / 4), predictive: 0.7, coolDown: 1500),
                        new Shoot(12, count: 7, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 3, coolDown: 1000),
                        new Shoot(12, count: 7, shootAngle: (float)(90 / 4), predictive: 0.7, coolDown: 1000),
                        new Shoot(12, count: 1, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 3, coolDown: 1000),
                        new Shoot(12, count: 1, shootAngle: (float)30, angleOffset: (float)-45, projectileIndex: 4, coolDown: 1000),
                        new HpLessTransition(0.9, "Ring_Attack")
                    ),
                    new State("Ring_Attack",
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 10)
                        ),
                        new Shoot(10, count: 3, projectileIndex: 1, coolDown: 5000),
                        new Shoot(10, count: 2, projectileIndex: 0, coolDown: 3000),
                        new Shoot(12, count: 4, shootAngle: (float)(180 / 4), predictive: 0.7, coolDown: 1500),
                        new Shoot(12, count: 7, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 3, coolDown: 1000),
                        new Shoot(12, count: 7, shootAngle: (float)(90 / 4), predictive: 0.7, coolDown: 1000),
                        new Shoot(12, count: 4, shootAngle: (float)30, angleOffset: (float)45, projectileIndex: 3, coolDown: 1000),
                        new Shoot(12, count: 2, shootAngle: (float)30, angleOffset: (float)-45, projectileIndex: 4, coolDown: 1000),
                        new HpLessTransition(0.4, "StartTheFun")


                    ),
                    new State("StartTheFun",
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
                                new Shoot(0, 6, projectileIndex: 1, fixedAngle: 45),
                                new Shoot(0, 5, projectileIndex: 1, fixedAngle: 135),
                                new Shoot(0, 2, projectileIndex: 4, fixedAngle: 90),
                                new Shoot(0, 5, projectileIndex: 1, fixedAngle: 135),
                                new Shoot(0, 2, projectileIndex: 4, fixedAngle: 90),
                                new Shoot(0, 4, projectileIndex: 1, fixedAngle: 315),
                                new TimedTransition(800, "shoot2")
                            ),
                            new State("shoot2",
                                new HpLessTransition(0.2, "OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven"),
                                new Shoot(0, 3, shootAngle: 10, projectileIndex: 3, fixedAngle: 45),
                                new Shoot(0, 5, shootAngle: 10, projectileIndex: 5, fixedAngle: 135),
                                new Shoot(0, 9, shootAngle: 10, projectileIndex: 0, fixedAngle: 225),
                                new Shoot(0, 5, projectileIndex: 1, fixedAngle: 135),
                                new Shoot(0, 2, projectileIndex: 4, fixedAngle: 90),
                                new Shoot(0, 2, shootAngle: 10, projectileIndex: 5, fixedAngle: 80),
                                new TimedTransition(800, "shoot3")
                            ),
                            new State("shoot3",
                                new HpLessTransition(0.2, "OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven"),
                                new Shoot(0, 14, shootAngle: 15, projectileIndex: 3, fixedAngle: 45),
                                new Shoot(0, 5, projectileIndex: 1, fixedAngle: 135),
                                new Shoot(0, 2, projectileIndex: 4, fixedAngle: 90),
                                new Shoot(0, 14, shootAngle: 15, projectileIndex: 2, fixedAngle: 135),
                                new Shoot(0, 10, shootAngle: 15, projectileIndex: 4, fixedAngle: 225),
                                new Shoot(0, 4, shootAngle: 15, projectileIndex: 4, fixedAngle: 55),
                                new TimedTransition(800, "shoot1")
                            )
                        )
                    ),
                    new State("OMG_HALP_ME_BUDS!!!!!!!!!!!!!!1111111oneoneoneeleven",
                        new Shoot(10, count: 3, shootAngle: 15, predictive: 0.7, coolDown: 1000),
                        new State("shoot1",
                            new Shoot(0, projectileIndex: 0, fixedAngle: 45),
                            new Shoot(0, projectileIndex: 2, fixedAngle: 135),
                                new Shoot(0, 5, projectileIndex: 1, fixedAngle: 135),
                                new Shoot(0, 2, projectileIndex: 4, fixedAngle: 90),
                            new Shoot(0, projectileIndex: 3, fixedAngle: 225),
                            new Shoot(0, projectileIndex: 2, fixedAngle: 315),
                            new TimedTransition(1000, "shoot2")
                        ),
                        new State("shoot2",
                            new Shoot(0, 3, shootAngle: 0, projectileIndex: 5, fixedAngle: 35),
                            new Shoot(0, 6, shootAngle: 15, projectileIndex: 0, fixedAngle: 45),
                                new Shoot(0, 5, projectileIndex: 1, fixedAngle: 135),
                                new Shoot(0, 2, projectileIndex: 4, fixedAngle: 90),
                            new Shoot(0, 3, shootAngle: 40, projectileIndex: 5, fixedAngle: 65),
                            new Shoot(0, 8, shootAngle: 15, projectileIndex: 0, fixedAngle: 75),
                            new TimedTransition(1000, "shoot1")
                        )
                    )
                )
            )
            

            .Init("Lord Ruthven Deux",

                new State(
                     new State("Ideeeeee",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(4, "basic")
                        ),
                                    new State("basic",

                        new ConditionalEffect(ConditionEffectIndex.Invincible),

                        new Taunt(1, 7000, "Say 'FIGHT' or I ain't fighting!"),

                        new ChatTransition("Idle", "FIGHT"),
                        new ChatTransition("Idle", "fight")
                        ),
                    //new Taunt(new string[3]
                    //{
                    //    "Start",
                    //    "Ring_Attack",
                    //    "Ring_Attack2"
                    //},
                    //text: "You are nothing more than nutiment for my roots.", cooldown: 15000),

                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(16, "Start")
                    ),
                    new State("Start",
                        new Shoot(16, count: 12, shootAngle: (float)(180 / 4), predictive: 0.7, coolDown: 1500),
                        new Shoot(16, count: 6, shootAngle: (float)60, angleOffset: (float)45, projectileIndex: 0, coolDown: 1000),
                        new Shoot(16, count: 14, shootAngle: (float)25, angleOffset: (float)-45, projectileIndex: 1, coolDown: 2000)

                        
                        )

                    )
            );
    }
}