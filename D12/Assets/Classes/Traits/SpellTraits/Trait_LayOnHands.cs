/// Trait_LayOnHands.cs
/// D12 Team

using System.Collections.Generic;
using Assets.Classes.Character;

namespace Assets.Classes.Traits
{
    /// <summary>
    /// Spell Trait: Lay On Hands 1
    /// </summary>
    public class LayOnHands1 : SpellTrait
    {
        public LayOnHands1(TraitStatus status) : base("Lay on Hands 1", "touch, heal a target for 1-2 hits of damage", 1, 1, 1, 1, status) { }

        public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            // Is there a target to heal? Range checking will be done by a higher up class to account for range buffs
            if (goodTargets.Count != 1)
            {
                msg = "Invalid targets";
                return false;
            }

            // The spell's target BaseCharacter
            var target = goodTargets[0];

            // Heal the target
            var regen = (roll >= 12) ? 2 : 1;
            target.Stats.Modify(HP: regen);

            // Return message and success
            msg = "Healed " + target.Info.Name + " for " + regen + " HP.";
            return true;
        }
    }

    /// <summary>
    /// Spell Trait: Lay On Hands 2
    /// </summary>
    public class LayOnHands2 : SpellTrait
    {
        public LayOnHands2(TraitStatus status) : base("Lay on Hands 2", "touch, heal a target for 1-2 hits of damage", 1, 1, 1, 1, status) { }


        public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            // Is there a target to heal? Range checking will be done by a higher up class to account for range buffs
            if (goodTargets.Count != 1)
            {
                msg = "Invalid targets";
                return false;
            }

            // The spell's target BaseCharacter
            var target = goodTargets[0];

            // Heal the target
            var regen = (roll >= 10) ? 2 : 1;
            target.Stats.Modify(HP: regen);

            // Return message and success
            msg = "Healed " + target.Info.Name + " for " + regen + " HP.";
            return true;
        }
    }

    /// <summary>
    /// Spell Trait: Lay On Hands 3
    /// </summary>
    public class LayOnHands3 : SpellTrait
    {
        public LayOnHands3(TraitStatus status) : base("Lay on Hands 3", "touch, heal a target for 2-3 hits of damage", 1, 1, 1, 1, status) { }


        public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            // Is there a target to heal? Range checking will be done by a higher up class to account for range buffs
            if (goodTargets.Count != 1)
            {
                msg = "Invalid targets";
                return false;
            }

            // The spell's target BaseCharacter
            var target = goodTargets[0];

            // Heal the target
            var regen = (roll >= 12) ? 3 : 2;
            target.Stats.Modify(HP: regen);

            // Return message and success
            msg = "Healed " + target.Info.Name + " for " + regen + " HP.";
            return true;
        }
    }


    /// <summary>
    /// Spell Trait: Lay On Hands 4
    /// </summary>
    public class LayOnHands4 : SpellTrait
    {
        public LayOnHands4(TraitStatus status) : base("Lay on Hands 4", "touch, heal a target for 2-3 hits of damage", 1, 1, 1, 1, status) { }


        public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            // Is there a target to heal? Range checking will be done by a higher up class to account for range buffs
            if (goodTargets.Count != 1)
            {
                msg = "Invalid targets";
                return false;
            }

            // The spell's target BaseCharacter
            var target = goodTargets[0];

            // Heal the target
            var regen = (roll >= 8) ? 3 : 2;
            target.Stats.Modify(HP: regen);

            // Return message and success
            msg = "Healed " + target.Info.Name + " for " + regen + " HP.";
            return true;
        }
    }


    /// <summary>
    /// Spell Trait: Lay On Hands 5
    /// </summary>
    public class LayOnHands5 : SpellTrait
    {
        public LayOnHands5(TraitStatus status) : base("Lay on Hands 5", "touch, heal a target for 3 hits of damage", 1, 1, 1, 1, status) { }


        public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            // Is there a target to heal? Range checking will be done by a higher up class to account for range buffs
            if (goodTargets.Count != 1)
            {
                msg = "Invalid targets";
                return false;
            }

            // The spell's target BaseCharacter
            var target = goodTargets[0];

            // Heal the target
            var regen = 3;
            target.Stats.Modify(HP: regen);

            // Return message and success
            msg = "Healed " + target.Info.Name + " for " + regen + " HP.";
            return true;
        }
    }

    /// <summary>
    /// Lay on Hands Crossroad Trait: Blessed be the Weak
    /// </summary>
    public class BlessedBeTheWeak : EffectTrait
    {
        public BlessedBeTheWeak(TraitStatus status) : base("Blessed be the Weak", "+1 hit healed to those with less health than you.", 1, status) { IsCrossroad = true; }

		public override bool DoSomething(out string msg, List<object> additionalObjects = null)
		{
            return base.DoSomething(out msg, additionalObjects);
		}
	}

    /// <summary>
    /// Lay on Hands Crossroad Trait: Blessed be the Giver
    /// </summary>
    public class BlessedBeTheGiver : EffectTrait
    {
        public BlessedBeTheGiver(TraitStatus status) : base("Blessed be the Giver", "+1 hit healed when healing yourself.", 1, status) { IsCrossroad = true; }

        public override bool DoSomething(out string msg, List<object> additionalObjects = null)
        {
            return base.DoSomething(out msg, additionalObjects);
        }
    }

    /// <summary>
    /// Lay on Hands Crossroad Trait: Radiant Touch
    /// </summary>
    public class RadiantTouch : EffectTrait
    {
        public RadiantTouch(TraitStatus status) : base("Radiant Touch","Lay on Hands heals everything within 5 meters of target", 1, status) { IsCrossroad = true; }

        public override bool DoSomething(out string msg, List<object> additionalObjects = null)
        {
            return base.DoSomething(out msg, additionalObjects);
        }
    }

    /// <summary>
    /// Lay on Hands Crossroad Trait: Boundless Gifts
    /// </summary>
    public class BoundlessGifts : EffectTrait
    {
        public BoundlessGifts(TraitStatus status) : base("Boundless Gifts", "Lay on Hands costs 0 mana", 1, status) { IsCrossroad = true; }

        public override bool DoSomething(out string msg, List<object> additionalObjects = null)
        {
            return base.DoSomething(out msg, additionalObjects);
        }
    }
}