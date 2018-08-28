/// Inventory.cs
/// D12 Team

using System;
using System.Collections.Generic;

/// <summary>
/// Inventory manangement system for a character
/// </summary>
public class Inventory
{
    /// <summary>
    /// Internal maximum volume of items an inventory can hold. Modified by storage items
    /// </summary>
    private double maxVolume;

    /// <summary>
    /// Maximum volume of items an inventory can hold. Modified by storage items
    /// </summary>
    public double MaxVolume {
        get
        {
            return maxVolume;
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Value must be greater than or equal to 0.");
            maxVolume = value;
        }
    }

    /// <summary>
    /// Internal list of items in the inventory
    /// </summary>
    private List<BaseItem> items;

    /// <summary>
    /// Public list of items in the inventory
    /// </summary>
    public List<BaseItem> Items {
        get
        {
            return new List<BaseItem>(items);
        }
    }

    /// <summary>
    /// Constructor: 
    /// </summary>
    public Inventory()
    {
        items = new List<BaseItem>();
    }

}