/// ActionTrait.cs
/// D12 Team

using System.Collections.Generic;

/// <summary>
/// Traits that are performed as actions
/// </summary>
public class ActionTrait : Trait
{
    /// <summary>
    /// Number of times the action can be done in a day
    /// </summary>
    public int DailyCount { get; protected set; }

    /// <summary>
    /// Count of times the action has been performed
    /// </summary>
    public int CurrentCount;

    /// <summary>
    /// Number of action targets
    /// </summary>
    public int NumTargets { get; protected set; }

    /// <summary>
    /// Constructor: Initializes all data members of an action trait
    /// </summary>
    /// <param name="name">Name of action trait</param>
    /// <param name="desc">Description of trait and its effects</param>
    /// <param name="cost">EXP cost to purchase (unlock) trait</param>
    /// <param name="dailyCount">Max number of times action should be performed in a day</param>
    /// <param name="numTargets">Number of targets for the action</param>
    /// <param name="active">Flag indicating if trait has been purchased (unlocked)</param>
    public ActionTrait(string name, string desc, int cost, int dailyCount, int numTargets, bool active) : base(name, desc, cost, active)
    {
        this.DailyCount = dailyCount;
        this.NumTargets = numTargets;
    }

    /// <summary>
    /// Simulates an action being performed on a number of targets
    /// </summary>
    /// <param name="msg">A flavor message returned after a performance</param>
    /// <param name="badTargets">Targets intended to be damaged by the action</param>
    /// <param name="goodTargets">Targets intended to benefit from the action</param>
    /// <param name="additionalObjects">Any additional objects the performance affects / interacts with</param>
    /// <returns>If action was succesfully performed</returns>
    public virtual bool Perform(out string msg, BaseCharacter[] badTargets = null, BaseCharacter[] goodTargets = null, object[] additionalObjects = null)
    {
        msg = "";
        return false;
    }
}

