/// BaseCharacter.cs
/// D12 Team
/// This class represents a single player and contains their:
/// - Attributes (TODO)
/// - Stats (TODO)
/// - Experience (WIP)
/// - Traits (TODO)
/// - Inventory (TODO)
/// - Multiplayer information (TODO)
/// 

/// (CTRL + M), (CTRL + O) to collapse all comments and functions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter
{
    /// <summary>
    /// Experience manager
    /// </summary>
    public Experience Experience;

    /// <summary>
    /// Information container
    /// </summary>
    public Information Info;

    /// <summary>
    /// Currency manager
    /// </summary>
    public Wallet Wallet;

    /// <summary>
    /// Constructor: Initializes all components to their default state (new character)
    /// </summary>
    public BaseCharacter ()
    {
        Experience = new Experience();
        Info = new Information();
    }

    /// <summary>
    /// Constructor: Initializes components from a save file (returning character)
    /// </summary>
    /// <param name="savefile">Path to save file</param>
    public BaseCharacter (string savefile)
    {
        // TODO
    }
}
