/// SpellTrait.cs
/// D12 Team

using System.Collections.Generic;
using Assets.Classes.Character;

namespace Assets.Classes.Traits
{
    /// <summary>
    /// Traits that are cast as spells
    /// </summary>
    public class SpellTrait : Trait
    {
        /// <summary>
        /// Mana cost of spell
        /// </summary>
        public int ManaCost { get; protected set; }

        /// <summary>
        /// Range in meters of the spell
        /// </summary>
        public int Range { get; protected set; }

        /// <summary>
        /// Number of spell targets
        /// </summary>
        public int NumTargets { get; protected set; }

        /// <summary>
        /// Constructor: Initializes all data members of a spell trait
        /// </summary>
        /// <param name="name">Name of spell trait</param>
        /// <param name="desc">Description of the spell and its effects</param>
        /// <param name="cost">EXP cost of spell trait</param>
        /// <param name="manaCost">Mana cose of spell trait</param>
        /// <param name="range">Spell's range in meters</param>
        /// <param name="numTargets">Number of targets spell affects</param>
        /// <param name="active">Flag indicating if trait has been purchased (unlocked)</param>
        public SpellTrait(string name, string desc, int cost, int manaCost, int range, int numTargets, TraitStatus status) : base(name, desc, cost, status)
        {
            ManaCost = manaCost;
            Range = range;
            NumTargets = numTargets;
        }

        /// <summary>
        /// Simulates a spell cast on a number of targets
        /// </summary>
        /// <param name="msg">A flavor message returned after a cast</param>
        /// <param name="roll">The d12 roll passed into the function</param>
        /// <param name="badTargets">Targets intended to be damaged by the spell</param>
        /// <param name="goodTargets">Targets inteded to be buffed/healed by the spell</param>
        /// <param name="additionalObjects">Any additional objects that the spellcast affects / interacts with</param>
        /// <returns>If spell was successfully cast</returns>
        public virtual bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            msg = "";
            return false;
        }
    }
}