/// Stats.cs
/// D12 Team

using System;

/// <summary>
/// Stats manager for a character
/// </summary>
public class Stats
{
    public int HP { get; private set; }

    public int MP { get; private set; }

    public int MS { get; private set; }

    public int DEF { get; private set; }

    public int DIS { get; private set; }

    public int SP { get; private set; }

    public int AWR { get; private set; }

    public int EXP { get; private set; }

    public int ATM { get; private set; }

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

    public Stats()
    {
    }
}
