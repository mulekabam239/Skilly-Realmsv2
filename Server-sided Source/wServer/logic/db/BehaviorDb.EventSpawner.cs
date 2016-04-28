#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ EventSpawner = () => Behav()
        .Init("0AAAEVENTSPAWNERXD",
                  new State(
                new TransformOnDeath("0AAAEVENTSPAWNERXDD"),

                                            new State("PlayerChoice",
                          new Taunt("Hey, today because I'm nice I will give you a choice to what I should spawn!"),

                        new TimedTransition(5000, "PlayerChoice2")
                              ),
                                            new State("WOWWWW",
                                                new Taunt("Up for another round, that's what I'm doing!"),
                                                 new TimedTransition(3000, "PlayerChoice2")
                                                ),
                          new State("PlayerChoice2",
                          new Taunt("So choose one of the following 'CUBE' 'SKULL' 'SPHINX' 'CRYSTAL'"),

                        new TimedTransition(25, "NOOOOOOWWWW")

                      ),
                          new State("NOOOOOOWWWW",
                               new ChatTransition("Cube God Prep", "cube"),
                        new ChatTransition("Skull Shrine Prep", "skull"),
                        new ChatTransition("Mysterious Crystal Prep", "crystal"),
                        new ChatTransition("Grand Sphinx Prep", "sphinx"),
                               new ChatTransition("Cube God Prep", "CUBE"),
                        new ChatTransition("Skull Shrine Prep", "SKULL"),
                        new ChatTransition("Mysterious Crystal Prep", "CRYSTAL"),
                        new ChatTransition("Grand Sphinx Prep", "SPHINX")
                              ),
                          new State("Cube God Prep",
                              new Taunt("Cube God that is in 10 seconds"),
                              new TimedTransition(0, "Cube God")
                              ),
                    new State("Cube God",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Cube God", 1, coolDown: 10000),

                        new TimedTransition(12000, "Cube God Check")
                        ),
                    new State("Cube God Check",
                        new EntityNotExistsTransition("Cube God", 10000, "suicide")
                        ),
                          new State("Skull Shrine Prep",
                              new Taunt("Skull Shrine that is in 10 seconds"),
                              new TimedTransition(0, "Skull Shrine")
                              ),
                      new State("Skull Shrine",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Skull Shrine", 1, coolDown: 10000),

                        new TimedTransition(12000, "Skull Shrine Check")
                        ),
                      new State("Skull Shrine Check",
                        new EntityNotExistsTransition("Skull Shrine", 10000, "suicide")
                         ),
                          new State("Mysterious Crystal Prep",
                              new Taunt("Mysterious Crystal that is in 10 seconds"),
                              new TimedTransition(0, "Crystal")
                              ),
                      new State("Crystal",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Mysterious Crystal", 1, coolDown: 10000),

                        new TimedTransition(12000, "Crystal Check")
                        ),
                      new State("Crystal Check",
                        new EntityNotExistsTransition("Mysterious Crystal", 12000, "Prisoner Check")
                        ),
                      new State("Prisoner Check",
                        new EntityNotExistsTransition("Crystal Prisoner", 12000, "suicide")
                         ),
                          new State("Grand Sphinx Prep",
                              new Taunt("Grand Sphinx Prep that is in 10 seconds"),
                              new TimedTransition(0, "Grand Sphinx")
                              ),
                      new State("Grand Sphinx",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Grand Sphinx", 1, coolDown: 10000),

                        new TimedTransition(12000, "Grand Sphinx Check")
                        ),
                      new State("Grand Sphinx Check",
                        new EntityNotExistsTransition("Grand Sphinx", 2000, "suicide")
                          ),

                        new State("suicide",
                        new Suicide()

            )
                        )
                          )
                .Init("0AAAEVENTSPAWNERXDDD",
                  new State(
                new TransformOnDeath("0AAAEVENTSPAWNERXDD"),

                                            new State("PlayerChoice",
                          new Taunt("Let's do another! :)"),

                        new TimedTransition(5000, "PlayerChoice2")
                              ),
                                            new State("WOWWWW",
                                                new Taunt("Up for another round, that's what I'm doing!"),
                                                 new TimedTransition(3000, "PlayerChoice2")
                                                ),
                          new State("PlayerChoice2",
                          new Taunt("So choose one of the following 'CUBE' 'SKULL' 'SPHINX' 'CRYSTAL'"),

                        new TimedTransition(25, "NOOOOOOWWWW")

                      ),
                          new State("NOOOOOOWWWW",
                               new ChatTransition("Cube God Prep", "cube"),
                        new ChatTransition("Skull Shrine Prep", "skull"),
                        new ChatTransition("Mysterious Crystal Prep", "crystal"),
                        new ChatTransition("Grand Sphinx Prep", "sphinx"),
                               new ChatTransition("Cube God Prep", "CUBE"),
                        new ChatTransition("Skull Shrine Prep", "SKULL"),
                        new ChatTransition("Mysterious Crystal Prep", "CRYSTAL"),
                        new ChatTransition("Grand Sphinx Prep", "SPHINX")
                              ),
                          new State("Cube God Prep",
                              new Taunt("Cube God that is in 10 seconds"),
                              new TimedTransition(0, "Cube God")
                              ),
                    new State("Cube God",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Cube God", 1, coolDown: 10000),

                        new TimedTransition(12000, "Cube God Check")
                        ),
                    new State("Cube God Check",
                        new EntityNotExistsTransition("Cube God", 10000, "suicide")
                        ),
                          new State("Skull Shrine Prep",
                              new Taunt("Skull Shrine that is in 10 seconds"),
                              new TimedTransition(0, "Skull Shrine")
                              ),
                      new State("Skull Shrine",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Skull Shrine", 1, coolDown: 10000),

                        new TimedTransition(12000, "Skull Shrine Check")
                        ),
                      new State("Skull Shrine Check",
                        new EntityNotExistsTransition("Skull Shrine", 10000, "suicide")
                         ),
                          new State("Mysterious Crystal Prep",
                              new Taunt("Mysterious Crystal that is in 10 seconds"),
                              new TimedTransition(0, "Crystal")
                              ),
                      new State("Crystal",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Mysterious Crystal", 1, coolDown: 10000),

                        new TimedTransition(12000, "Crystal Check")
                        ),
                      new State("Crystal Check",
                        new EntityNotExistsTransition("Mysterious Crystal", 12000, "Prisoner Check")
                        ),
                      new State("Prisoner Check",
                        new EntityNotExistsTransition("Crystal Prisoner", 12000, "suicide")
                         ),
                          new State("Grand Sphinx Prep",
                              new Taunt("Grand Sphinx Prep that is in 10 seconds"),
                              new TimedTransition(0, "Grand Sphinx")
                              ),
                      new State("Grand Sphinx",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Grand Sphinx", 1, coolDown: 10000),

                        new TimedTransition(12000, "Grand Sphinx Check")
                        ),
                      new State("Grand Sphinx Check",
                        new EntityNotExistsTransition("Grand Sphinx", 2000, "suicide")
                          ),

                        new State("suicide",
                        new Suicide()


            )
                        )
                          )
              .Init("0AAAEVENTSPAWNERXDD",
                  new State(
                new TransformOnDeath("0AAAEVENTSPAWNERXDDD"),

                                            new State("PlayerChoice",
                          new Taunt("Up for another round, that's what I'm doing!"),

                        new TimedTransition(5000, "PlayerChoice2")
                              ),
                                            new State("WOWWWW",
                                                new Taunt("Up for another round, that's what I'm doing!"),
                                                 new TimedTransition(3000, "PlayerChoice2")
                                                ),
                          new State("PlayerChoice2",
                          new Taunt("So choose one of the following 'CUBE' 'SKULL' 'SPHINX' 'CRYSTAL'"),

                        new TimedTransition(25, "NOOOOOOWWWW")

                      ),
                          new State("NOOOOOOWWWW",
                               new ChatTransition("Cube God Prep", "cube"),
                        new ChatTransition("Skull Shrine Prep", "skull"),
                        new ChatTransition("Mysterious Crystal Prep", "crystal"),
                        new ChatTransition("Grand Sphinx Prep", "sphinx"),
                               new ChatTransition("Cube God Prep", "CUBE"),
                        new ChatTransition("Skull Shrine Prep", "SKULL"),
                        new ChatTransition("Mysterious Crystal Prep", "CRYSTAL"),
                        new ChatTransition("Grand Sphinx Prep", "SPHINX")
                              ),
                          new State("Cube God Prep",
                              new Taunt("Cube God that is in 10 seconds"),
                              new TimedTransition(0, "Cube God")
                              ),
                    new State("Cube God",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Cube God", 1, coolDown: 10000),

                        new TimedTransition(12000, "Cube God Check")
                        ),
                    new State("Cube God Check",
                        new EntityNotExistsTransition("Cube God", 10000, "suicide")
                        ),
                          new State("Skull Shrine Prep",
                              new Taunt("Skull Shrine that is in 10 seconds"),
                              new TimedTransition(0, "Skull Shrine")
                              ),
                      new State("Skull Shrine",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Skull Shrine", 1, coolDown: 10000),

                        new TimedTransition(12000, "Skull Shrine Check")
                        ),
                      new State("Skull Shrine Check",
                        new EntityNotExistsTransition("Skull Shrine", 10000, "suicide")
                         ),
                          new State("Mysterious Crystal Prep",
                              new Taunt("Mysterious Crystal that is in 10 seconds"),
                              new TimedTransition(0, "Crystal")
                              ),
                      new State("Crystal",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Mysterious Crystal", 1, coolDown: 10000),

                        new TimedTransition(12000, "Crystal Check")
                        ),
                      new State("Crystal Check",
                        new EntityNotExistsTransition("Mysterious Crystal", 12000, "Prisoner Check")
                        ),
                      new State("Prisoner Check",
                        new EntityNotExistsTransition("Crystal Prisoner", 12000, "suicide")
                         ),
                          new State("Grand Sphinx Prep",
                              new Taunt("Grand Sphinx Prep that is in 10 seconds"),
                              new TimedTransition(0, "Grand Sphinx")
                              ),
                      new State("Grand Sphinx",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),

                    new Spawn("Grand Sphinx", 1, coolDown: 10000),

                        new TimedTransition(12000, "Grand Sphinx Check")
                        ),
                      new State("Grand Sphinx Check",
                        new EntityNotExistsTransition("Grand Sphinx", 2000, "suicide")
                            ),

                        new State("suicide",
                        new Suicide()


                        )
                          )


            );
    }
}