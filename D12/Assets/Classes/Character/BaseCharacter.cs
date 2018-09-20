/// BaseCharacter.cs
/// D12 Team
/// This class represents a single player and contains their:
/// - Attributes (TODO)
/// - Stats (TODO)
/// - Traits (TODO)
/// - Inventory (TODO)
/// - Currency Info (WIP)
/// - Flavor Info (WIP)
/// - Multiplayer information (TODO)

/// (CTRL + M), (CTRL + O) to collapse all comments and functions

using System;

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

        /// <summary>
        /// Constructor: Initializes components from a save file (returning character)
        /// </summary>
        /// <param name="savefile">Path to save file</param>
        public BaseCharacter(string savefile)
        {
            // TODO
        }
    }
}