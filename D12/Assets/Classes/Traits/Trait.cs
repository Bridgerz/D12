/// Trait.cs
/// D12 Team

using System;
using System.Collections.Generic;

/// <summary>
/// Parent class for all traits
/// </summary>
public class Trait
{
    /// <summary>
    /// Name of the trait
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Description of trait and its effects
    /// </summary>
    public string Desc { get; protected set; }

    /// <summary>
    /// EXP cost to purchase (unlock) trait
    /// </summary>
    public int Cost { get; protected set; }

    /// <summary>
    /// Flag if trait has been unlocked
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// List of parent traits (traits directly above it in the tree)
    /// </summary>
    public List<Trait> parents;

    /// <summary>
    /// List of children traits (traits directly beneath it in the tree)
    /// </summary>
    public List<Trait> children;

    /// <summary>
    /// Internal rng for calculations
    /// </summary>
    protected readonly Random rng;

    /// <summary>
    /// Constructor: Initializes a Trait with a name, desc, cost and active flag
    /// </summary>
    /// <param name="name">Name of trait</param>
    /// <param name="desc">Description of trait and its effects</param>
    /// <param name="cost">EXP cost to purchase (unlock) trait</param>
    /// <param name="active">Flag indicating trait's lock/unlock status</param>
    public Trait(string name, string desc, int cost, bool active)
    {
        children = new List<Trait>();
        parents = new List<Trait>();
        Active = active;
        Cost = cost;
        Desc = desc;
        Name = name;
        rng = new Random(new Guid().GetHashCode());
    }
}

