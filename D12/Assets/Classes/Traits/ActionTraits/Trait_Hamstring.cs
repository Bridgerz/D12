﻿/// Trait_Hamstring.cs
/// D12 Team

using System.Collections.Generic;
using Assets.Classes.Character;

namespace Assets.Classes.Traits
{
    /// <summary>
    /// Action Trait: Hamstring 1
    /// </summary>
    public class Hamstring1 : ActionTrait
    {
        public Hamstring1(TraitStatus status) : base("Hamstring 1", "make a basic attack which slows the target by 30% if it hits", 1, 3, 1, status) { }

        public override bool Perform(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            return base.Perform(out msg, roll, badTargets, goodTargets, additionalObjects);
        }
    }

    /// <summary>
    /// Action Trait: Hamstring 2
    /// </summary>
    public class Hamstring2 : ActionTrait
    {
        public Hamstring2(TraitStatus status) : base("Hamstring 2", "make a basic attack which slows the target by 40% if it hits", 1, 3, 1, status) { }

        public override bool Perform(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            return base.Perform(out msg, roll, badTargets, goodTargets, additionalObjects);
        }
    }

    /// <summary>
    /// Action Trait: Hamstring 3
    /// </summary>
    public class Hamstring3 : ActionTrait
    {
        public Hamstring3(TraitStatus status) : base("Hamstring 3", "make a basic attack which slows the target by 40% if it hits", 1, 4, 1, status) { }

        public override bool Perform(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            return base.Perform(out msg, roll, badTargets, goodTargets, additionalObjects);
        }
    }

    /// <summary>
    /// Action Trait: Hamstring 4
    /// </summary>
    public class Hamstring4 : ActionTrait
    {
        public Hamstring4(TraitStatus status) : base("Hamstring 4", "make a basic attack which slows the target by 50% if it hits", 1, 4, 1, status) { }

        public override bool Perform(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            return base.Perform(out msg, roll, badTargets, goodTargets, additionalObjects);
        }
    }

    /// <summary>
    /// Action Trait: Hamstring 5
    /// </summary>
    public class Hamstring5 : ActionTrait
    {
        public Hamstring5(TraitStatus status) : base("Hamstring 5", "make a basic attack which slows the target by 50% if it hits", 1, 5, 1, status) { }

        public override bool Perform(out string msg, int roll, List<BaseCharacter> badTargets = null, List<BaseCharacter> goodTargets = null, List<object> additionalObjects = null)
        {
            return base.Perform(out msg, roll, badTargets, goodTargets, additionalObjects);
        }
    }

    /// <summary>
    /// Hamstring Crossroad Trait: Deep Wound
    /// </summary>
    public class DeepWound : SkillTrait
    {
        public DeepWound(TraitStatus status) : base("Deep Wound", "1-5's on damage rolls for Hamstring are 6's", 1, status) { IsCrossroad = true; }
    }


    /// <summary>
    /// Hamstring Crossroad Trait: Achilles
    /// </summary>
    public class Achilles : EffectTrait
    {
        public Achilles(TraitStatus status) : base("Achilles","slow is increased by 20%", 1, status) { IsCrossroad = true; }

        public override bool DoSomething(out string msg, List<object> additionalObjects = null)
        {
            return base.DoSomething(out msg, additionalObjects);
        }
    }

    /// <summary>
    /// Hamstring Crossroad Trait: Backswing
    /// </summary>
    public class Backswing : EffectTrait
    {
        public Backswing(TraitStatus status) : base("Backswing", "if Hamstring misses once, it is used again for free.", 1, status) { IsCrossroad = true; }

        public override bool DoSomething(out string msg, List<object> additionalObjects = null)
        {
            return base.DoSomething(out msg, additionalObjects);
        }
    }

    /// <summary>
    /// Hamstring Crossroad Trait: Leave It Bleeding
    /// </summary>
    public class LeaveItBleeding : EffectTrait
    {
        public LeaveItBleeding(TraitStatus status) : base("LeaveItBleeding", "targets slowed by Hamstring take 1 damage when they take the move.", 1, status) { IsCrossroad = true; }

        public override bool DoSomething(out string msg, List<object> additionalObjects = null)
        {
            return base.DoSomething(out msg, additionalObjects);
        }
    }
}
