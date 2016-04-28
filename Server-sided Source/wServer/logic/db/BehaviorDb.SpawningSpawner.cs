#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ SpawningArena = () => Behav()
        .Init("0AArenaSpawner",
                  new State(
                new TransformOnDeath("0AArenaSpawner2"),
                new DropPortalOnDeath("SpawningArena", percent: 100, dropDelaySec: 2, XAdjustment: 0, YAdjustment: 2, PortalDespawnTimeSec: 10),
                new DropPortalOnDeath("Eventspawner Portal", percent: 100, dropDelaySec: 2, XAdjustment: 2, YAdjustment: 0, PortalDespawnTimeSec: 10),

                                            new State("PlayerChoice",
                          new Taunt("A Spawning Arena and Event Arena will be opened in around 15 seconds, make sure you enter it!"),

                        new TimedTransition(15000, "WOWWWW")
                              ),
                                            new State("WOWWWW",
                                                new Taunt("Now opening, you got 10 seconds to enter it! If you don't want to, wait for a new one!"),
                                                new Taunt("New one will be spawned in 30 seconds!"),
                                                 new TimedTransition(3000, "suicide")

                      

                          ),

                        new State("suicide",
                       new Suicide()
                            )
                      )
            )
                .Init("0AArenaSpawner2",
                  new State(
                new TransformOnDeath("0AArenaSpawner"),

                                            new State("PlayerChoice",

                        new TimedTransition(30000, "suicide")
                              ),
                                            new State("WOWWWW",
                                                new Taunt("Now opening, you got 10 seconds to enter it! If you don't want to, wait for a new one!"),
                                                 new TimedTransition(3000, "suicide")



                          ),

                        new State("suicide",
                             new ChangeSize(-20, 25),
                             new Taunt(1, 7000, "New Arenas open every 60 seconds!"),
                       new Suicide()







                        )
                          )


            );
    }
}