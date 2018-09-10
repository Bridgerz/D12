/// Trait_LayOnHands.cs
/// D12 Team

using System.Collections.Generic;

/// <summary>
/// Spell Trait: Lay On Hands 1
/// </summary>
public class LayOnHands1 : SpellTrait
{
    public LayOnHands1(bool active) : base("Lay on Hands 1", "touch, heal a target for 1 hit of damage", 1, 1, 1, 1, active) { }

    public override bool Cast(out string msg, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, object[] additionalObjects = null)
    {
        // Is there a target to heal? Range checking will be done by a higher up class to account for range buffs
        if(goodTargets.Count != 1)
        {
            msg = "Invalid targets";
            return false;
        }

        // The spell's target BaseCharacter
        var target = goodTargets[0];

        // Heal the target
        var regen = 1;
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
    public LayOnHands2(bool active) : base("Lay on Hands 1", "touch, heal a target for 1 hit of damage", 1, 1, 1, 1, active) { }

    public override bool Cast(out string msg, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, object[] additionalObjects = null)
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
        var regen = 2;
        target.Stats.Modify(HP: regen);

        // Return message and success
        msg = "Healed " + target.Info.Name + " for " + regen + " HP.";
        return true;
    }
}

