/// Trait_Deception.cs
/// D12 Team

namespace Assets.Classes.Traits
{
    /// <summary>
    /// 
    /// </summary>
    public class Deception1: SkillTrait
    {
        public Deception1(TraitStatus status) : base("Deception 1", "+1 to Social Sparring when attempting to decieve the opponent", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Deception2 : SkillTrait
    {
        public Deception2(TraitStatus status) : base("Deception 2", "+2 to Social Sparring when attempting to decieve the opponent", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Deception3 : SkillTrait
    {
        public Deception3(TraitStatus status) : base("Deception 3", "+3 to Social Sparring when attempting to decieve the opponent", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Deception4 : SkillTrait
    {
        public Deception4(TraitStatus status) : base("Deception 4", "+4 to Social Sparring when attempting to decieve the opponent", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Deception5 : SkillTrait
    {
        public Deception5(TraitStatus status) : base("Deception 5", "+5 to Social Sparring when attempting to decieve the opponent", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Pawner : SkillTrait
    {
        public Pawner(TraitStatus status) : base("Pawner", "you get advantage on Social Sparring rolls involving the buying and selling of goods", 1, status) { IsCrossroad = true; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SmoothTalker : SkillTrait
    {
        public SmoothTalker(TraitStatus status) : base("Smooth Talker", "you get advantage on Social Sparring rolls when getting out of trouble", 1, status) { IsCrossroad = true; }
    }
}
