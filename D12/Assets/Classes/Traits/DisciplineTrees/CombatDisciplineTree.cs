/// CombatDisciplineTree.cs
/// D12 Team

using System;
using System.Collections.Generic;

/// <summary>
/// The tree of all combat discipline based traits
/// </summary>
public class CombatDisciplineTree
{
    public Trait root;

    public CombatDisciplineTree()
    {
        // ROOT
        root = new Trait("root","root of combat tree", 0, true);
    }
}

