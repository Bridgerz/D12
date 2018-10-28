/// SkillDisciplineTree.cs
/// D12 Team

using System;
using System.Collections.Generic;

namespace Assets.Classes.Traits
{
    /// <summary>
    /// Tree of all skill discipline based traits
    /// </summary>
    public class SkillDisciplineTree
    {
        public Trait root;

        public SkillDisciplineTree()
        {
            root = new Trait("root", "root of skill tree", 0, TraitStatus.active);

            // Lockpicking
            Lockpicking1 l1 = new Lockpicking1(TraitStatus.inactive);
            Lockpicking2 l2 = new Lockpicking2(TraitStatus.inactive);
            Lockpicking3 l3 = new Lockpicking3(TraitStatus.inactive);
            Lockpicking4 l4 = new Lockpicking4(TraitStatus.inactive);
            Lockpicking5 l5 = new Lockpicking5(TraitStatus.inactive);
            Safebreaker l5_1= new Safebreaker(TraitStatus.inactive);
            Vandal l5_2 = new Vandal(TraitStatus.inactive);
            Link(root, l1);
            Link(l1, l2);
            Link(l2, l3);
            Link(l3, l4);
            Link(l4, l5);
            Link(l5, l5_1);
            Link(l5, l5_2);

            // Deception
            Deception1 d1 = new Deception1(TraitStatus.inactive);
            Deception2 d2 = new Deception2(TraitStatus.inactive);
            Deception3 d3 = new Deception3(TraitStatus.inactive);
            Pawner d3_1 = new Pawner(TraitStatus.inactive);
            SmoothTalker d3_2 = new SmoothTalker(TraitStatus.inactive);
            Deception4 d4 = new Deception4(TraitStatus.inactive);
            Deception5 d5 = new Deception5(TraitStatus.inactive);
            Link(root, d1);
            Link(d1, d2);
            Link(d2, d3);
            Link(d3, d3_1);
            Link(d3, d3_2);
            Link(d3_1, d4);
            Link(d3_2, d4);
            Link(d4, d5);

            // Smithing
            Smithing1 s1 = new Smithing1(TraitStatus.inactive);
            Smithing2 s2 = new Smithing2(TraitStatus.inactive);
            Smithing3 s3 = new Smithing3(TraitStatus.inactive);
            Weaponsmith s3_1 = new Weaponsmith(TraitStatus.inactive);
            Armorsmith s3_2 = new Armorsmith(TraitStatus.inactive);
            Artificer s3_3 = new Artificer(TraitStatus.inactive);
            Smithing4 s4 = new Smithing4(TraitStatus.inactive);
            Smithing5 s5 = new Smithing5(TraitStatus.inactive);
            Gilder s5_1 = new Gilder(TraitStatus.inactive);
            Engraver s5_2 = new Engraver(TraitStatus.inactive);
            Link(root, s1);
            Link(s1, s2);
            Link(s2, s3);
            Link(s3, s3_1);
            Link(s3, s3_2);
            Link(s3, s3_3);
            Link(s3_1, s4);
            Link(s3_2, s4);
            Link(s3_3, s4);
            Link(s4, s5);
            Link(s5, s5_1);
            Link(s5, s5_2); 
        }

        private void Link(Trait parent, Trait child)
        {
            child.parents.Add(parent);
            parent.children.Add(child);
        }
    }
}
