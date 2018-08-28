/// BaseCharacter.cs
/// D12 Team
/// This class represents a single player and contains their:
/// - Attributes (TODO)
/// - Stats (TODO)
/// - Experience (WIP)
/// - Traits (TODO)
/// - Inventory (TODO)
/// - Currency Info (WIP)
/// - Flavor Info (WIP)
/// - Multiplayer information (TODO)

/// (CTRL + M), (CTRL + O) to collapse all comments and functions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a character and encapsulates all their information
/// </summary>
public class BaseCharacter
{
    /// <summary>
    /// Experience manager
    /// </summary>
    public Experience Experience;

    /// <summary>
    /// Information and flavor container
    /// </summary>
    public Information Info;

    /// <summary>
    /// Currency manager
    /// </summary>
    public Wallet Wallet;

    /// <summary>
    /// Inventory manager
    /// </summary>
    public Inventory Inventory;

    /// <summary>
    /// Constructor: Initializes all components to their default state (new character)
    /// </summary>
    public BaseCharacter()
    {
        Experience = new Experience();
        Info = new Information();
        Wallet = new Wallet();
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
