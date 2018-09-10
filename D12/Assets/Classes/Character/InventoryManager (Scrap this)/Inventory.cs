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
    /// Maximum volume of items the inventory can hold. Modified by storage items
    /// </summary>
    public double MaxVolume {
        get { return MaxVolume; }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Value must be greater than or equal to 0.");
            MaxVolume = value;
        }
    }


    /// <summary>
    /// Weight of all items currently in the inventory, rounded to 2 decimals
    /// </summary>
    public double CurrentWeight {
        get { return Math.Round(CurrentWeight, 2); }
        private set { CurrentWeight = value; }
    }

    /// <summary>
    /// Total volume of all items in the inventory
    /// </summary>
    public double CurrentVolume { get; private set; }

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
    /// Constructor: Initializes a default empty inventory
    /// </summary>
    public Inventory()
    {
        items = new List<BaseItem>();
        CurrentWeight = 0;
        CurrentVolume = 0;
        MaxVolume = Constants.DEFAULT_MAX_VOLUME;
    }

    /// <summary>
    /// Constructor: Initializes the inventory to a list of existing items
    /// </summary>
    /// <param name="savedItems">List of items to add to the inventory</param>
    public Inventory(List<BaseItem> savedItems)
    {
        //TODO (make sure to calculate currentWeight)
    }


    /// <summary>
    /// Add an item to the inventory if it fits
    /// </summary>
    /// <param name="item">Item to be added to inventory</param>
    /// <returns>If item fits in the inventory</returns>
    public bool Add(BaseItem item)
    {
        if (CurrentVolume + item.Volume >MaxVolume) return false;
        items.Add(item);
        CurrentVolume += item.Volume;
        CurrentWeight += item.Weight;
        return true;
    }

    /// <summary>
    /// Removes an item from the inventory based on GUID
    /// </summary>
    /// <param name="targetId">Target item's guid</param>
    /// <returns>False if item was not in inventory</returns>
    public bool Remove(Guid targetId)
    {
        int index = items.FindIndex(x => x.UniqueId == targetId);
        if (index == -1) return false;
        var item = items[index];
        items.RemoveAt(index);
        CurrentVolume -= item.Volume;
        CurrentWeight -= item.Weight;
        return true;
    }
}