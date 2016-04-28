#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ MiniRealmSpawner = () => Behav()
        .Init("lil Red Demon",
                  new State(

                                            new State("PlayerChoice",
                          new Taunt("How dare you enter the realm of the Minions..Literally mini minions.."),

                        new TimedTransition(5000, "Invincible")
                              ), 
                                            new State("PlayerChoice2",
                          new Taunt("Ahahaha!"),

                    new EntitiesNotExistsTransition(1000, "PlayerChoice3", "lil White Demon", "lil Sprite God", "lil Medusa", "lil Ent God", "lil Beholder", "lil Flying Brain", "lil Slime God", "lil Ghost God", "lil Djinn")

                              ),
                                             new State("PlayerChoice3",
                          new Taunt("That wasnt a good idea!"),

                        new TimedTransition(5000, "Invincible")
                              ),
                          new State("Invincible",
                          new Taunt("the little minions will now attack!'"),

                        new TimedTransition(25, "NOOOOOOWWWW")
                              ),
                          new State("NOOOOOOWWWW",

                    new Spawn("lil White Demon", 1, coolDown: 10000),
                    new Spawn("lil Sprite God", 1, coolDown: 11000),
                    new Spawn("lil Medusa", 1, coolDown: 12000),
                    new Spawn("lil Ent God", 1, coolDown: 13000),
                    new Spawn("lil Beholder", 1, coolDown: 14000),
                    new Spawn("lil Flying Brain", 1, coolDown: 15000),
                    new Spawn("lil Slime God", 1, coolDown: 16000),
                    new Spawn("lil Ghost God", 1, coolDown: 17000),
                    new Spawn("lil Djinn", 1, coolDown: 18000),
                    new TimedTransition(19250, "PlayerChoice2")


                              )
                        )

           );
    }
}