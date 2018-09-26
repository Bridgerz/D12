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

        public AccumenDisciplineTree()
        {
            root = new Trait("root", "root of accumen tree", 0, true);

            Linguist1 l1 = new Linguist1(false);
            Linguist2 l2 = new Linguist2(false);
            Linguist3 l3 = new Linguist3(false);
            Multilinguist l3_1 = new Multilinguist(false);
            Transcriber l3_2 = new Transcriber(false);
            Linguist4 l4 = new Linguist4(false);
            Linguist5 l5 = new Linguist5(false);
            Archlinguist l5_1 = new Archlinguist(false);
            GlobalLocal l5_2 = new GlobalLocal(false);

            link(root, l1);
            link(l1, l2);
            link(l3, l3_1);
            link(l3, l3_2);
            link(l3_1, l4);
            link(l3_2, l4);
            link(l4, l5);
            link(l5, l5_1);
            link(l5, l5_2);

            ChromicInsight1 c1 = new ChromicInsight1(false);
            ChromicInsight2 c2 = new ChromicInsight2(false);
            ChromicInsight3 c3 = new ChromicInsight3(false);

            link(root, c1);
            link(c1, c2);
            link(c2, c3);

            Religion1 r1 = new Religion1(false);
            Religion2 r2 = new Religion2(false);
            Religion3 r3 = new Religion3(false);
            Religion4 r4 = new Religion4(false);
            Religion5 r5 = new Religion5(false);
            Philotheos r5_1 = new Philotheos(false);
            Blessed r5_2 = new Blessed(false);

            link(root, r1);
            link(r1, r2);
            link(r2, r3);
            link(r3, r4);
            link(r4, r5);
            link(r5, r5_1);
            link(r5, r5_2);
        }

        private void link(Trait parent, Trait child)
        {
            child.parents.Add(parent);
            parent.children.Add(child);
        }
    }
}
