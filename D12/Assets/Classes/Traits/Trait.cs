﻿/// Trait.cs
/// D12 Team

using System;
using System.Collections.Generic;

namespace Assets.Classes.Traits
{
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
        /// Flag if trait has been unlocked and is active
        /// </summary>
        public TraitStatus Status { get; set; }

        /// <summary>
        /// Flag if trait is a crossroad trait
        /// </summary>
        public bool IsCrossroad { get; protected set; }

        /// <summary>
        /// List of parent traits (traits directly above it in the tree)
        /// </summary>
        public List<Trait> parents;

        /// <summary>
        /// List of children traits (traits directly beneath it in the tree)
        /// </summary>
        public List<Trait> children;

        /// <summary>
        /// Returns true if a trait is not a crossroad or is a crossroad
        /// where its purchasable condition is satisfied.
        /// </summary>
        /// <param name="system"></param>
        /// <param name="additionalObjs"></param>
        /// <returns></returns>
        public virtual bool IsCrossroadSatisfied(TraitSystem system, object[] additionalObjs)
        {
            return true;
        }

        /// <summary>
        /// Constructor: Initializes a Trait with a name, desc, cost and active flag
        /// </summary>
        /// <param name="name">Name of trait</param>
        /// <param name="desc">Description of trait and its effects</param>
        /// <param name="cost">EXP cost to purchase (unlock) trait</param>
        /// <param name="active">Flag indicating trait's lock/unlock status</param>
        public Trait(string name, string desc, int cost, TraitStatus status)
        {
            children = new List<Trait>();
            parents = new List<Trait>();
            Status = status;
            Cost = cost;
            Desc = desc;
            Name = name;
            IsCrossroad = false;
        }
    }

    public enum TraitStatus
    {
        locked,
        purchasble,
        purchased,
        active,
        inactive
    }
}