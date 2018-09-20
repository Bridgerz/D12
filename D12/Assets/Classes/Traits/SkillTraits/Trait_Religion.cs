/// Trait_Religion.cs
/// D12 Team

namespace Assets.Classes.Traits
{
    public class Religion1 : SkillTrait
    {
        public Religion1(bool active) : base("Religion 1", "+1 to rolls involving recalling facts about Gods and their religions", 1, active) { }
    }

    public class Religion2 : SkillTrait
    {
        public Religion2(bool active) : base("Religion 2", "+2 to rolls involving recalling facts about Gods and their religions", 1, active) { }
    }

    public class Religion3 : SkillTrait
    {
        public Religion3(bool active) : base("Religion 3", "+3 to rolls involving recalling facts about Gods and their religions", 1, active) { }
    }

    public class Religion4 : SkillTrait
    {
        public Religion4(bool active) : base("Religion 4", "+4 to rolls involving recalling facts about Gods and their religions", 1, active) { }
    }

    public class Religion5 : SkillTrait
    {
        public Religion5(bool active) : base("Religion 5", "+5 to rolls involving recalling facts about Gods and their religions", 1, active) { }
    }

    public class Philotheos : SkillTrait
    {
        public Philotheos(bool active) : base("Philotheos", "you are able to tell if an object or person has a God's good or bad will", 1, active) { IsCrossroad = true; }
    }

    public class Blessed : SkillTrait
    {
        public Blessed(bool active) : base("Blessed", "you gain the favor of a God. Though it does not interact with you, others with Sight will see its good will", 1, active) { IsCrossroad = true; }
    }
}
