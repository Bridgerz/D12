/// SpellTrait.cs
/// D12 Team

using System.Collections.Generic;

/// <summary>
/// Traits that are cast as spells
/// </summary>
class SpellTrait : Trait
{
    /// <summary>
    /// Internal mana cost of spell
    /// </summary>
    private int manaCost;

    /// <summary>
    /// Mana cost of spell
    /// </summary>
    public int ManaCost
    {
        get
        {
            return manaCost;
        }
    }

    /// <summary>
    /// Internal range in meters of the spell
    /// </summary>
    private int range;

    /// <summary>
    /// Range in meters of the spell
    /// </summary>
    public int Range
    {
        get
        {
            return range;
        }
    }

    /// <summary>
    /// Internal number of spell targets
    /// </summary>
    private int targets;

    /// <summary>
    /// Number of spell targets
    /// </summary>
    public int Targets
    {
        get
        {
            return targets;
        }
    }


    public SpellTrait(string name, int cost, int manaCost, int range, int targets, bool active) : base(name, cost, active)
    {
        this.manaCost = manaCost;
        this.range = range;
        this.targets = targets;
    }

}

