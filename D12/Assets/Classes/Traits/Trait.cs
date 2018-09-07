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
    /// Internal name of the trait
    /// </summary>
    protected string name;

    /// <summary>
    /// Internal EXP cost to puchase trait
    /// </summary>
    protected int cost;

    /// <summary>
    /// Internal flag if trait has been purchased and is now active
    /// </summary>
    protected bool active;

    /// <summary>
    /// Name of the trait
    /// </summary>
    public string Name
    {
        get
        {
            return name;
        }
    }

    /// <summary>
    /// EXP cost to purchase (unlock) trait
    /// </summary>
    public int Cost
    {
        get
        {
            return cost;
        }
    }

    /// <summary>
    /// Flag if trait has been unlocked
    /// </summary>
    public bool Active
    {
        get
        {
            return active;
        }
    }

    /// <summary>
    /// List of parent traits (traits directly above it in the tree)
    /// </summary>
    public List<Trait> parents;

    /// <summary>
    /// List of children traits (traits directly beneath it in the tree)
    /// </summary>
    public List<Trait> children;

    /// <summary>
    /// Constructor: Initializes a Trait with a name, cost and active flag
    /// </summary>
    /// <param name="name">Name of trait</param>
    /// <param name="cost">EXP cost to purchase (unlock) trait</param>
    /// <param name="active">Flag indicating trait's lock/unlock status</param>
    public Trait(string name, int cost, bool active)
    {
        children = new List<Trait>();
        parents = new List<Trait>();
        this.active = active;
        this.cost = cost;
        this.name = name;
    }
}

