/// Wallet.cs
/// D12 Team

using System;

/// <summary>
/// Currency management system for a character.
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
    public int Bits {
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
    public int Bars {
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
    public Wallet()
    {
        bits = Constants.STARTING_BIT_VAL;
        bars = Constants.STARTING_BAR_VAL;
    }

    /// <summary>
    /// Constructor: Initializes bits and bars from parameters
    /// </summary>
    /// <param name="bits">Initial bit amount</param>
    /// <param name="bars">Initial bar amount</param>
    public Wallet(int bits, int bars)
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

    /// <summary>
    /// Deducts an amount from the character's wallet if able. Deducts from the bits before the bars
    /// </summary>
    /// <param name="amount">Deduction amount</param>
    /// <returns>If wallet had a balance greater than or equal to amount</returns>
    public bool Deduct(int amount)
    {
        var balance = GetBalance();
        if (amount > balance) return false;

        // Can transaction be covered by the bits
        if (amount <= bits)
        {
            bits -= balance;
        }
        else
        {
            // Deduct from bits first
            amount -= bits;
            // Deduct remaining amount from bars
            var barsNeeded = amount / 100;
            if (amount % 100 == 0)
            {
                bars -= barsNeeded;
            }
            else
            {
                bars -= barsNeeded + 1;
                bits = amount % barsNeeded;
            }
        }
        return true;
    }

    /// <summary>
    /// Add bits to the character's wallet
    /// </summary>
    /// <param name="amount">Amount of bits to be added</param>
    public void AddBits(int amount)
    {
        bits += amount;
    }

    /// <summary>
    /// Add bars to the character's wallet
    /// </summary>
    /// <param name="amount">Amount of bars to be added</param>
    public void AddBars(int amount)
    {
        bars += amount;
    }

    /// <summary>
    /// Add a combination of bits and bars to the character's wallet
    /// </summary>
    /// <param name="bitAmount">Amount of bits to be added</param>
    /// <param name="barAmount">Amount of bars to be added</param>
    public void AddAmount(int bitAmount, int barAmount)
    {
        AddBars(barAmount);
        AddBits(bitAmount);
    }
}