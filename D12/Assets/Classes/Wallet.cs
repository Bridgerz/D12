/// Wallet.cs
/// D12 Team
using System;
/// <summary>
/// Currency management system for a character
/// </summary>
public class Wallet
{

    /// <summary>
    /// Internal bits count
    /// </summary>
    private int bits;

    /// <summary>
    /// Internal bars count
    /// </summary>
    private int bars;

    /// <summary>
    /// Lower currency denomination (100 Bits = 1 Bar). Represents total bits in character's wallet
    /// </summary>
    public int Bits 
    {
        get
        {
            return bits;
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Value must be greater than or equal to 0.");
            bits = value;
        }
    }

    /// <summary>
    /// Upper currency denomination (1 Bar = 100 Bits). Represents total bars in character's wallet
    /// </summary>
    public int Bars 
    {
        get
        {
            return bars;
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Value must be greater than or equal to 0.");
            bars = value;
        }
    }

    /// <summary>
    /// Constructor: Initializes bits and bars to defaults for a new character
    /// </summary>
    public Wallet ()
    {
        bits = Constants.STARTING_BIT_VAL;
        bars = Constants.STARTING_BAR_VAL;
    }

    /// <summary>
    /// Constructor: Initializes bits and bars from parameters
    /// </summary>
    /// <param name="bits">Initial bit amount</param>
    /// <param name="bars">Initial bar amount</param>
    public Wallet (int bits, int bars)
    {
        this.bits = bits;
        this.bars = bars;
    }

    /// <summary>
    /// Get the current wallet balance in bits
    /// </summary>
    /// <returns>The wallets balance in bits</returns>
    public int GetBalance()
    {
        return bars * 100 + bits;
    }

    bool Deduct(int bits)
    {
        if (bits > GetBalance()) return false;

    }


}