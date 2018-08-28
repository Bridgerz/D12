/// BaseItem.cs
/// D12 Team

using System;

/// <summary>
/// Parent item class that all items (weapons, tools, etc) should inherit from
/// </summary>
public class BaseItem
{
    /// <summary>
    /// Internal weight of the item in kilograms
    /// </summary>
    protected double weight;

    /// <summary>
    /// Weight of the item in kilograms
    /// </summary>
    public double Weight {
        get
        {
            return weight;
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Value must be greater than or equal to 0.");
            weight = value;
        }
    }

    /// <summary>
    /// Internal name of the item
    /// </summary>
    protected string name;

    /// <summary>
    /// Name of the item
    /// </summary>
    public string Name {
        get
        {
            return name;
        }
        set
        {
            // Any illegal name checking can be done here (i.e. swear filter)
            name = value;
        }
    }

    /// <summary>
    /// Internal volume of the item (how much space it takes up in an inventory)
    /// </summary>
    protected double volume;

    /// <summary>
    /// Volume of the item (how much space it takes up in an inventory)
    /// </summary>
    public double Volume {
        get
        {
            return volume;
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Value must be greater than or equal to 0.");
            weight = value;
        }
    }

    /// <summary>
    /// Constructor: Initializes name and weight to default values
    /// </summary>
    protected BaseItem()
    {
        weight = Constants.BASEITEM_DEFAULT_WEIGHT;
        name = Constants.BASEITEM_DEFAULT_NAME;
        volume = Constants.BASEITEM_DEFAULT_VOLUME;
    }

    /// <summary>
    /// Constructor: Initializes name and weight to parameters
    /// </summary>
    /// <param name="name">Name of the item</param>
    /// <param name="weight">Weight of the item in kilograms</param>
    /// <param name="volume">Volume of the item</param>
    protected BaseItem(string name, double weight, double volume)
    {
        Weight = weight;
        Name = name;
        Volume = volume;
    }
}
