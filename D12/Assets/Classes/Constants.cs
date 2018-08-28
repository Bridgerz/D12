/// Constants.cs
/// D12 Team
/// <summary>
/// Global constants for BaseCharacter class and its members
/// </summary>
public static class Constants
{
    /* Experience.cs */
    /// <summary>
    /// New character starting experience points
    /// </summary>
    public const int STARTING_EXP_VAL = 24;

    /* Wallet.cs */
    /// <summary>
    /// New character starting bit amount
    /// </summary>
    public const int STARTING_BIT_VAL = 0;
    /// <summary>
    /// New character starting bar amount
    /// </summary>
    public const int STARTING_BAR_VAL = 10;

}

/// <summary>
/// Playable races for a character
/// </summary>
public enum Race
{
    Unassigned,
    Human,
    Orc,
    Goblin,
    Dwarf,
    Halfling
}