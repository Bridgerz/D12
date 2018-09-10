/// Stats.cs
/// D12 Team

using System;

/// <summary>
/// Stats manager for a character
/// </summary>
public class Stats
{
    /// <summary>
    /// Health value of a character
    /// </summary>
    public int HP { get; private set; }

    /// <summary>
    /// Mana value of a character
    /// </summary>
    public int MP { get; private set; }

    /// <summary>
    /// Movement speed of a character
    /// </summary>
    public int MS { get; private set; }

    /// <summary>
    /// Defense value of a character
    /// </summary>
    public int DEF { get; private set; }

    /// <summary>
    /// Discernment value of a character
    /// </summary>
    public int DIS { get; private set; }

    /// <summary>
    /// Spell potency value of a character
    /// </summary>
    public int SP { get; private set; }

    /// <summary>
    /// Awareness value of a character
    /// </summary>
    public int AWR { get; private set; }

    /// <summary>
    /// Experience points for a character
    /// </summary>
    public int EXP { get; private set; }

    /// <summary>
    /// Attunement value of a character
    /// </summary>
    public int ATM { get; private set; }

    /// <summary>
    /// Modifies any number of stats. Enter negative values to deduct a stat.
    /// </summary>
    /// <param name="HP">Health value of a character</param>
    /// <param name="MP">Mana value of a character</param>
    /// <param name="MS">Movement speed of a character</param>
    /// <param name="DEF">Defense value of a character</param>
    /// <param name="DIS">Discernment value of a character</param>
    /// <param name="SP">Spell potency value of a character</param>
    /// <param name="AWR">Awareness value of a character</param>
    /// <param name="EXP">Experience points for a character</param>
    /// <param name="ATM">Attunement value of a character</param>
    public void Modify(int HP = 0, int MP = 0, int MS = 0, int DEF = 0, int DIS = 0, int SP = 0, int AWR = 0, int EXP = 0, int ATM = 0)
    {
        this.HP += HP;
        this.MP += MP;
        this.MS += MS;
        this.DEF += DEF;
        this.DIS += DIS;
        this.SP += SP;
        this.AWR += AWR;
        this.EXP += EXP;
        this.ATM += ATM;
    } 

    /// <summary>
    /// Constructor: Initializes all stats to 0
    /// </summary>
    public Stats()
    {
        HP = 0;
        MP = 0;
        MS = 0;
        DEF = 0;
        DIS = 0;
        SP = 0;
        AWR = 0;
        EXP = 0;
        ATM = 0;
    }

    /// <summary>
    /// Constructor: Initializes all stats
    /// </summary>
    /// <param name="HP">Health value of a character</param>
    /// <param name="MP">Mana value of a character</param>
    /// <param name="MS">Movement speed of a character</param>
    /// <param name="DEF">Defense value of a character</param>
    /// <param name="DIS">Discernment value of a character</param>
    /// <param name="SP">Spell potency value of a character</param>
    /// <param name="AWR">Awareness value of a character</param>
    /// <param name="EXP">Experience points for a character</param>
    /// <param name="ATM">Attunement value of a character</param>
    public Stats(int HP, int MP, int MS, int DEF, int DIS, int SP, int AWR, int EXP, int ATM)
    {
        this.HP = HP;
        this.MP = MP;
        this.MS = MS;
        this.DEF = DEF;
        this.DIS = DIS;
        this.SP = SP;
        this.AWR = AWR;
        this.EXP = EXP;
        this.ATM = ATM;
    }
}
