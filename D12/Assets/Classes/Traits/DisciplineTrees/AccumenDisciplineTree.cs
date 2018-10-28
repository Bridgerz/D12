/// AccumenDisciplineTree.cs
/// D12 Team

using System;
using System.Collections.Generic;

namespace Assets.Classes.Traits
{
    /// <summary>
    /// Tree of all accumen discipline based traits
    /// </summary>
    public class AccumenDisciplineTree
    {
        public Trait root;

        public Linguist1 linguist1 = new Linguist1(TraitStatus.purchasble);
        public Linguist2 linguist2 = new Linguist2(TraitStatus.inactive);
        public Linguist3 linguist3 = new Linguist3(TraitStatus.inactive);
        public Multilinguist multilinguist = new Multilinguist(TraitStatus.inactive);
        public Transcriber transcriber = new Transcriber(TraitStatus.inactive);
        public Linguist4 linguist4 = new Linguist4(TraitStatus.inactive);
        public Linguist5 linguist5 = new Linguist5(TraitStatus.inactive);
        public Archlinguist archlinguist = new Archlinguist(TraitStatus.inactive);
        public GlobalLocal globalLocal = new GlobalLocal(TraitStatus.inactive);

        public ChromicInsight1 chromicInsight1 = new ChromicInsight1(TraitStatus.purchasble);
        public ChromicInsight2 chromicInsight2 = new ChromicInsight2(TraitStatus.inactive);
        public ChromicInsight3 chromicInsight3 = new ChromicInsight3(TraitStatus.inactive);

        public Religion1 religion1 = new Religion1(TraitStatus.purchasble);
        public Religion2 religion2 = new Religion2(TraitStatus.inactive);
        public Religion3 religion3 = new Religion3(TraitStatus.inactive);
        public Religion4 religion4 = new Religion4(TraitStatus.inactive);
        public Religion5 religion5 = new Religion5(TraitStatus.inactive);
        public Philotheos philotheos = new Philotheos(TraitStatus.inactive);
        public Blessed blessed = new Blessed(TraitStatus.inactive);

        public AccumenDisciplineTree()
        {
            root = new Trait("root", "root of accumen tree", 0, TraitStatus.active);

            link(root, linguist1);
            link(linguist1, linguist2);
            link(linguist3, multilinguist);
            link(linguist3, transcriber);
            link(multilinguist, linguist4);
            link(transcriber, linguist4);
            link(linguist4, linguist5);
            link(linguist5, archlinguist);
            link(linguist5, globalLocal);

            link(root, chromicInsight1);
            link(chromicInsight1, chromicInsight2);
            link(chromicInsight2, chromicInsight3);

            link(root, religion1);
            link(religion1, religion2);
            link(religion2, religion3);
            link(religion3, religion4);
            link(religion4, religion5);
            link(religion5, philotheos);
            link(religion5, blessed);
        }

        private void link(Trait parent, Trait child)
        {
            child.parents.Add(parent);
            parent.children.Add(child);
        }
    }
}
