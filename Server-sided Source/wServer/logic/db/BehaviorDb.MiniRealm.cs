#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ LilMountain = () => Behav()
            .Init("lil White Demon",
                new State(
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(.4, range: 7),
                        new Wander(0.2)
                        ),
                    new Shoot(10, 2, 20, predictive: 1, coolDown: 500)
                    



                    )
            )
            .Init("lil Sprite God",
                new State(
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Wander(0.2)
                        ),
                    new Shoot(12, projectileIndex: 0, count: 2, shootAngle: 10),
                    new Shoot(10, projectileIndex: 1, predictive: 1)
                    


                    )
            )

            .Init("lil Medusa",
                new State(
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(.4, range: 7),
                        new Wander(0.2)
                        ),
                    new Shoot(12, 3, 10, coolDown: 1000),
                    new Grenade(4, 52, 8, coolDown: 3000)
                    


                    )
            )
 .Init("lil Ent God",
                new State(
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(.4, range: 7),
                        new Wander(0.2)
                        ),
                    new Shoot(12, 2, 10, predictive: 1, coolDown: 1250)

                    


                    )
            )
            .Init("lil Beholder",
             new State(
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(.4, range: 7),
                        new Wander(0.2)
                        ),
                    new Shoot(12, projectileIndex: 0, count: 3, shootAngle: 72, predictive: 0.5, coolDown: 750),
                    new Shoot(10, projectileIndex: 1, predictive: 1)

					
					
					
                    )
            )
            .Init("lil Flying Brain",
                new State(
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(.4, range: 7),
                        new Wander(0.2)
                        ),
                    new Shoot(12, 2, 72, coolDown: 500)


                    )
            )
            .Init("lil Slime God",
                new State(
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(.4, range: 7),
                        new Wander(0.2)
                        ),
                    new Shoot(12, projectileIndex: 0, count: 3, shootAngle: 10, predictive: 1, coolDown: 1000),
                    new Shoot(10, projectileIndex: 1, predictive: 1, coolDown: 650)


                    )
            )
            .Init("lil Ghost God",
                new State(
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(.4, range: 7),
                        new Wander(0.2)
                        ),
                    new Shoot(12, 4, 25, predictive: 0.5, coolDown: 900),
                    new DropPortalOnDeath("Undead Lair Portal", 20)


                    )
            )
            .Init("lil Djinn",
                new State(
                    new State("Idle",
                        new Prioritize(
                            new StayAbove(1, 200),
                        new Wander(0.2)
                            ),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(8, "Attacking")
                        ),
                    new State("Attacking",
                        new State("Bullet",
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 100, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 110, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 150, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 160, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 160, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 130, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 120, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 1800, shootAngle: 90),
                            new TimedTransition(2000, "Wait")
                            ),
                        new State("Wait",
                            new Follow(0.7, range: 0.5),
                            new Flash(0xff00ff00, 0.1, 20),
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(2000, "Bullet")
                            ),
                        new NoPlayerWithinTransition(13, "Idle"),
                        new HpLessTransition(0.5, "FlashBeforeExplode")
                        ),
                    new State("FlashBeforeExplode",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xff0000, 0.3, 3),
                        new TimedTransition(1000, "Explode")
                        ),
                    new State("Explode",
                        new Shoot(0, 10, 36, fixedAngle: 0),
                        new Suicide()
                        


						
                    
            
           
                        )
                    

					)
			
                    
            )
            ;
    }
}