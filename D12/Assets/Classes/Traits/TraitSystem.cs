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

        public AccumenDisciplineTree AccumenTree;

        public int TotalSkillExp;

        public int TotalCombatExp;

        public int TotalAccumenExp;

        public TraitSystem()
        {
            TotalSkillExp = 0;
            TotalCombatExp = 0;
            TotalAccumenExp = 0;
            SkillTree = new SkillDisciplineTree();
            CombatTree = new CombatDisciplineTree();
            AccumenTree = new AccumenDisciplineTree();
        }
    }
}
