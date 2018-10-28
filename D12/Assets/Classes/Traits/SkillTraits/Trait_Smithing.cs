/// Trait_Smithing.cs
/// D12 Team

namespace Assets.Classes.Traits
{
    /// <summary>
    /// 
    /// </summary>
    public class Smithing1 : SkillTrait
    {
        public Smithing1(TraitStatus status) : base("Smithing 1", "+1 to Work rolls involving smith tools", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Smithing2 : SkillTrait
    {
        public Smithing2(TraitStatus status) : base("Smithing 2", "+2 to Work rolls involving smith tools", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Smithing3 : SkillTrait
    {
        public Smithing3(TraitStatus status) : base("Smithing 3", "+3 to Work rolls involving smith tools", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Smithing4 : SkillTrait
    {
        public Smithing4(TraitStatus status) : base("Smithing 4", "+4 to Work rolls involving smith tools", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Smithing5 : SkillTrait
    {
        public Smithing5(TraitStatus status) : base("Smithing 5", "+5 to Work rolls involving smith tools", 1, status) { }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Weaponsmith : SkillTrait
    {
        public Weaponsmith(TraitStatus status) : base("Weaponsmith", "+2 free points to weapon blanks, does not count towards Apathy", 1, status) { IsCrossroad = true; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Armorsmith : SkillTrait
    {
        public Armorsmith(TraitStatus status) : base("Armorsmith", "+1 Defence to armors you make, counts towards Apathy", 1, status) { IsCrossroad = true; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Artificer : SkillTrait
    {
        public Artificer(TraitStatus status) : base("Artificer", "arts you make have -1 Apathy", 1, status) { IsCrossroad = true; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Gilder : SkillTrait
    {
        public Gilder(TraitStatus status) : base("Gilder", "ignore the gilded tags negative effects", 1, status) { IsCrossroad = true; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Engraver : SkillTrait
    {
        public Engraver(TraitStatus status) : base("Engraver", "ignore ingraving's negative effects", 1, status) { IsCrossroad = true; }
    }
}
