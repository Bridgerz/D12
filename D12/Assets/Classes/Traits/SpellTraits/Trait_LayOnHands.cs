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
        public LayOnHands1(bool active) : base("Lay on Hands 1", "touch, heal a target for 1-2 hits of damage", 1, 1, 1, 1, active) { }

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
        public LayOnHands2(bool active) : base("Lay on Hands 2", "touch, heal a target for 1-2 hits of damage", 1, 1, 1, 1, active) { }


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
        public LayOnHands3(bool active) : base("Lay on Hands 3", "touch, heal a target for 2-3 hits of damage", 1, 1, 1, 1, active) { }


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
        public LayOnHands4(bool active) : base("Lay on Hands 4", "touch, heal a target for 2-3 hits of damage", 1, 1, 1, 1, active) { }


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
        public LayOnHands5(bool active) : base("Lay on Hands 5", "touch, heal a target for 3 hits of damage", 1, 1, 1, 1, active) { }


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
}