/// BaseCharacter.cs
/// D12 Team
/// This class represents a single player and contains their:
/// - Attributes (TODO)
/// - Stats (TODO)
/// - Experience (WIP)
/// - Traits (TODO)
/// - Inventory (TODO)
/// - Multiplayer information (TODO)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter
{
    /// <summary>
    /// Constructor: Initializes all components to their default state
    /// </summary>
    public BaseCharacter ()
    {
        experience = new Experience();
    }

    /// <summary>
    /// Constructor: Initializes components from a save file
    /// </summary>
    /// <param name="savefile">Path to save file</param>
    public BaseCharacter (string savefile)
    {
        // TODO
    }

    /// <summary>
    /// Internal experience manager
    /// </summary>
    private Experience experience;


}
