#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ DavyJones = () => Behav()
            .Init("Davy Jones",
                new State(
                    new DropPortalOnDeath("Glowing Realm Portal", 100, PortalDespawnTimeSec: 360),
                    new State("Floating",
                        new ChangeSize(100, 100),
                        new SetAltTexture(1),
                        new SetAltTexture(3),
                        new Wander(.2),
                        new Shoot(10, 5, 10, 0, coolDown: 2000),
                        new Shoot(10, 1, 10, 1, coolDown: 4000),
                        new EntityNotExistsTransition("Ghost Lanturn Off", 10, "Vunerable"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                        ),
                    new State("CheckOffLanterns",
                        new SetAltTexture(2),
                        new StayCloseToSpawn(.1, 3),
                        new Shoot(10, 5, 10, 0, coolDown: 2000),
                        new Shoot(10, 1, 10, 1, coolDown: 4000),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Ghost Lanturn Off", 10, "Vunerable")
                        ),
                    new State("Vunerable",
                        new SetAltTexture(2),
                        new StayCloseToSpawn(.1, 0),
                        new Shoot(10, 5, 10, 0, coolDown: 2000),
                        new Shoot(10, 1, 10, 1, coolDown: 4000),
                        new TimedTransition(5000, "deactivate")
                        ),
                    new State("deactivate",
                        new SetAltTexture(2),
                        new StayCloseToSpawn(.1, 0),
                        new Shoot(10, 5, 10, 0, coolDown: 2000),
                        new Shoot(10, 1, 10, 1, coolDown: 4000),
                        new EntityNotExistsTransition("Ghost Lanturn On", 10, "Floating")
                        )
                    ),
                new Threshold(0.1),
                new TierLoot(3, ItemType.Ring, 0.2),
                new TierLoot(7, ItemType.Armor, 0.2),
                new TierLoot(8, ItemType.Weapon, 0.2),
                new TierLoot(4, ItemType.Ability, 0.1),
                new TierLoot(8, ItemType.Armor, 0.1),
                new TierLoot(4, ItemType.Ring, 0.05),
                new TierLoot(9, ItemType.Armor, 0.03),
                new TierLoot(5, ItemType.Ability, 0.03),
                new TierLoot(9, ItemType.Weapon, 0.03),
                new TierLoot(10, ItemType.Armor, 0.02),
                new TierLoot(10, ItemType.Weapon, 0.02),
                new TierLoot(11, ItemType.Armor, 0.01),
                new TierLoot(11, ItemType.Weapon, 0.01),
                new TierLoot(5, ItemType.Ring, 0.01),
                    new ItemLoot("Shadow's Strike", 0.012),
                    new ItemLoot("Dirk of Sound Circles", 0.012),
                    new ItemLoot("Thunderous Scimtar", 0.012),
                    new ItemLoot("Deadly Fiery Cutlass", 0.012),
                    new ItemLoot("Medium Food", 0.2),
                new ItemLoot("Spirit Dagger", 0.012),
                new ItemLoot("Wine Cellar Incantation", 0.01),
                new ItemLoot("Spectral Cloth Armor", 0.012),
                new ItemLoot("Ghostly Prism", 0.012),
                new ItemLoot("Captain's Ring", 0.012),
                new ItemLoot("Potion of Wisdom", 0.5)
            )
            .Init("Ghost Lanturn Off",
                new State(
                    new TransformOnDeath("Ghost Lanturn On")
                    )
            )
            .Init("Ghost Lanturn On",
                new State(
                    new State("idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "deactivate")
                        ),
                    new State("deactivate",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Ghost Lanturn Off", 10, "shoot"),
                        new TimedTransition(10000, "gone")
                        ),
                    new State("shoot",
                        new Shoot(10, 6, coolDown: 9000001, coolDownOffset: 100),
                        new TimedTransition(1000, "gone")
                        ),
                    new State("gone",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Transform("Ghost Lanturn Off")
                        )
                    )
            );
    }
}