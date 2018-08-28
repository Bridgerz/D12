﻿/// Information.cs
/// D12 Team

using System.Collections.Generic;

/// <summary>
/// Collection of information regarding a character's backstory, habits, and other flavor
/// </summary>
public class Information
{
    /// <summary>
    /// Character's backstory
    /// </summary>
    public string Backstory { get; set; }

    /// <summary>
    /// Character's race
    /// </summary>
    public Race Race { get; set; }

    /// <summary>
    /// List of character's habits
    /// </summary>
    public List<string> HabitList { get; set; }

    /// <summary>
    /// Constructor: All components are initialized to default values
    /// </summary>
    public Information()
    {
        HabitList = new List<string>();
        Race = 0;
        Backstory = "";
    }

    /// <summary>
    /// Constructor: Initializes components to existing information
    /// </summary>
    /// <param name="backstory">The character's backstory</param>
    /// <param name="race">The character's race</param>
    /// <param name="habitList">The character's list of habits</param>
    public Information(string backstory, Race race, List<string> habitList)
    {
        Backstory = backstory;
        Race = race;
        HabitList = habitList;
    }
}