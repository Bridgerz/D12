/// TraitSystem.cs
/// D12 Team

using System;
using System.Collections.Generic;

namespace Assets.Classes.Traits
{
    /// <summary>
    /// System to manage all three trait trees
    /// </summary>
    public class TraitSystem
    {
        public SkillDisciplineTree SkillTree;

        public CombatDisciplineTree CombatTree;

        public int TotalSkillExp;

        public int TotalCombatExp;

        public TraitSystem()
        {
            SkillTree = new SkillDisciplineTree();
            CombatTree = new CombatDisciplineTree();
        }
    }
}
