using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using wServer.realm;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Shatters = () => Behav()
            .Init("shtrs Stone Paladin",
                new State(
                    new State("Idle",
                        new Prioritize(
                            new Wander(0.8)
                            ),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Reproduce(densityMax: 4),
                        new PlayerWithinTransition(8, "Attacking")
                        ),
                    new State("Attacking",
                        new State("Bullet",
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 100, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 110, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 120, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 130, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 140, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 150, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 160, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 170, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 180, coolDownOffset: 1800, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 180, coolDownOffset: 2000, shootAngle: 45),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 180, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 170, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 160, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 150, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 140, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 130, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 120, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 110, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 100, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 1800, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 2000, shootAngle: 22.5),
                            new TimedTransition(2000, "Wait")
                            ),
                        new State("Wait",
                            new Follow(0.4, range: 2),
                            new Flash(0xff00ff00, 0.1, 20),
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(2000, "Bullet")
                            ),
                        new NoPlayerWithinTransition(13, "Idle")
                        )
                    )
            )
            .Init("shtrs Wooden Gate",
                new State(
                    new State("Idle",
                        new EntityNotExistsTransition("0Ashtrs Abandoned Switch 1", 10, "Despawn")
                        ),
                    new State("Despawn",
                        new Decay(0)
                        ))
            )
           .Init("0S Bridge Spawner 1",
                new State(

                    new OnDeathBehavior(new ApplySetpiece("ShattersBridge1")),
                    new State("Idle",
                        new EntityNotExistsTransition("0Ashtrs Abandoned Switch 1", 10000, "Despawn")
                        ),
                    new State("Despawn",
                        new Suicide()
                        ))
            )
          .Init("0S Bridge Spawner 2",
                new State(

                    new OnDeathBehavior(new ApplySetpiece("ShattersBridge2")),
                    new State("Idle",
                        new EntityNotExistsTransition("shtrs Bridge Sentinel", 10000, "Despawn")
                        ),
                    new State("Despawn",
                        new Suicide()
                        ))
            )
              .Init("0S Bridge Spawner 3",
                new State(

                    new OnDeathBehavior(new ApplySetpiece("ShattersBridge2")),
                    new State("Idle",
                        new EntityNotExistsTransition("0Ashtrs Abandoned Switch 2", 10000, "Despawn")
                        ),
                    new State("Despawn",
                        new Suicide()
                        ))
            )
         .Init("0S Bridge Spawner 4",
                new State(

                    new OnDeathBehavior(new ApplySetpiece("ShattersBridge2")),
                    new State("Idle",
                        new EntityNotExistsTransition("shtrs Twilight Archmage", 10000, "Despawn")
                        ),
                    new State("Despawn",
                        new Suicide()
                        ))
            )
            .Init("shtrs Stone Knight",
            new State(
                new State("Follow",
                        new Follow(0.6, 10, 5),
                        new PlayerWithinTransition(5, "Charge")
                    ),
                    new State("Charge",
                        new TimedTransition(2000, "Follow"),
                        new Charge(4, 5),
                        new Shoot(5, 6, projectileIndex:0, coolDown:3000)
                        )
                    )
            )
            .Init("shtrs Ice Mage",
                new State("Main",
                    new Follow(0.5, range: 1),
                    new Shoot(10, 5, 10, projectileIndex: 0, coolDown: 1500)
                    ))
            .Init("shtrs Ice Adept",
            new State(
                new State("Main",
                    new TimedTransition(7000, "Throw"),
                    new Follow(0.8, range: 1),
                    new Shoot(10, 1, projectileIndex: 0, coolDown: 100, predictive: 1),
                    new Shoot(10, 3, projectileIndex: 1, shootAngle:10, coolDown: 4000, predictive: 1)
                ),
                new State("Throw",
                    new TossObject("shtrs Ice Portal", 5, coolDown: 900, coolDownOffset: 7000, randomToss: true),
                    new TimedTransition(1000, "Main")
                )
                  ))
           .Init("shtrs Fire Adept",
            new State(
                new State("Main",
                    new TimedTransition(7000, "Throw"),
                    new Follow(0.6, range: 1),
                    new Shoot(10, 3, projectileIndex: 1, shootAngle: 10, coolDown: 1000, predictive: 1),
                    new Shoot(10, 5, projectileIndex: 0, shootAngle: 10, coolDown: 1000)
                ),
                new State("Throw",
                    new TossObject("shtrs Fire Portal", 5, coolDown: 900, coolDownOffset: 7000, randomToss: true),
                    new TimedTransition(1000, "Main")
                )
                  ))
            .Init("shtrs MagiGenerators",
            new State(

                    new EntitiesNotExistsTransition(1000, "Despawn", "shtrs Twilight Archmage"),
                new State("Main",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Shoot(15, 10, coolDown:1000),
                    new Shoot(15, 1, projectileIndex:1, coolDown:2500)
                ),
                new State("Hide",
                    new SetAltTexture(1),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                    ),
                new State("Despawn",
                    new Decay()
                    )
                  ))
          .Init("shtrs Ice Shield",
                new State(
                    new State("Idle",
                        new TimedTransition(2500, "Spin")
                    ),
                    new State("Spin",
                        new TimedTransition(2000, "Pause"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(150, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(150, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(150, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(150, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(150, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(150, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(150, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(150, "Quadforce1")
                        )
                    ),
                    new State("Pause",
                       new TimedTransition(5000, "Spin")
                    )
                )
            )
            .Init("shtrs Ice Portal",
                new State(
                    new State("Idle",
                        new TimedTransition(2500, "Spin")
                    ),
                    new State("Spin",
                        new TimedTransition(2000, "Pause"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(150, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(150, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(150, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(150, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(150, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(150, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(150, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(150, "Quadforce1")
                        )
                    ),
                    new State("Pause",
                       new TimedTransition(5000, "Spin")
                    )
                )
            )
            .Init("shtrs Fire Portal",
                new State(
                    new State("Idle",
                        new TimedTransition(2500, "Spin")
                    ),
                    new State("Spin",
                        new TimedTransition(2000, "Pause"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(150, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(150, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(150, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(150, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(150, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(150, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(150, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(150, "Quadforce1")
                        )
                    ),
                    new State("Pause",
                       new TimedTransition(5000, "Spin")
                    )
                )
            )
            .Init("shtrs Bridge Sentinel",
                new State(
                new TransformOnDeath("shattesr superBITCH1"),
                    new SetLootState("obelisk"),
                    new CopyLootState("shtrs encounterchestspawner", 20),
                    new HpLessTransition(0.1, "Death"),
                    new CopyDamageOnDeath("shtrs Encounter Chest"),
                    new State("Idle",
                        new PlayerWithinTransition(15, "Close Bridge")
                    ),
                    //not correct
                    new State("Close Bridge",
                        new TimedTransition(2500, "Start")
                    ),
                    //new State("Start the Start",
                    //    new Order(10, "shtrs Bridge Obelisk A", "Talk"),
                    //    new Order(10, "shtrs Bridge Obelisk B", "Talk"),
                    //    new Order(10, "shtrs Bridge Obelisk C", "Talk"),
                    //    new Order(10, "shtrs Bridge Obelisk D", "Talk")
                    //),
                    new State("Start",
                        new Shoot(15, 10, 15, 5, 90, coolDown: 1000),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(15000, "Blobomb"),
                        new EntityNotExistsTransition("shtrs Bridge Titanum", 10, "Wake")
                        ),
                        new State("Wake",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Who has woken me...? Leave this place."),
                        new Timed(2100, new Shoot(15, 15, 12, projectileIndex: 0, fixedAngle: 90, coolDown: 700, coolDownOffset: 3000)),
                        new TimedTransition(8000, "Swirl Shot")
                        ),
                        new State("Swirl Shot",
                            new Taunt("Go."),
                            new State("Swirl1",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 12, coolDown: 200),
                            new TimedTransition(50, "Swirl2")
                            ),
                            new State("Swirl2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 24, coolDown: 200),
                            new TimedTransition(50, "Swirl3")
                            ),
                            new State("Swirl3",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 36, coolDown: 200),
                            new TimedTransition(50, "Swirl4")
                            ),
                            new State("Swirl4",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 48, coolDown: 200),
                            new TimedTransition(50, "Swirl5")
                            ),
                            new State("Swirl5",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 60, coolDown: 200),
                            new TimedTransition(50, "Swirl6")
                            ),
                            new State("Swirl6",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 72, coolDown: 200),
                            new TimedTransition(50, "Swirl7")
                            ),
                            new State("Swirl7",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 84, coolDown: 200),
                            new TimedTransition(50, "Swirl8")
                            ),
                            new State("Swirl8",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 96, coolDown: 200),
                            new TimedTransition(50, "Swirl9")
                            ),
                            new State("Swirl9",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 108, coolDown: 200),
                            new TimedTransition(50, "Swirl10")
                            ),
                            new State("Swirl10",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 120, coolDown: 200),
                            new TimedTransition(50, "Swirl11")
                            ),
                            new State("Swirl11",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 132, coolDown: 200),
                            new TimedTransition(50, "Swirl12")
                            ),
                            new State("Swirl12",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 144, coolDown: 200),
                            new TimedTransition(50, "Swirl13")
                            ),
                            new State("Swirl13",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 156, coolDown: 200),

                            new TimedTransition(50, "Swirl14")
                            ),
                            new State("Swirl14",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 168, coolDown: 200),
                            new TimedTransition(50, "Swirl15")
                            ),
                            new State("Swirl15",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 168, coolDown: 200),
                            new TimedTransition(50, "Swirl16")
                            ),
                            new State("Swirl16",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 156, coolDown: 200),

                            new TimedTransition(50, "Swirl17")
                            ),
                            new State("Swirl17",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 144, coolDown: 200),
                            new TimedTransition(50, "Swirl18")
                            ),
                            new State("Swirl18",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 132, coolDown: 200),
                            new TimedTransition(50, "Swirl19")
                            ),
                            new State("Swirl19",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 120, coolDown: 200),
                            new TimedTransition(50, "Swirl20")
                            ),
                            new State("Swirl20",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 108, coolDown: 200),
                            new TimedTransition(50, "Swirl21")
                            ),
                            new State("Swirl21",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 96, coolDown: 200),
                            new TimedTransition(50, "Swirl22")
                            ),
                            new State("Swirl22",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 84, coolDown: 200),
                            new TimedTransition(50, "Swirl23")
                            ),
                            new State("Swirl23",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 72, coolDown: 200),
                            new TimedTransition(50, "Swirl24")
                            ),
                            new State("Swirl24",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 60, coolDown: 200),
                            new TimedTransition(50, "Swirl25")
                            ),
                            new State("Swirl25",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 48, coolDown: 200),
                            new TimedTransition(50, "Swirl26")
                            ),
                            new State("Swirl26",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 36, coolDown: 200),
                            new TimedTransition(50, "Swirl27")
                            ),
                            new State("Swirl27",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 24, coolDown: 200),
                            new TimedTransition(50, "Swirl28")
                            ),
                            new State("Swirl28",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 12, coolDown: 200),
                            new TimedTransition(50, "Swirl1")
                            )
                            ),
                            new State("Blobomb",
                            new Taunt("You live still? DO NOT TEMPT FATE!"),
                            new Taunt("CONSUME!"),
                            new Order(20, "shtrs blobomb maker", "Spawn"),
                            new EntityNotExistsTransition("shtrs Blobomb", 30, "SwirlAndShoot")
                                ),
                                new State("SwirlAndShoot",
                                    new TimedTransition(10000, "Blobomb"),
                                    new Taunt("FOOLS! YOU DO NOT UNDERSTAND!"),
                                    new ChangeSize(20, 130),
                            new Shoot(15, 15, 11, projectileIndex: 0, fixedAngle: 90, coolDown: 700, coolDownOffset: 700),
                                    new State("Swirl1_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 12, coolDown: 200),
                            new TimedTransition(50, "Swirl2_2")
                            ),
                            new State("Swirl2_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 24, coolDown: 200),
                            new TimedTransition(50, "Swirl3_2")
                            ),
                            new State("Swirl3_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 36, coolDown: 200),
                            new TimedTransition(50, "Swirl4_2")
                            ),
                            new State("Swirl4_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 48, coolDown: 200),
                            new TimedTransition(50, "Swirl5_2")
                            ),
                            new State("Swirl5_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 60, coolDown: 200),
                            new TimedTransition(50, "Swirl6_2")
                            ),
                            new State("Swirl6_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 72, coolDown: 200),
                            new TimedTransition(50, "Swirl7_2")
                            ),
                            new State("Swirl7_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 84, coolDown: 200),
                            new TimedTransition(50, "Swirl8_2")
                            ),
                            new State("Swirl8_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 96, coolDown: 200),
                            new TimedTransition(50, "Swirl9_2")
                            ),
                            new State("Swirl9_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 108, coolDown: 200),
                            new TimedTransition(50, "Swirl10_2")
                            ),
                            new State("Swirl10_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 120, coolDown: 200),
                            new TimedTransition(50, "Swirl11_2")
                            ),
                            new State("Swirl11_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 132, coolDown: 200),
                            new TimedTransition(50, "Swirl12_2")
                            ),
                            new State("Swirl12_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 144, coolDown: 200),
                            new TimedTransition(50, "Swirl13_2")
                            ),
                            new State("Swirl13_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 156, coolDown: 200),
                            new TimedTransition(50, "Swirl14_2")
                            ),
                            new State("Swirl14_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 168, coolDown: 200),
                            new TimedTransition(50, "Swirl15_2")
                            ),
                            new State("Swirl15_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 168, coolDown: 200),
                            new TimedTransition(50, "Swirl16_2")
                            ),
                            new State("Swirl16_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 156, coolDown: 200),
                            new TimedTransition(50, "Swirl17_2")
                            ),
                            new State("Swirl17_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 144, coolDown: 200),
                            new TimedTransition(50, "Swirl18_2")
                            ),
                            new State("Swirl18_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 132, coolDown: 200),
                            new TimedTransition(50, "Swirl19_2")
                            ),
                            new State("Swirl19_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 120, coolDown: 200),
                            new TimedTransition(50, "Swirl20_2")
                            ),
                            new State("Swirl20_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 108, coolDown: 200),
                            new TimedTransition(50, "Swirl21_2")
                            ),
                            new State("Swirl21_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 96, coolDown: 200),
                            new TimedTransition(50, "Swirl22_2")
                            ),
                            new State("Swirl22_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 84, coolDown: 200),
                            new TimedTransition(50, "Swirl23_2")
                            ),
                            new State("Swirl23_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 72, coolDown: 200),
                            new TimedTransition(50, "Swirl24_2")
                            ),
                            new State("Swirl24_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 60, coolDown: 200),
                            new TimedTransition(50, "Swirl25_2")
                            ),
                            new State("Swirl25_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 48, coolDown: 200),
                            new TimedTransition(50, "Swirl26_2")
                            ),
                            new State("Swirl26_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 36, coolDown: 200),
                            new TimedTransition(50, "Swirl27_2")
                            ),
                            new State("Swirl27_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 24, coolDown: 200),
                            new TimedTransition(50, "Swirl28_2")
                            ),
                            new State("Swirl28_2",
                            new Shoot(15, 1, projectileIndex: 0, fixedAngle: 12, coolDown: 200),
                            new TimedTransition(50, "Swirl1_2")
                            )
                                    ),
                                    new State("Death",
                                        new ChangeSize(20, 130),
                                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                        new Taunt("I tried to protect you...I have failed. You release a great evil upon this realm..."),
                                        new Shoot(15, 12, projectileIndex: 0, coolDown: 100000, coolDownOffset: 3000),
                                        new CopyDamageOnDeath("shtrs Encounter Chest"),
                                        new Order(10, "shtrs encounterchestspawner", "Spawn"),
                                        new Suicide()
                                        )
                        )
            )
            .Init("shtrs Bridge Obelisk A",
                new State(
                    new Reproduce("shtrs Stone Paladin", densityMax: 1, spawnRadius: 0, coolDown: 8000),
                    new ConditionalEffect(ConditionEffectIndex.Armored, true),
                    
                        new State("IMMA_MOVE_NAOW",
                            new PlayerWithinTransition(24, "IMMA_DONT_MOVE_NAOW")
                            ),
                        new State("IMMA_DONT_MOVE_NAOW",
                        new Flash(0xf0e68c, flashPeriod: 0.2, flashRepeats: 2),
                         new CallWorldMethod("Shatters", "CloseBridge1", null),
                            new Taunt("DO NOT WAKE THE BRIDGE GUARDIAN!"),
                            new TimedTransition(2000, "shoot1")
                            ),

                            new State("shoot1",
                                new Shoot(50, fixedAngle: 0),
                                new Shoot(100, fixedAngle: 0, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 0, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 0, coolDownOffset: 150),
                                new TimedTransition(0, "shoot2")
                            ),
                            new State("shoot2",
                                new Shoot(50, fixedAngle: 180),
                                new Shoot(100, fixedAngle: 180, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 180, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 180, coolDownOffset: 150),
                                new TimedTransition(0, "shoot3")
                                ),
                            new State("shoot3",
                                new Shoot(50, fixedAngle: 90),

                                new Shoot(100, fixedAngle: 90, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 90, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 90, coolDownOffset: 150),
                                new TimedTransition(0, "shoot4")
                                ),

                            new State("shoot4",
                                new Shoot(50, fixedAngle: 270),
                                new Shoot(100, fixedAngle: 270, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 270, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 270, coolDownOffset: 150),
                                new TimedTransition(0, "shoot1")
                            )
                       
                    )
                    
                
            )
                .Init("shtrs Bridge Titanum",
                new State(

                        new State("IMMA_MOVE_NAOW",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new EntitiesNotExistsTransition(1000, "shoot1", "shtrs Bridge Obelisk A", "shtrs Bridge Obelisk B", "shtrs Bridge Obelisk C", "shtrs Bridge Obelisk D", "shtrs Bridge Obelisk E", "shtrs Bridge Obelisk F")
                            ),
                        new State("IMMA_DONT_MOVE_NAOW",
                        new Flash(0xf0e68c, flashPeriod: 0.2, flashRepeats: 2),
                            new TimedTransition(2000, "shoot1")
                            ),
                            new State("shoot1",
                                new Shoot(50, fixedAngle: 0),
                                new Shoot(100, fixedAngle: 0),
                                new TimedTransition(0, "shoot2")
                            ),
                            new State("shoot2",
                                new Shoot(50, fixedAngle: 180),
                                new Shoot(100, fixedAngle: 180),
                                new TimedTransition(0, "shoot3")
                                ),
                            new State("shoot3",
                                new Shoot(50, fixedAngle: 90),
                                new Shoot(100, fixedAngle: 90),
                                new TimedTransition(0, "shoot4")
                                ),

                            new State("shoot4",
                                new Shoot(50, fixedAngle: 270),
                                new Shoot(100, fixedAngle: 270),
                                new TimedTransition(0, "shoot1")
                            )

                    )


            )
           .Init("shtrs Bridge Obelisk B",
                new State(
                    new Reproduce("shtrs Stone Paladin", densityMax: 1, spawnRadius: 0, coolDown: 8000),
                    new ConditionalEffect(ConditionEffectIndex.Armored, true),

                        new State("IMMA_MOVE_NAOW",
                            new PlayerWithinTransition(24, "IMMA_DONT_MOVE_NAOW")
                            ),
                        new State("IMMA_DONT_MOVE_NAOW",

                        new Flash(0xf0e68c, flashPeriod: 0.2, flashRepeats: 2),
                            new Taunt("DO NOT WAKE THE BRIDGE GUARDIAN!"),
                            new TimedTransition(2000, "shoot1")
                            ),

                            new State("shoot1",
                                new Shoot(50, fixedAngle: 0),
                                new Shoot(100, fixedAngle: 0, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 0, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 0, coolDownOffset: 150),
                                new TimedTransition(0, "shoot2")
                            ),
                            new State("shoot2",
                                new Shoot(50, fixedAngle: 180),
                                new Shoot(100, fixedAngle: 180, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 180, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 180, coolDownOffset: 150),
                                new TimedTransition(0, "shoot3")
                                ),
                            new State("shoot3",
                                new Shoot(50, fixedAngle: 90),

                                new Shoot(100, fixedAngle: 90, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 90, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 90, coolDownOffset: 150),
                                new TimedTransition(0, "shoot4")
                                ),

                            new State("shoot4",
                                new Shoot(50, fixedAngle: 270),
                                new Shoot(100, fixedAngle: 270, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 270, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 270, coolDownOffset: 150),
                                new TimedTransition(0, "shoot1")
                            )

                    )


            )
           .Init("shtrs Bridge Obelisk C",
                new State(
                    new Reproduce("shtrs Stone Paladin", densityMax: 1, spawnRadius: 0, coolDown: 8000),
                    new ConditionalEffect(ConditionEffectIndex.Armored, true),

                        new State("IMMA_MOVE_NAOW",
                            new PlayerWithinTransition(24, "IMMA_DONT_MOVE_NAOW")
                            ),
                        new State("IMMA_DONT_MOVE_NAOW",
                        new Flash(0xf0e68c, flashPeriod: 0.2, flashRepeats: 2),
                            new Taunt("DO NOT WAKE THE BRIDGE GUARDIAN!"),
                            new TimedTransition(2000, "shoot1")
                            ),

                            new State("shoot1",
                                new Shoot(50, fixedAngle: 0),
                                new Shoot(100, fixedAngle: 0, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 0, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 0, coolDownOffset: 150),
                                new TimedTransition(0, "shoot2")
                            ),
                            new State("shoot2",
                                new Shoot(50, fixedAngle: 180),
                                new Shoot(100, fixedAngle: 180, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 180, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 180, coolDownOffset: 150),
                                new TimedTransition(0, "shoot3")
                                ),
                            new State("shoot3",
                                new Shoot(50, fixedAngle: 90),

                                new Shoot(100, fixedAngle: 90, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 90, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 90, coolDownOffset: 150),
                                new TimedTransition(0, "shoot4")
                                ),

                            new State("shoot4",
                                new Shoot(50, fixedAngle: 270),
                                new Shoot(100, fixedAngle: 270, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 270, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 270, coolDownOffset: 150),
                                new TimedTransition(0, "shoot1")
                            )

                    )


            )
           .Init("shtrs Bridge Obelisk D",
                new State(
                    new Reproduce("shtrs Stone Paladin", densityMax: 1, spawnRadius: 0, coolDown: 8000),
                    new ConditionalEffect(ConditionEffectIndex.Armored, true),

                        new State("IMMA_MOVE_NAOW",
                            new PlayerWithinTransition(24, "IMMA_DONT_MOVE_NAOW")
                            ),
                        new State("IMMA_DONT_MOVE_NAOW",
                        new Flash(0xf0e68c, flashPeriod: 0.2, flashRepeats: 2),
                            new Taunt("DO NOT WAKE THE BRIDGE GUARDIAN!"),
                            new TimedTransition(2000, "shoot1")
                            ),

                            new State("shoot1",
                                new Shoot(50, fixedAngle: 0),
                                new Shoot(100, fixedAngle: 0, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 0, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 0, coolDownOffset: 150),
                                new TimedTransition(0, "shoot2")
                            ),
                            new State("shoot2",
                                new Shoot(50, fixedAngle: 180),
                                new Shoot(100, fixedAngle: 180, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 180, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 180, coolDownOffset: 150),
                                new TimedTransition(0, "shoot3")
                                ),
                            new State("shoot3",
                                new Shoot(50, fixedAngle: 90),

                                new Shoot(100, fixedAngle: 90, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 90, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 90, coolDownOffset: 150),
                                new TimedTransition(0, "shoot4")
                                ),

                            new State("shoot4",
                                new Shoot(50, fixedAngle: 270),
                                new Shoot(100, fixedAngle: 270, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 270, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 270, coolDownOffset: 150),
                                new TimedTransition(0, "shoot1")
                            )

                    )


            )
               .Init("shtrs Bridge Obelisk E",
                new State(
                    new Reproduce("shtrs Stone Paladin", densityMax: 1, spawnRadius: 0, coolDown: 8000),
                    new ConditionalEffect(ConditionEffectIndex.Armored, true),

                        new State("IMMA_MOVE_NAOW",
                            new PlayerWithinTransition(24, "IMMA_DONT_MOVE_NAOW")
                            ),
                        new State("IMMA_DONT_MOVE_NAOW",
                        new Flash(0xf0e68c, flashPeriod: 0.2, flashRepeats: 2),
                            new Taunt("DO NOT WAKE THE BRIDGE GUARDIAN!"),
                            new TimedTransition(2000, "shoot1")
                            ),

                            new State("shoot1",
                                new Shoot(50, fixedAngle: 0),
                                new Shoot(100, fixedAngle: 0, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 0, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 0, coolDownOffset: 150),
                                new TimedTransition(0, "shoot2")
                            ),
                            new State("shoot2",
                                new Shoot(50, fixedAngle: 180),
                                new Shoot(100, fixedAngle: 180, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 180, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 180, coolDownOffset: 150),
                                new TimedTransition(0, "shoot3")
                                ),
                            new State("shoot3",
                                new Shoot(50, fixedAngle: 90),

                                new Shoot(100, fixedAngle: 90, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 90, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 90, coolDownOffset: 150),
                                new TimedTransition(0, "shoot4")
                                ),

                            new State("shoot4",
                                new Shoot(50, fixedAngle: 270),
                                new Shoot(100, fixedAngle: 270, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 270, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 270, coolDownOffset: 150),
                                new TimedTransition(0, "shoot1")
                            )

                    )


            )
               .Init("shtrs Bridge Obelisk F",
                new State(
                    new Reproduce("shtrs Stone Paladin", densityMax: 1, spawnRadius: 0, coolDown: 8000),
                    new ConditionalEffect(ConditionEffectIndex.Armored, true),

                        new State("IMMA_MOVE_NAOW",
                            new PlayerWithinTransition(24, "IMMA_DONT_MOVE_NAOW")
                            ),
                        new State("IMMA_DONT_MOVE_NAOW",
                        new Flash(0xf0e68c, flashPeriod: 0.2, flashRepeats: 2),
                            new Taunt("DO NOT WAKE THE BRIDGE GUARDIAN!"),
                            new TimedTransition(2000, "shoot1")
                            ),
                            new State("shoot1",
                                new Shoot(50, fixedAngle: 0),
                                new Shoot(100, fixedAngle: 0, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 0, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 0, coolDownOffset: 150),
                                new TimedTransition(0, "shoot2")
                            ),
                            new State("shoot2",
                                new Shoot(50, fixedAngle: 180),
                                new Shoot(100, fixedAngle: 180, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 180, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 180, coolDownOffset: 150),
                                new TimedTransition(0, "shoot3")
                                ),
                            new State("shoot3",
                                new Shoot(50, fixedAngle: 90),

                                new Shoot(100, fixedAngle: 90, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 90, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 90, coolDownOffset: 150),
                                new TimedTransition(0, "shoot4")
                                ),

                            new State("shoot4",
                                new Shoot(50, fixedAngle: 270),
                                new Shoot(100, fixedAngle: 270, coolDownOffset: 50),
                                new Shoot(50, fixedAngle: 270, coolDownOffset: 100),
                                new Shoot(100, fixedAngle: 270, coolDownOffset: 150),
                                new TimedTransition(0, "shoot1")
                            )

                    )


            )
            .Init("shtrs Twilight Archmage",
                new State(
                new TransformOnDeath("shattesr superBITCH2"),
                    new SetLootState("archmage"),
                    new CopyLootState("shtrs encounterchestspawner", 20),
                    new HpLessTransition(.1, "Death"),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition2("shtrs Glassier Archmage", "shtrs Archmage of Flame", 15, "Wake")
                    ),
                    new State("Wake",
                        new State("Comment1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new SetAltTexture(1),
                            new Taunt("Ha...ha........hahahahahaha! You will make a fine sacrifice!"),
                            new TimedTransition(3000, "Comment2")
                        ),
                        new SetAltTexture(1),
                        new State("Comment2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Taunt("You will find that it was...unwise...to wake me."),
                            new TimedTransition(1000, "Comment3")
                        ),
                        new State("Comment3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new SetAltTexture(1),
                            new Taunt("Let us see what can conjure up!"),
                            new TimedTransition(1000, "Comment4")
                        ),
                        new State("Comment4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new SetAltTexture(1),
                            new Taunt("I will freeze the life from you!"),
                            new TimedTransition(1000, "Blue1")
                        )
                    ),
                    new State("Blue1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new SetAltTexture(2),
                        new TossObject("shtrs Ice Portal", 4, 90, 100000000),
                        new TossObject("shtrs Fire Portal", 4, 180, 100000000),
                        new Spawn("shtrs Ice Shield", 1, 1, 1000000000),
                        new TimedTransition(2000, "checkSphere")
                    ),
                    new State("checkSphere",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Ice Shield", 15, "Spawn Birds")
                    ),
                    new State("Spawn Birds",

                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Order(1, "shtrs MagiGenerators", "Hide"),
                        new Taunt("You leave me no choice...Inferno! Blizzard!"),
                        new InvisiToss("shtrs Inferno", 3, 0, 1000000000, 7000),
                        new InvisiToss("shtrs Blizzard", 3, 180, 1000000000, 7000),
                        new TimedTransition(8000, "wait")
                    ),
                    new State("wait",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition2("shtrs Inferno", "shtrs Blizzard", 15, "Change")
                    ),
                    new State("Change",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new SetAltTexture(2),
                        new ChangeSize(100, 200),
                        new Taunt("Your souls feed my King."),
                        new TimedTransition(3000, "Active 1")
                    ),
                    new State("Active 1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Darkness give me strength!"),
                        new MoveTo(6, 0),
                        new TimedTransition(4000, "Active2")
                    ),
                    new State("Active2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new MoveTo(0, 4, 1.5),
                        new Taunt("THE POWER...IT CONSUMES ME!"),
                        new Shoot(15, 20, projectileIndex:2, coolDown:100000000, coolDownOffset:5000),
                        new Shoot(15, 20, projectileIndex: 3, coolDown: 100000000, coolDownOffset: 5000),
                        new Shoot(15, 20, projectileIndex: 4, coolDown: 100000000, coolDownOffset: 5100),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 5200),
                        new Shoot(15, 20, projectileIndex: 5, coolDown: 100000000, coolDownOffset: 5350),
                        new Shoot(15, 20, projectileIndex: 6, coolDown: 100000000, coolDownOffset: 5400),
                        new TimedTransition(6000, "Active3")
                    ),
                    new State("Active3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("THE POWER...IT CONSUMES ME!"),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 5000),
                        new Shoot(15, 20, projectileIndex: 3, coolDown: 100000000, coolDownOffset: 5000),
                        new Shoot(15, 20, projectileIndex: 4, coolDown: 100000000, coolDownOffset: 5100),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 5200),
                        new Shoot(15, 20, projectileIndex: 5, coolDown: 100000000, coolDownOffset: 5350),
                        new Shoot(15, 20, projectileIndex: 6, coolDown: 100000000, coolDownOffset: 5400)
                    ),
                    new State("Death",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("I...will........retuuurr...n...n....."),
                        new Shoot(15, 12, projectileIndex:5, coolDown:1000000, coolDownOffset:30000),
                        new CopyDamageOnDeath("shtrs Encounter Chest"),
                        new Order(10, "shtrs encounterchestspawner", "Spawn"),
                        new Suicide()
                    )
                )
            )
            .Init("shtrs The Forgotten King",
                new State(
                    new DropPortalOnDeath("Glowing Realm Portal", 100, PortalDespawnTimeSec: 360),
                new TransformOnDeath("shattesr superBITCH"),

                    new State("Idle",

                        new PlayerWithinTransition(18, "Shoot")
                    ),
                    new State("Shoot",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(24, 6, projectileIndex: 1, coolDown: 2500),
                        new Shoot(24, 3, projectileIndex: 1, coolDown: 1720),
                             new Spawn("shtrs Inferno", maxChildren: 1, initialSpawn: 1, coolDown: 100000),
                             new Spawn("shtrs Blizzard", maxChildren: 1, initialSpawn: 1, coolDown: 100000),
                        new Shoot(24, 8, projectileIndex: 1, coolDown: 800),
                        new Shoot(24, 3, projectileIndex: 1, coolDown: 3400),
                            new HpLessTransition(0.95, "Rage1")
                            ),
                        new State("Rage1",

                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Taunt("YOU HAVE MESSED WITH THE WRONG KING"),
                        new Order(1000, "shtrs ACTIVATE MOFO BRIDG", "Despawn"),
                            new Shoot(24, 16, projectileIndex: 2, coolDown: 1000, shootAngle: 15),
                            new TimedTransition(12500, "SPAWNSHIT")
                            ),
                        new State("SPAWNSHIT",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                             new Taunt("HOW COULD YOU EVEN BOTHER!"), new Shoot(20, 1, 0, 1, 60),
                        new Shoot(20, 1, 0, 1, 120),
                        new Shoot(20, 1, 0, 1, 180),
                        new Shoot(20, 1, 0, 1, 240),
                        new Shoot(20, 1, 0, 1, 300),
                        new Shoot(20, 1, 0, 1, 0),
                        new Shoot(20, 1, 0, 1, 130, coolDownOffset: 1400),
                        new Shoot(20, 1, 0, 1, 190, coolDownOffset: 1400),
                        new Shoot(20, 1, 0, 1, 250, coolDownOffset: 1400),
                        new Shoot(20, 1, 0, 1, 310, coolDownOffset: 1400),
                        new Shoot(20, 1, 0, 1, 10, coolDownOffset: 1400),
                        new Shoot(20, 1, 0, 1, 70, coolDownOffset: 1400),
                        new Shoot(20, 1, 0, 1, 140, coolDownOffset: 1600),
                        new Shoot(20, 1, 0, 1, 200, coolDownOffset: 1600),
                        new Shoot(20, 1, 0, 1, 260, coolDownOffset: 1600),
                        new Shoot(20, 1, 0, 1, 320, coolDownOffset: 1600),
                        new Shoot(20, 1, 0, 1, 20, coolDownOffset: 1600),
                        new Shoot(20, 1, 0, 1, 80, coolDownOffset: 1600),
                        new Shoot(20, 1, 0, 1, 150, coolDownOffset: 2000),
                        new Shoot(20, 1, 0, 1, 210, coolDownOffset: 2000),
                        new Shoot(20, 1, 0, 1, 250, coolDownOffset: 2000),
                        new Shoot(20, 1, 0, 1, 330, coolDownOffset: 2000),
                        new Shoot(20, 1, 0, 1, 30, coolDownOffset: 2000),
                        new Shoot(20, 1, 0, 1, 90, coolDownOffset: 2000),
                            new TimedTransition(15000, "DORANDOMSTUFFw8")
                            ),       
                        new State("DORANDOMSTUFFw8",

                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                new InvisiToss("shtrs Royal Guardian J", range: 4.3, angle: 15),
                                new InvisiToss("shtrs Royal Guardian J", range: 4.6, angle: 30),
                                new InvisiToss("shtrs Royal Guardian J", range: 3.3, angle: 45),
                                new InvisiToss("shtrs Royal Guardian J", range: 3.9, angle: 60),
                                new InvisiToss("shtrs Royal Guardian J", range: 4.6, angle: 75),
                            new TimedTransition(0, "DORANDOMSTUFFw82")



                        ),
                             new State("DORANDOMSTUFFw82",

                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs Royal Guardian J", 15, "DORANDOMSTUFF")



                        ),
                        new State("DORANDOMSTUFF",

                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new MoveTo(0, -6, 1.5),
                        new Order(1000, "shtrs blobomb maker", "blobombs 3rd"),
                    new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, coolDown: 600),
                            new Shoot(0, projectileIndex: 2, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 1500),
                            new Shoot(0, projectileIndex: 1, count: 6, shootAngle: 80, fixedAngle: 30, coolDown: 1250),
                            new Shoot(0, projectileIndex: 1, count: 6, shootAngle: 120, fixedAngle: 45, coolDown: 1250),
                             new Spawn("shtrs Blue Crystal", maxChildren: 1, initialSpawn: 1, coolDown: 999999),
                             new Spawn("shtrs Yellow Crystal", maxChildren: 1, initialSpawn: 1, coolDown: 999999),
                             new Spawn("shtrs Green Crystal", maxChildren: 1, initialSpawn: 1, coolDown: 999999),
                             new Spawn("shtrs Red Crystal", maxChildren: 1, initialSpawn: 1, coolDown: 999999),

                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 160, fixedAngle: 60, coolDown: 3500),
                            new Shoot(0, projectileIndex: 3, count: 6, shootAngle: 180, fixedAngle: 75, coolDown: 1500)


                        ),
                    new State("Death",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new CopyDamageOnDeath("shtrs Encounter Chest"),
                        new Taunt("I WILL RETURN!!!"),

                                new InvisiToss("shtrs Fire Portal", range: 6.9, angle: 15),
                                new InvisiToss("shtrs Ice Portal", range: 3.6, angle: 30),
                        new Order(10, "shtrs encounterchestspawner", "Spawn"),
                        new Suicide()
                    )
                )
            )
                       .Init("shtrs ACTIVATE MOFO BRIDG",
                new State(

                    new OnDeathBehavior(new ApplySetpiece("ShattersFIGHT")),
                    new State("Idle"
                      
                        ),
                    new State("Despawn",
                        new Suicide()
                        ))
            )
             .Init("shtrs Royal Guardian J",
                new State(
                        new Orbit(.6, 3, target: "shtrs The Forgotten King", radiusVariance: 0.5),
                    new State("active",
                        new PlayerWithinTransition(20, "blink")
                    ),
                    new State("blink",

                        new Shoot(15, 6, coolDown: 5500)
                    )
                )
            )
        .Init("shtrs Lava Souls",
                new State(
                    new State("active",
                        new Follow(.7, range: 0),
                        new PlayerWithinTransition(2, "blink")
                    ),
                    new State("blink",
                        new Flash(0xfFF0000, flashRepeats: 10000, flashPeriod: 0.1),
                        new TimedTransition(2000, "explode")
                    ),
                    new State("explode",
                        new Flash(0xfFF0000, flashRepeats: 5, flashPeriod: 0.1),
                        new Shoot(5, 9),
                        new Suicide()
                    )
                )
            )
            .Init("shtrs blobomb maker",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible)
                    ),
                    new State("Spawn",
                        new Spawn("shtrs Blobomb", coolDown: 1000),
                        new TimedTransition(6000, "Idle")
                     ),
                    new State("blobombs avatar",
                        new Spawn("shtrs Blobomb", maxChildren: 1, coolDown: 6000)
                        ),
                      new State("blobombs 3rd",
                        new Spawn("shtrs Lava Souls", maxChildren: 3, coolDown: 3000)
                        ),
                    new State("AVATAR HELP!",
                        new Spawn("shtrs Blobomb", maxChildren: 1, coolDown: 2000),
                        new TimedTransition(2000, "Idle")
                    )
                )
            )
            .Init("shtrs encounterchestspawner",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible, true)
                    ),
                    new State("Spawn",
                        new Spawn("shtrs Encounter Chest", 1, 1),
                        new CopyLootState("shtrs Encounter Chest", 10),
                        new TimedTransition(5000, "Idle")
                    )
                )
            )

            .Init("shtrs Encounter Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "Bracer")
                    ),
                    new State("Bracer")
                ),
                new Threshold(0.1,
                    new TierLoot(11, ItemType.Weapon, 0.06),
                    new TierLoot(12, ItemType.Weapon, 0.05),
                    new TierLoot(6, ItemType.Ability, 0.05),
                    new TierLoot(12, ItemType.Armor, 0.06),
                    new TierLoot(13, ItemType.Armor, 0.05),
                    new TierLoot(6, ItemType.Ring, 0.06)
                ),
                new LootState("obelisk",
                    new Threshold(0.32,
                        new ItemLoot("Potion of Attack", 1),
                        new ItemLoot("Potion of Defense", 0.5)
                    ),
                    new Threshold(0.1,
                        new ItemLoot("Bracer of the Guardian", 0.02)
                    )
                ),
                new LootState("archmage",
                    new Threshold(0.32,
                        new ItemLoot("Potion of Mana", 1)
                    ),
                    new Threshold(0.1,
                        new ItemLoot("The Twilight Gemstone", 0.02)
                    )
                ),
                new LootState("forgottenKing",
                    new Threshold(0.32,
                        new ItemLoot("Potion of Life", 1)
                    ),
                    new Threshold(0.1,
                        new ItemLoot("The Forgotten Crown", 0.02)
                    )
                )
            )
                   .Init("shattesr superBITCH1",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new Threshold(0.1,
                    new ItemLoot("Bracer of the Guardian", 0.02),
                    new ItemLoot("Potion of Defense", 0.7),
                    new ItemLoot("Robe of the Grand Sorcerer", 0.07),
                    new ItemLoot("Ring of Unbound Attack", 0.05),
                    new ItemLoot("Ring of Unbound Defense", 0.05),
                    new ItemLoot("Ring of Unbound Dexterity", 0.05),
                    new ItemLoot("Staff of Astral Knowledge", 0.3),
                    new ItemLoot("Tome of Holy Guidance", 0.05),
                    new ItemLoot("Quiver of Elvish Mastery", 0.05),
                    new ItemLoot("Colossus Shield", 0.05),
                    new ItemLoot("Scepter of Storms", 0.05)
                    )
            )
          .Init("shattesr superBITCH2",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new Threshold(0.1,
                    new ItemLoot("Potion of Defense", 0.7),
                    new ItemLoot("The Twilight Gemstone", 0.02),
                    new ItemLoot("Robe of the Grand Sorcerer", 0.07),
                    new ItemLoot("Ring of Unbound Attack", 0.05),
                    new ItemLoot("Ring of Unbound Defense", 0.05),
                    new ItemLoot("Ring of Unbound Dexterity", 0.05),
                    new ItemLoot("Staff of Astral Knowledge", 0.3),
                    new ItemLoot("Tome of Holy Guidance", 0.05),
                    new ItemLoot("Quiver of Elvish Mastery", 0.05),
                    new ItemLoot("Colossus Shield", 0.05),
                    new ItemLoot("Scepter of Storms", 0.05)
                    )
            )
           .Init("shattesr superBITCH",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new Threshold(0.1,
                    new ItemLoot("The Forgotten Crown", 0.01),
                    new ItemLoot("Potion of Life", 0.7),
                    new ItemLoot("Potion of Defense", 0.7),
                    new ItemLoot("Potion of Mana", 0.7),
                    new ItemLoot("Sword of Acclaim", 0.06),
                    new ItemLoot("Staff of the Cosmic Whole", 0.07),
                    new ItemLoot("Wand of Recompense", 0.07),
                    new ItemLoot("Dagger of Foul Malevolence", 0.07),
                    new ItemLoot("Acropolis Armor", 0.06),
                    new ItemLoot("Hydra Skin Armor", 0.06),
                    new ItemLoot("Robe of the Grand Sorcerer", 0.07),
                    new ItemLoot("Ring of Unbound Health", 0.05),
                    new ItemLoot("Ring of Unbound Magic", 0.05),
                    new ItemLoot("Ring of Unbound Attack", 0.05),
                    new ItemLoot("Legendary Food", 0.2),
                    new ItemLoot("Ring of Unbound Defense", 0.05),
                    new ItemLoot("Ring of Unbound Speed", 0.05),
                    new ItemLoot("Ring of Unbound Dexterity", 0.05),
                    new ItemLoot("Ring of Unbound Wisdom", 0.05),
                    new ItemLoot("Ring of Unbound Vitality", 0.05),
                    new ItemLoot("Cloak of the Old Secrets", 0.02),
                    new ItemLoot("Skysplitter Sword", 0.3),
                    new ItemLoot("Agateclaw Dagger", 0.3),
                    new ItemLoot("Staff of Astral Knowledge", 0.3),
                    new ItemLoot("Wand of Ancient Warning", 0.3),
                    new ItemLoot("Abyssal Armor", 0.3),
                    new ItemLoot("Robe of the Elder Warlock", 0.3),
                    new ItemLoot("Griffon Hide Armor", 0.3),
                    new ItemLoot("Wine Cellar Incantation", 0.03),
                    new ItemLoot("Elemental Detonation Spell", 0.05),
                    new ItemLoot("Tome of Holy Guidance", 0.05),
                    new ItemLoot("Quiver of Elvish Mastery", 0.05),
                    new ItemLoot("Helm of the Great General", 0.05),
                    new ItemLoot("Cloak of Ghostly Concealment", 0.05),
                    new ItemLoot("Colossus Shield", 0.05),
                    new ItemLoot("Seal of the Blessed Champion", 0.05),
                    new ItemLoot("Bloodsucker Skull", 0.05),
                    new ItemLoot("Baneserpent Poison", 0.05),
                    new ItemLoot("Giantcatcher Trap", 0.05),
                    new ItemLoot("Planefetter Orb", 0.05),
                    new ItemLoot("Doom Circle", 0.05),
                    new ItemLoot("Scepter of Storms", 0.05),
                    new ItemLoot("Prism of Apparitions", 0.05)
                    )
            )

            .Init("shtrs Inferno",
                new State(
                    new Follow(1, range: 1, coolDown: 1000),
                    new Orbit(1, 4, 15, "shtrs Blizzard"),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 4333),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 3500),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 7250),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 10000)
                )
            )
                .Init("shtrs Yellow Crystal",
                new State(

                    new Follow(0.5, range: 1, coolDown: 1000),
                    new State("Idle",
                        new TimedTransition(2500, "Spin")
                    ),
                    new State("Spin",
                        new TimedTransition(2000, "Pause"),
                        new State("Quadforce1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(200, "Quadforce2")
                        ),
                        new State("Quadforce2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(200, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(200, "Quadforce4")
                        ),
                        new State("Quadforce4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(200, "Quadforce5")
                        ),
                        new State("Quadforce5",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(200, "Quadforce6")
                        ),
                        new State("Quadforce6",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(200, "Quadforce7")
                        ),
                        new State("Quadforce7",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(200, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(200, "Quadforce1")
                        )
                    ),
                    new State("Pause",
                       new TimedTransition(5000, "Spin")
                    )
                )
            )
        .Init("shtrs Red Crystal",
                new State(
                    new Orbit(1, 6, 15, "shtrs The Forgotten King"),

                    new Follow(1, range: 1, coolDown: 1000),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(5, "Spin")
                    ),
                    new State("Spin",
                        new TimedTransition(2000, "Pause"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(200, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(200, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(200, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(200, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(200, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(200, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(200, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(200, "Quadforce1")
                        )
                    ),
                    new State("Pause",
                       new TimedTransition(5000, "Spin")
                    )
                )
            )
                .Init("shtrs Blue Crystal",
                new State(
                    new Orbit(1, 3, 15, "shtrs The Forgotten King"),

                    new Follow(1, range: 1, coolDown: 1000),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(5, "Spin")
                    ),
                    new State("Spin",
                        new TimedTransition(2000, "Pause"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(200, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(200, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(200, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(200, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(200, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(200, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(200, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(200, "Quadforce1")
                        )
                    ),
                    new State("Pause",
                       new TimedTransition(5000, "Spin")
                    )
                )
            )
        .Init("shtrs Green Crystal",
                new State(
                    new Orbit(1, 4, 15, "shtrs The Forgotten King"),

                    new Follow(1, range: 1, coolDown: 1000),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(5, "Spin")
                    ),
                    new State("Spin",
                        new TimedTransition(2000, "Pause"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(200, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(200, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(200, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(200, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(200, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(200, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(200, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(200, "Quadforce1")
                        )
                    ),
                    new State("Pause",
                       new TimedTransition(5000, "Spin")
                    )
                )
            )
            .Init("shtrs Blizzard",
                new State(
                    new Follow(1, range: 1, coolDown: 1000),
                    new Orbit(1, 4, 15, "shtrs Inferno"),

                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 4333),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 3500),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 7250),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 10000)
                )
            );
    }
}
