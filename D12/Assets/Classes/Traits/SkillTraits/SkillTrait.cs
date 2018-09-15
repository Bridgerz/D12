/// SkillTrait.cs
/// D12 Team

using System;
using System.Collections.Generic;

/// <summary>
/// Traits that buff rolls
/// </summary>
class SkillTrait : Trait
{
    /// <summary>
    /// Constructor: initializes all data to parameters
    /// </summary>
    /// <param name="name">Name of trait</param>
    /// <param name="buff">The description of the buff</param>
    /// <param name="cost">EXP cost to purchase (unlock) trait</param>
    /// <param name="active">Flag indicating trait's lock/unlock status</param>
    public SkillTrait(string name, string buff, int cost, bool active) : base(name, buff, cost, active) { }

    /// <summary>
    /// Wrapper for trait description
    /// </summary>
    public string Skill { get { return Desc; } }
}
