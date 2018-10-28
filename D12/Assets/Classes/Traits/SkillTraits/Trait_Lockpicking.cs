/// Trait_Lockpicking.cs
/// D12 Team

namespace Assets.Classes.Traits
{
    /// <summary>
    /// Skill Trait: Lockpicking 1
    /// </summary>
    public class Lockpicking1 : SkillTrait
    {
        public Lockpicking1(TraitStatus status) : base("Lockpicking 1", "+1 to rolls involving picking or examining locks", 1, status) { }
    }

    /// <summary>
    /// Skill Trait: Lockpicking 2
    /// </summary>
    public class Lockpicking2 : SkillTrait
    {
        public Lockpicking2(TraitStatus status) : base("Lockpicking 2", "+2 to rolls involving picking or examining locks", 1, status) { }
    }

    /// <summary>
    /// Skill Trait: Lockpicking 3
    /// </summary>
    public class Lockpicking3 : SkillTrait
    {
        public Lockpicking3(TraitStatus status) : base("Lockpicking 3", "+3 to rolls involving picking or examining locks", 1, status) { }
    }

    /// <summary>
    /// Skill Trait: Lockpicking 4
    /// </summary>
    public class Lockpicking4 : SkillTrait
    {
        public Lockpicking4(TraitStatus status) : base("Lockpicking 4", "+4 to rolls involving picking or examining locks", 1, status) { }
    }

    /// <summary>
    /// Skill Trait: Lockpicking 5
    /// </summary>
    public class Lockpicking5 : SkillTrait
    {
        public Lockpicking5(TraitStatus status) : base("Lockpicking 5", "+5 to rolls involving picking or examining locks", 1, status) { }
    }

    /// <summary>
    /// Lockpicking Crossroads Trait: Safebreaker
    /// </summary>
    public class Safebreaker : SkillTrait
    {
        public Safebreaker(TraitStatus status) : base("Safebreaker", "you do not trigger traps when successfully lockpicking", 1, status) { IsCrossroad = true; }
    }

    /// <summary>
    /// Lockpicking Crossroads Trait: Vandal
    /// </summary>
    public class Vandal : SkillTrait
    {
        public Vandal(TraitStatus status) : base("Vandal", "you may be stealthed while picking locks and suppress all noise from picking", 1, status) { IsCrossroad = true; }
    }
}
