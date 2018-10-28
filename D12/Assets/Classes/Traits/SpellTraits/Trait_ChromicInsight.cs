
using System.Collections.Generic;
using Assets.Classes.Character;
/// Trait_ChromicInsight.cs
/// D12 Team
namespace Assets.Classes.Traits
{
    public class ChromicInsight1 : SpellTrait
    {
        public ChromicInsight1(TraitStatus status) : base("Chromic Insight 1", "cause an object no bigger than a 5' cube to change color", 1, 1, 60, 1, status) { }

        public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            return base.Cast(out msg, roll, badTargets, goodTargets, additionalObjects);
        }
    }

    public class ChromicInsight2 : SpellTrait
    {
        public ChromicInsight2(TraitStatus status) : base("Chromic Insight 2", "cause an object no bigger than a 15' cube to change color", 1, 1, 60, 1, status) { }

        public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            return base.Cast(out msg, roll, badTargets, goodTargets, additionalObjects);
        }
    }

    public class ChromicInsight3 : SpellTrait
    {
        public ChromicInsight3(TraitStatus status) : base("Chromic Insight 3", "cause an object no bigger than a 25' cube to change color", 1, 1, 60, 1, status) { }

        public override bool Cast(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            return base.Cast(out msg, roll, badTargets, goodTargets, additionalObjects);
        }
    }
}
