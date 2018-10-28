
using System.Collections.Generic;
/// Trait_Linguist.cs
/// D12 Team
namespace Assets.Classes.Traits
{
    /// <summary>
    /// 
    /// </summary>
    public class Linguist1 : SkillTrait
    {
        public Linguist1(TraitStatus status) : base("Linguist 1", "you may learn to speak another language", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Linguist2 : SkillTrait
    {
        public Linguist2(TraitStatus status) : base("Linguist 2", "you may learn to read and write a language you can speak", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Linguist3 : SkillTrait
    {
        public Linguist3(TraitStatus status) : base("Linguist 3", "you may learn to speak another language", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Linguist4 : SkillTrait
    {
        public Linguist4(TraitStatus status) : base("Linguist 4", "you may learn to read and write a language you can speak", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Linguist5 : SkillTrait
    {
        public Linguist5(TraitStatus status) : base("Linguist 5", " you may learn to speak, read and write another language", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Multilinguist : EffectTrait
    {
        public Multilinguist(TraitStatus status) : base("Multilinguist", "the EXP purchase cost of other Linguist traits is reduced", 1, status) { IsCrossroad = true; }

        public override bool DoSomething(out string msg, List<object> additionalObjects = null)
        {
            return base.DoSomething(out msg, additionalObjects);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Transcriber : SkillTrait
    {
        public Transcriber(TraitStatus status) : base("Transcriber", "you can read all languages", 1, status) { IsCrossroad = true; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Archlinguist : SkillTrait
    {
        public Archlinguist(TraitStatus status) : base("Archlinguist", "you can read runes and understand their purpose", 1, status) { IsCrossroad = true; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GlobalLocal : SkillTrait
    {
        public GlobalLocal(TraitStatus status) : base("Global Local", "get better prices on goods when speaking in the seller/buyer's native language", 1, status) { IsCrossroad = true; }
    }
}
