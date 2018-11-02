/// BaseCharacter.cs
/// D12 Team

using System;
using Assets.Classes.Traits;

namespace Assets.Classes.Character
{
    /// <summary>
    /// Represents a character and encapsulates all their information
    /// </summary>
    public class BaseCharacter
    {
        /// <summary>
        /// Information and flavor container
        /// </summary>
        public Information Info;

        /// <summary>
        /// Currency manager
        /// </summary>
        public Wallet Wallet;

        /// <summary>
        /// Stats manager
        /// </summary>
        public Stats Stats;

        /// <summary>
        /// Unique player identifier
        /// </summary>
        public Guid Guid { get; private set; }

        /// <summary>
        /// Constructor: Initializes all components to their default state (new character)
        /// </summary>
        public BaseCharacter()
        {
            Info = new Information();
            Wallet = new Wallet();
            Stats = new Stats();
            Guid = new Guid();
        }
    }
}