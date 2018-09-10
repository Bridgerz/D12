/// Trait_Firebolt.cs
/// D12 Team
/// Firebolt spell traits

using System;

/// <summary>
/// Spell Trait: Firebolt 1
/// </summary>
public class Firebolt1 : SpellTrait
{
    public Firebolt1(bool active) : base("Firebolt 1", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, active)
    {

    }

    public override bool Cast(out string msg, BaseCharacter[] badTargets = null, BaseCharacter[] goodTargets = null, object[] additionalObjects = null)
    {
        msg = desc;

        if (badTargets.Length != 1) return false;

        // damage the badTarget here (no concept of hp yet hmm something to do)

        return true;
    }
}

/// <summary>
/// Spell Trait: Firebolt 2
/// </summary>
public class Firebolt2 : SpellTrait
{
    public Firebolt2(bool active) : base("Firebolt 2", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, active)
    {

    }

    public override bool Cast(out string msg, BaseCharacter[] badTargets = null, BaseCharacter[] goodTargets = null, object[] additionalObjects = null)
    {
        msg = desc;

        if (badTargets.Length != 1) return false;

        // damage the badTarget here (no concept of hp yet hmm something to do)

        return true;
    }
}
