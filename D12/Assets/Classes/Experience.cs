/// Experience.cs
/// D12 Team
using System;
/// <summary>
/// Experience management system for a character
/// </summary>
public class Experience
{
    /// <summary>
    /// Internal experience point count
    /// </summary>
    private int points;

    /// <summary>
    /// Current experience points character holds
    /// </summary>
    public int Points {
        get
        {
            return points;
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Value must be greater than or equal to 0.");
            points = value;
        }
    }

    /// <summary>
    /// Constructor: Initializes experience points to default value
    /// </summary>
    public Experience ()
    {
        points = Constants.STARTING_EXP_VAL;
    }

    /// <summary>
    /// Constructor: Initializes experience points from parameter
    /// </summary>
    /// <param name="initialValue">Starting experience points</param>
    public Experience (int initialValue)
    {
        points = initialValue;
    }

    /// <summary>
    /// Deducts from current point balance if possible
    /// </summary>
    /// <param name="val">Deduction value</param>
    /// <returns>If deduction was successful</returns>
    public bool Deduct (int val)
    {
        if (val < 0 || val > points) return false;
        points -= val;
        return true;
    }

    /// <summary>
    /// Adds to current point balance
    /// </summary>
    /// <param name="val">Addition value</param>
    public void Add (int val)
    {
        points += val;
    }
}