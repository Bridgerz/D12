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
    /// Internal maximum volume of items the inventory can hold. Modified by storage items
    /// </summary>
    private double maxVolume;

    /// <summary>
    /// Maximum volume of items the inventory can hold. Modified by storage items
    /// </summary>
    public double MaxVolume
    {
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
    /// Internal weight of all items currently in the inventory
    /// </summary>
    private double currentWeight;

    /// <summary>
    /// Weight of all items currently in the inventory
    /// </summary>
    public double CurrentWeight
    {
        get
        {
            return currentWeight;
        }
        private set { }
    }

    /// <summary>
    /// Internal total volume of all items in the inventory
    /// </summary>
    private double currentVolume;

    /// <summary>
    /// Total volume of all items in the inventory
    /// </summary>
    public double CurrentVolume
    {
        get
        {
            return currentVolume;
        }
        private set { }
    }

    /// <summary>
    /// Internal list of items in the inventory
    /// </summary>
    private List<BaseItem> items;

    /// <summary>
    /// Public list of items in the inventory
    /// </summary>
    public List<BaseItem> Items
    {
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
        currentWeight = 0;
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
    bool Add(BaseItem item)
    {
        if (currentVolume + item.Volume > maxVolume) return false;
        items.Add(item);
        currentVolume += item.Volume;
        currentWeight += item.Weight;
        return true;
    }

    /// <summary>
    /// Removes an item from the inventory based on GUID
    /// </summary>
    /// <param name="targetId">Target item's guid</param>
    /// <returns>False if item was not in inventory</returns>
    bool Remove(Guid targetId)
    {
        int index = items.FindIndex(x => x.UniqueId == targetId);
        if (index == -1) return false;
        var item = items[index];
        items.RemoveAt(index);
        currentVolume -= item.Volume;
        currentWeight -= item.Weight;
        return true;
    }

    /// <summary>
    /// Removes all items in the inventory with target name
    /// </summary>
    /// <param name="targetName"></param>
    /// <returns></returns>
    void RemoveAll(string targetName)
    {
        var removedItems = items.FindAll(x => x.Name == targetName);
        if(removedItems.Count > 0)
        {
            items.RemoveAll(x => x.Name == targetName);
            foreach(BaseItem i in removedItems)
            {
                currentVolume -= i.Volume;
                currentWeight -= i.Weight;
            }
        }
    }
}