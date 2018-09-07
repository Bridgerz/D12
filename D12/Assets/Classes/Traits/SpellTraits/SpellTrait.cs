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
    private int numTargets;

    /// <summary>
    /// Number of spell targets
    /// </summary>
    public int NumTargets
    {
        get
        {
            return numTargets;
        }
    }

    /// <summary>
    /// Constructor: Initializes all data members of a spell trait
    /// </summary>
    /// <param name="name">Name of spell trait</param>
    /// <param name="cost">EXP cost of spell trait</param>
    /// <param name="manaCost">Mana cose of spell trait</param>
    /// <param name="range">Spell's range in meters</param>
    /// <param name="numTargets">Number of targets spell affects</param>
    /// <param name="active">Flag indicating if trait has been purchased (unlocked)</param>
    public SpellTrait(string name, int cost, int manaCost, int range, int numTargets, bool active) : base(name, cost, active)
    {
        this.manaCost = manaCost;
        this.range = range;
        this.numTargets = numTargets;
    }

    /// <summary>
    /// Simulates a spell cast on a number of targets
    /// </summary>
    /// <param name="badTargets">Targets intended to be damaged by the spell</param>
    /// <param name="goodTargets">Targets inteded to be buffed/healed by the spell</param>
    /// <returns>If spell was successfully cast</returns>
    public virtual bool Cast(BaseCharacter[] badTargets = null, BaseCharacter[] goodTargets = null)
    {
        return false;
    }
}

