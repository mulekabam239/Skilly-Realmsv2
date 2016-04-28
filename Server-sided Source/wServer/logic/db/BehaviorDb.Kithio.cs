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

        private _ Kithio = () => Behav()
            .Init("Kithio the Belly Monster",
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

                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Once I met a guy."),
                        new TimedTransition(5000, "TalkShit1")
                        ),
                    new State("TalkShit1",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("I ate him, he tasted like roast beef..."),
                        new TimedTransition(5000, "TalkShit2")
                        ), 
                    new State("TalkShit2",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("He wasn't too large though, so he didn't become a full course meal sadly."),
                        new TimedTransition(5000, "TalkShit3")
                        ),
                    new State("TalkShit3",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("He escaped he said, truth was, I cloned him and ate the other part."),
                        new TimedTransition(5000, "TalkShit4")
                        ),
                     new State("TalkShit4",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("That being said, I could clone some other people. Right?"),
                         new TimedTransition(1600, "RAGE_MODE")
                        ),
                    new State("RAGE_MODE",

                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                new InvisiToss("NoobHereo Fake", range: 5.0, angle: 180),
                                new InvisiToss("NoobHereo Real", range: 5.0, angle: 360),
                                
                                new TimedTransition(0, "shoot1")
                            ),
                            new State("shoot1",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                             new Taunt("Ah, so what we got here, we cloned a NoobHereo, pretty cool I could say."),
                                new TimedTransition(1600, "shoot2")
                            ),
                            new State("shoot2",
                                  new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                             new Taunt("It's up to you to make up the decision for which one I shall eat. Be fast though."),
                                new TimedTransition(1600, "shoot3")
                            ),
                            new State("shoot3",
                                  new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                             new Taunt("Decide now."),

                                new Flash(0xfff0066, flashPeriod: 0.5, flashRepeats: 10),
                                new EntityNotExistsTransition("NoobHereo Fake", 100, "WeakendPrep"),
                                new EntityNotExistsTransition("NoobHereo Real", 100, "SuperPowersPrep")
                                ),
                            new State("SuperPowersPrep",
                                new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                             new Taunt("You've chosen the real NoobHereo, prepare to die!"),

                            new TimedTransition(12500, "SuperPowers")
), 
                            new State("SuperPowers",
                                new Shoot(14, 2, shootAngle: 15, projectileIndex: 0),
                            new Shoot(14, 2, shootAngle: 15, projectileIndex: 1),
                                new TimedTransition(12500, "SuperPowers2")
                                ),
                            new State("SuperPowers2",
                                new Shoot(14, 3, shootAngle: 15, projectileIndex: 1),
                            new Shoot(14, 6, shootAngle: 15, projectileIndex: 2),
                                new TimedTransition(12500, "SuperPowers")

                                ),
                            new State("WeakendPrep",
                                 new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                             new Taunt("You've chosen the fake NoobHereo, prepare to die!"),
                                      new TimedTransition(12500, "Weakend")
                                ),
                            new State("Weakend",
                                new Flash(0xf663300, flashPeriod: 0.2, flashRepeats: 1),
                                new Shoot(12, 1, shootAngle: 15, projectileIndex: 3),
                                 new TimedTransition(12500, "Weakend1")
                                ),

                            new State("Weakend1",
                                new Shoot(12, 2, shootAngle: 15, projectileIndex: 4),
                                 new TimedTransition(12500, "Weakend")
                      
                        )
                    
                )
            )
        .Init("0ANoobHereoMinion",
                new State(
                    new Wander(0.2),
                    new Shoot(12, 3, 10, coolDown: 1000)
                    
                    )
            )
            .Init("NoobHereo Fake",
                new State(

                    new EntityNotExistsTransition("Kithio the Belly Monster", 100, "Despawn"),
                            new State("shoot1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),

                                new Taunt("What the hell is this? Kithio?"),
                                new TimedTransition(1600, "shoot2")
                            ),
                            new State("shoot2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                new Taunt("What are you doing?"),
                                new TimedTransition(1600, "shoot3")
                            ),
                            new State("shoot3",
                                new Flash(0xfff0066, flashPeriod: 0.5, flashRepeats: 10),
                                new Taunt("I'm real.")
                            
                        
                    ),
                    new State("Despawn",
                        new Timed(1000, new Suicide())
                    )
                )
            )
            .Init("NoobHereo Real",
                new State(

                    new EntityNotExistsTransition("Kithio the Belly Monster", 100, "Despawn"),
                            new State("shoot1",

                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),

                                new Taunt("Haha, I like being cloned!"),
                                new TimedTransition(1600, "shoot2")
                            ),
                            new State("shoot2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                new Taunt("Wait, what?"),
                                new TimedTransition(1600, "shoot3")
                            ),
                            new State("shoot3",
                                
                                new Flash(0xfff0066, flashPeriod: 0.5, flashRepeats: 10),
                                new Taunt("I'm the real one!")
                            
                        
                    ),
                    new State("Despawn",
                        new Timed(1000, new Suicide())
                    
                
            

                   )
                )
            );
    }
}
