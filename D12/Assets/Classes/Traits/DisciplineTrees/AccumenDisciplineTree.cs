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

        public Linguist1 linguist1;
        public Linguist2 linguist2;
        public Linguist3 linguist3;
        public Multilinguist multilinguist;
        public Transcriber transcriber;
        public Linguist4 linguist4;
        public Linguist5 linguist5;
        public Archlinguist archlinguist;
        public GlobalLocal globalLocal;

        public ChromicInsight1 chromicInsight1;
        public ChromicInsight2 chromicInsight2;
        public ChromicInsight3 chromicInsight3;

        public Religion1 religion1;
        public Religion2 religion2;
        public Religion3 religion3;
        public Religion4 religion4;
        public Religion5 religion5;
        public Philotheos philotheos;
        public Blessed blessed;

        public AccumenDisciplineTree()
        {
            root = new Trait("root", "root of accumen tree", 0, TraitStatus.active);

            linguist1 = new Linguist1(TraitStatus.inactive);
            linguist2 = new Linguist2(TraitStatus.inactive);
            linguist3 = new Linguist3(TraitStatus.inactive);
            multilinguist = new Multilinguist(TraitStatus.inactive);
            transcriber = new Transcriber(TraitStatus.inactive);
            linguist4 = new Linguist4(TraitStatus.inactive);
            linguist5 = new Linguist5(TraitStatus.inactive);
            archlinguist = new Archlinguist(TraitStatus.inactive);
            globalLocal = new GlobalLocal(TraitStatus.inactive);

            link(root, linguist1);
            link(linguist1, linguist2);
            link(linguist3, multilinguist);
            link(linguist3, transcriber);
            link(multilinguist, linguist4);
            link(transcriber, linguist4);
            link(linguist4, linguist5);
            link(linguist5, archlinguist);
            link(linguist5, globalLocal);

            chromicInsight1 = new ChromicInsight1(TraitStatus.inactive);
            chromicInsight2 = new ChromicInsight2(TraitStatus.inactive);
            chromicInsight3 = new ChromicInsight3(TraitStatus.inactive);

            link(root, chromicInsight1);
            link(chromicInsight1, chromicInsight2);
            link(chromicInsight2, chromicInsight3);

            religion1 = new Religion1(TraitStatus.inactive);
            religion2 = new Religion2(TraitStatus.inactive);
            religion3 = new Religion3(TraitStatus.inactive);
            religion4 = new Religion4(TraitStatus.inactive);
            religion5 = new Religion5(TraitStatus.inactive);
            philotheos = new Philotheos(TraitStatus.inactive);
            blessed = new Blessed(TraitStatus.inactive);

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
