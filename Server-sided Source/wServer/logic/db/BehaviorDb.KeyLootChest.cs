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

        private _ KeyLootChest = () => Behav()
            
            
            .Init("Key Loot Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new Threshold(0.1,
                    new ItemLoot("Draconis Key", 0.1),
                    new ItemLoot("Totem Key", 0.1),
                    new ItemLoot("Oryx Chicken Key", 0.1),
                    new ItemLoot("Manor Key", 0.1),
                    new ItemLoot("Woodland Labyrinth Key", 0.1),
                    new ItemLoot("Deadwater Docks Key", 0.1),
                    new ItemLoot("The Crawling Depths Key", 0.1),
                    new ItemLoot("Shaitan's Key", 0.1),
                    new ItemLoot("Theatre Key", 0.1),
                    new ItemLoot("Ice Cave Key", 0.1),
                    new ItemLoot("Kithio Key", 0.1),
                    new ItemLoot("Davy's Key", 0.1),
                    new ItemLoot("Tomb of the Ancients Key", 0.1),
                    new ItemLoot("Undead Lair Key", 0.1),
                    new ItemLoot("Ocean Trench Key", 0.1),
                    new ItemLoot("Shatters Key", 0.1),
                    new ItemLoot("Pacman Key", 0.1),
                    new ItemLoot("Sprite World Key", 0.1),
                    new ItemLoot("Bella's Key", 0.1),
                    new ItemLoot("ElderCube Key", 0.1),
                    new ItemLoot("ElderSkull Key", 0.1),
                    new ItemLoot("Cemetery Key", 0.1),
                    new ItemLoot("Candy Key", 0.1),
                    new ItemLoot("Sprite World Key", 0.1),
                    new ItemLoot("Battle Nexus Key", 0.1),
                    new ItemLoot("Abyss of Demons Key", 0.1)
                )
            );
    }
}
