/// SkillDisciplineTree.cs
/// D12 Team

using System;
using System.Collections.Generic;

namespace Assets.Classes.Traits
{
    /// <summary>
    /// Tree of all skill discipline based traits
    /// </summary>
    class SkillDisciplineTree
    {
        public Trait root;

        public int TotalSpentEXP;

        public SkillDisciplineTree()
        {
            TotalSpentEXP = 0;

            root = new Trait("root", "root of skill tree", 0, true);

            // Lockpicking
            Lockpicking1 l1 = new Lockpicking1(false);
            Lockpicking2 l2 = new Lockpicking2(false);
            Lockpicking3 l3 = new Lockpicking3(false);
            Lockpicking4 l4 = new Lockpicking4(false);
            Lockpicking5 l5 = new Lockpicking5(false);
            Safebreaker safebreaker= new Safebreaker(false);
            Vandal vandal = new Vandal(false);
            Link(root, l1);
            Link(l1, l2);
            Link(l2, l3);
            Link(l3, l4);
            Link(l4, l5);
            Link(l5, safebreaker);
            Link(l5, vandal);

            // Deception
            Deception1 d1 = new Deception1(false);
            Deception2 d2 = new Deception2(false);
            Deception3 d3 = new Deception3(false);
            Pawner pawner = new Pawner(false);
            SmoothTalker smooth = new SmoothTalker(false);
            Deception4 d4 = new Deception4(false);
            Deception5 d5 = new Deception5(false);
            Link(root, d1);
            Link(d1, d2);
            Link(d2, d3);
            Link(d3, pawner);
            Link(d3, smooth);
            Link(pawner, d4);
            Link(smooth, d4);
            Link(d4, d5);

            // Smithing
            Smithing1 s1 = new Smithing1(false);
            Smithing2 s2 = new Smithing2(false);
            Smithing3 s3 = new Smithing3(false);
            Weaponsmith weaponsmith = new Weaponsmith(false);
            Armorsmith armorsmith = new Armorsmith(false);
            Artificer artificer = new Artificer(false);
            Smithing4 s4 = new Smithing4(false);
            Smithing5 s5 = new Smithing5(false);
            Gilder gilder = new Gilder(false);
            Engraver engraver = new Engraver(false);
            Link(root, s1);
            Link(s1, s2);
            Link(s2, s3);
            Link(s3, weaponsmith);
            Link(s3, armorsmith);
            Link(s3, artificer);
            Link(weaponsmith, s4);
            Link(armorsmith, s4);
            Link(artificer, s4);
            Link(s4, s5);
            Link(s5, gilder);
            Link(s5, engraver); 
        }

        private void Link(Trait parent, Trait child)
        {
            child.parents.Add(parent);
            parent.children.Add(child);
        }
    }
}
