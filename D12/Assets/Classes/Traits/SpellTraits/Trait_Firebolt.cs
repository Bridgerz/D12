/// Trait_Firebolt.cs
/// D12 Team

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

        if (badTargets.Length != 0) return false;

        // damage the badTarget here (no concept of hp yet hmm something to do)
    }
}