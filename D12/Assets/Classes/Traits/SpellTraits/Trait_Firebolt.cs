/// Trait_Firebolt.cs
/// D12 Team
/// Firebolt spell traits

using System.Collections.Generic;
using Assets.Classes.Character;

namespace Assets.Classes.Traits
{
    /// <summary>
    /// Spell Trait: Firebolt 1
    /// </summary>
    public class Firebolt1 : SpellTrait
    {
        public Firebolt1(TraitStatus status) : base("Firebolt 1", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, status) { }

        public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            if (badTargets.Count != 1)
            {
                msg = "Invalid targets";
                return false;
            }

            // The spell's target BaseCharacter
            var target = badTargets[0];

            // Calculate damage based on roll
            var dmg = (roll > 8) ? -2 : -1;

            // Damage the target
            // TODO: Check targets resistances.
            target.Stats.Modify(HP: dmg);

            // Return confirmation message and success
            msg = "Hit " + target.Info.Name + " for " + dmg + " damage.";
            return true;
        }
    }

    /// <summary>
    /// Spell Trait: Firebolt 2
    /// </summary>
    public class Firebolt2 : SpellTrait
    {
        public Firebolt2(TraitStatus status) : base("Firebolt 2", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, status) { }

        public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            return base.Cast(out msg, roll, badTargets, goodTargets, additionalObjects);
        }
    }

    /// <summary>
    /// Spell Trait: Firebolt 3
    /// </summary>
    public class Firebolt3 : SpellTrait
    {
        public Firebolt3(TraitStatus status) : base("Firebolt 3", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, status) { }

        public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            return base.Cast(out msg, roll, badTargets, goodTargets, additionalObjects);
        }
    }

    /// <summary>
    /// Spell Trait: Firebolt 4
    /// </summary>
    public class Firebolt4 : SpellTrait
    {
        public Firebolt4(TraitStatus status) : base("Firebolt 4", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, status) { }

        public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            return base.Cast(out msg, roll, badTargets, goodTargets, additionalObjects);
        }
    }


    /// <summary>
    /// Spell Trait: Firebolt 4
    /// </summary>
    public class Firebolt5 : SpellTrait
    {
        public Firebolt5(TraitStatus status) : base("Firebolt 5", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, status) { }

        public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            return base.Cast(out msg, roll, badTargets, goodTargets, additionalObjects);
        }
    }

    /// <summary>
    /// Firebolt Crossroad Trait: Homeseeking Embers
    /// </summary>
    public class HomeseekingEmbers : EffectTrait
    {
        public HomeseekingEmbers(TraitStatus status) : base("Homeseeking Embers", "missed firebolts consume no mana", 1, status) { IsCrossroad = true; }

        public override bool DoSomething(out string msg, List<object> additionalObjects = null)
        {
            return base.DoSomething(out msg, additionalObjects);
        }
    }

    /// <summary>
    /// Firebolt Crossroad Trait: Unerring Bolt
    /// </summary>
    public class UnerringBolt : SkillTrait
    {
        public UnerringBolt(TraitStatus status) : base("Unerring Bolt", "+3 to rolls when attacking with firebolt", 1, status) { IsCrossroad = true; }
    }

    /// <summary>
    /// Firebolt Crossroad Trait: Two Embers
    /// </summary>
    public class TwoEmbers : EffectTrait
    {
        public TwoEmbers(TraitStatus status) : base("Two Embers", "firebolt casts twice targeting two different targets", 1, status) { IsCrossroad = true; }

        public override bool DoSomething(out string msg, List<object> additionalObjects = null)
        {
            return base.DoSomething(out msg, additionalObjects);
        }
    }

    /// <summary>
    /// Firebolt Crossroad Trait: IgneosBirth
    /// </summary>
    public class IgneosBirth : EffectTrait
    {
        public IgneosBirth(TraitStatus status) : base("Igneos Birth", "after casting firebolt you may choose to continue casting firebolt for free as long as no other action is taken", 1, status) { IsCrossroad = true; }

        public override bool DoSomething(out string msg, List<object> additionalObjects = null)
        {
            return base.DoSomething(out msg, additionalObjects);
        }
    }
}