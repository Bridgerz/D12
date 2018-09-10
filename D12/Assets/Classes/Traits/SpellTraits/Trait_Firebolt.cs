﻿/// Trait_Firebolt.cs
/// D12 Team
/// Firebolt spell traits

/// <summary>
/// Spell Trait: Firebolt 1
/// </summary>
public class Firebolt1 : SpellTrait
{
    public Firebolt1(bool active) : base("Firebolt 1", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, active) { }

    public override bool Cast(out string msg, BaseCharacter[] badTargets = null, BaseCharacter[] goodTargets = null, object[] additionalObjects = null)
    {
        if (badTargets.Length != 1)
        {
            msg = "No targets availible";
            return false;
        }
        var target = badTargets[0];
        var roll = rng.Next(1, 13);
        var dmg = (roll > 8) ? -2 : -1;
        target.Stats.Modify(HP: dmg);
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

    public override bool Cast(out string msg, BaseCharacter[] badTargets = null, BaseCharacter[] goodTargets = null, object[] additionalObjects = null)
    {
        if (badTargets.Length != 1)
        {
            msg = "No targets availible";
            return false;
        }
        var target = badTargets[0];
        var roll = rng.Next(1, 13);
        var dmg = (roll > 6) ? -2 : -1;
        target.Stats.Modify(HP: dmg);
        msg = "Hit " + target.Info.Name + " for " + dmg + " damage.";
        return true;
    }
}

/// <summary>
/// Spell Trait: Firebolt 3
/// </summary>
public class Firebolt3 : SpellTrait
{
    public Firebolt3(bool active) : base("Firebolt 3", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, active) { }

    public override bool Cast(out string msg, BaseCharacter[] badTargets = null, BaseCharacter[] goodTargets = null, object[] additionalObjects = null)
    {
        if (badTargets.Length != 1)
        {
            msg = "No targets availible";
            return false;
        }
        var target = badTargets[0];
        var roll = rng.Next(1, 13);
        var dmg = (roll > 4) ? -2 : -1;
        target.Stats.Modify(HP: dmg);
        msg = "Hit " + target.Info.Name + " for " + dmg + " damage.";
        return true;
    }
}

/// <summary>
/// Spell Trait: Firebolt 4
/// </summary>
public class Firebolt4 : SpellTrait
{
    public Firebolt4(bool active) : base("Firebolt 4", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, active) { }

    public override bool Cast(out string msg, BaseCharacter[] badTargets = null, BaseCharacter[] goodTargets = null, object[] additionalObjects = null)
    {
        if (badTargets.Length != 1)
        {
            msg = "No targets availible";
            return false;
        }
        var target = badTargets[0];
        var roll = rng.Next(1, 13);
        var dmg = (roll > 2) ? -2 : -1;
        target.Stats.Modify(HP: dmg);
        msg = "Hit " + target.Info.Name + " for " + dmg + " damage.";
        return true;
    }
}


/// <summary>
/// Spell Trait: Firebolt 4
/// </summary>
public class Firebolt5 : SpellTrait
{
    public Firebolt5(bool active) : base("Firebolt 5", "sling hissing fire at a target, dealing a hit of fire damage", 1, 1, 80, 1, active) { }

    public override bool Cast(out string msg, BaseCharacter[] badTargets = null, BaseCharacter[] goodTargets = null, object[] additionalObjects = null)
    {
        if (badTargets.Length != 1)
        {
            msg = "No targets availible";
            return false;
        }
        var target = badTargets[0];
        var dmg = 2;
        target.Stats.Modify(HP: dmg);
        msg = "Hit " + target.Info.Name + " for " + dmg + " damage.";
        return true;
    }
}

