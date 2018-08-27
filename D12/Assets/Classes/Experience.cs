/// Experience.cs
/// D12 team
/// <summary>
/// Experience management system for a character
/// </summary>
public class Experience
{
    /// <summary>
    /// Default starting point value
    /// </summary>
    public readonly int STARTING_EXP_VAL = 24;

    /// <summary>
    /// Constructor: Initializes experience points to default value
    /// </summary>
    public Experience()
    {
        Points = STARTING_EXP_VAL;
    }

    /// <summary>
    /// Constructor: Initializes experience points to parameter
    /// </summary>
    /// <param name="initialValue">Starting experience points</param>
    public Experience (int initialValue)
    {
        Points = initialValue;
    }

    /// <summary>
    /// Deducts from current point balance if possible
    /// </summary>
    /// <param name="val">Deduction value</param>
    /// <returns>If deduction was successful</returns>
    public bool Deduct(int val)
    {
        if (val < 0 || val > Points) return false;
        Points -= val;
        return true;
    }

    /// <summary>
    /// Adds to current point balance
    /// </summary>
    /// <param name="val">Addition value</param>
    public void Add (int val)
    {
        Points += val;
    }

    /// <summary>
    /// Current experience points character holds
    /// </summary>
    public int Points { get; set; }
}