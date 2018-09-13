/// Trait_Firebolt.cs
/// D12 Team
/// Firebolt spell traits

using System.Collections.Generic;

/// <summary>
/// Spell Trait: Firebolt 1
/// </summary>
public class Firebolt1 : SpellTrait
{
    public Firebolt1(bool active) : base("Firebolt 1", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, active) { }

    public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
    {
        // Is there a target to hit? Range checking will be done by a higher up class to account for range buffs
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
    public Firebolt2(bool active) : base("Firebolt 2", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, active) { }
}

/// <summary>
/// Spell Trait: Firebolt 3
/// </summary>
public class Firebolt3 : SpellTrait
{
    public Firebolt3(bool active) : base("Firebolt 3", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, active) { }
}

/// <summary>
/// Spell Trait: Firebolt 4
/// </summary>
public class Firebolt4 : SpellTrait
{
    public Firebolt4(bool active) : base("Firebolt 4", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, active) { }
}


/// <summary>
/// Spell Trait: Firebolt 4
/// </summary>
public class Firebolt5 : SpellTrait
{
    public Firebolt5(bool active) : base("Firebolt 5", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, active) { }
}

