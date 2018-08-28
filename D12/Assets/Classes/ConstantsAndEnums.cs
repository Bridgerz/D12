/// ConstantsAndEnums.cs
/// D12 Team

/// <summary>
/// Global constants
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

    /* BaseItem.cs*/
    /// <summary>
    /// Default name for any item
    /// </summary>
    public const string BASEITEM_DEFAULT_NAME = "BASEITEM_DEFAULT_NAME";
    /// <summary>
    /// Default weight for any item
    /// </summary>
    public const double BASEITEM_DEFAULT_WEIGHT = 0;
    /// <summary>
    /// Default volume for any item
    /// </summary>
    public const double BASEITEM_DEFAULT_VOLUME = 0;
    

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