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

        public Lockpicking1 lockpicking1;
        public Lockpicking2 lockpicking2;
        public Lockpicking3 lockpicking3;
        public Lockpicking4 lockpicking4;
        public Lockpicking5 lockpicking5;
        public Safebreaker safebreaker;
        public Vandal vandal;

        public Deception1 deception1;
        public Deception2 deception2;
        public Deception3 deception3;
        public Pawner pawner;
        public SmoothTalker smoothTalker;
        public Deception4 deception4;
        public Deception5 deception5;

        public Smithing1 smithing1;
        public Smithing2 smithing2;
        public Smithing3 smithing3;
        public Weaponsmith weaponsmith;
        public Armorsmith armorsmith;
        public Artificer artificer;
        public Smithing4 smithing4;
        public Smithing5 smithing5;
        public Gilder gilder;
        public Engraver engraver;

        public SkillDisciplineTree()
        {
            root = new Trait("root", "root of skill tree", 0, TraitStatus.active);

            // Lockpicking
            lockpicking1 = new Lockpicking1(TraitStatus.inactive);
            lockpicking2 = new Lockpicking2(TraitStatus.inactive);
            lockpicking3 = new Lockpicking3(TraitStatus.inactive);
            lockpicking4 = new Lockpicking4(TraitStatus.inactive);
            lockpicking5 = new Lockpicking5(TraitStatus.inactive);
            safebreaker = new Safebreaker(TraitStatus.inactive);
            vandal = new Vandal(TraitStatus.inactive);

            Link(root, lockpicking1);
            Link(lockpicking1, lockpicking2);
            Link(lockpicking2, lockpicking3);
            Link(lockpicking3, lockpicking4);
            Link(lockpicking4, lockpicking5);
            Link(lockpicking5, safebreaker);
            Link(lockpicking5, vandal);

            // Deception
            deception1 = new Deception1(TraitStatus.inactive);
            deception2 = new Deception2(TraitStatus.inactive);
            deception3 = new Deception3(TraitStatus.inactive);
            pawner = new Pawner(TraitStatus.inactive);
            smoothTalker = new SmoothTalker(TraitStatus.inactive);
            deception4 = new Deception4(TraitStatus.inactive);
            deception5 = new Deception5(TraitStatus.inactive);

            Link(root, deception1);
            Link(deception1, deception2);
            Link(deception2, deception3);
            Link(deception3, pawner);
            Link(deception3, smoothTalker);
            Link(pawner, deception4);
            Link(smoothTalker, deception4);
            Link(deception4, deception5);

            // Smithing
            smithing1 = new Smithing1(TraitStatus.inactive);
            smithing2 = new Smithing2(TraitStatus.inactive);
            smithing3 = new Smithing3(TraitStatus.inactive);
            weaponsmith = new Weaponsmith(TraitStatus.inactive);
            armorsmith = new Armorsmith(TraitStatus.inactive);
            artificer = new Artificer(TraitStatus.inactive);
            smithing4 = new Smithing4(TraitStatus.inactive);
            smithing5 = new Smithing5(TraitStatus.inactive);
            gilder = new Gilder(TraitStatus.inactive);
            engraver = new Engraver(TraitStatus.inactive);

            Link(root, smithing1);
            Link(smithing1, smithing2);
            Link(smithing2, smithing3);
            Link(smithing3, weaponsmith);
            Link(smithing3, armorsmith);
            Link(smithing3, artificer);
            Link(weaponsmith, smithing4);
            Link(armorsmith, smithing4);
            Link(artificer, smithing4);
            Link(smithing4, smithing5);
            Link(smithing5, gilder);
            Link(smithing5, engraver);
        }

        private void Link(Trait parent, Trait child)
        {
            child.parents.Add(parent);
            parent.children.Add(child);
        }
    }
}
