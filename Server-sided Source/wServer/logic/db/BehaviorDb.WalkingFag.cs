#region

using wServer.logic.behaviors;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ WalkingFagg = () => Behav()
            .Init("0AAAAAAA",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(0.8, 5),
                        new Wander(0.2)
                        ),
                    new State("Waiting",
                        new TimedTransition(2500, "Attacking")
                        ),
                    new State("Attacking",
                        new Taunt(1, 32000, "Welcome to TEST! Enjoy your stay! :') Use /glands in realm!"),
                        new Taunt(1, 62500, "Go battle, I shall see you soon warrior! :'3 Use /glands in realm!")
                        )
                    
            ))
            ;
    }
}
