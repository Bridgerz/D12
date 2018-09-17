/// EffectTrait.cs
/// D12 Team

using System.Collections.Generic;
using Assets.Classes.Character;

namespace Assets.Classes.Traits
{
    /// <summary>
    /// Traits that are mainly flavor / unique
    /// </summary>
    public class EffectTrait : Trait
    {
        /// <summary>
        /// Constructor: Initializes a Trait with a name, desc, cost and active flag
        /// </summary>
        /// <param name="name">Name of trait</param>
        /// <param name="desc">Description of trait and its effects</param>
        /// <param name="cost">EXP cost to purchase (unlock) trait</param>
        /// <param name="active">Flag indicating trait's lock/unlock status</param>
        public EffectTrait(string name, string desc, int cost, bool active) : base(name, desc, cost, active) { IsCrossroad = false; }

        /// <summary>
        /// Does something?
        /// </summary>
        /// <param name="msg">Flavor message returned when something has been attempted</param>
        /// <param name="additionalObjects">Any additional objects needed to do something</param>
        public virtual bool DoSomething(out string msg, List<object> additionalObjects = null)
        {
            msg = "";
            return false;
        }
    }
}
