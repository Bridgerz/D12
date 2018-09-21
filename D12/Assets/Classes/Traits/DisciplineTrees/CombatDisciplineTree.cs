/// CombatDisciplineTree.cs
/// D12 Team

using System;
using System.Collections.Generic;

namespace Assets.Classes.Traits
{
    /// <summary>
    /// Tree of all combat discipline based traits
    /// </summary>
    public class CombatDisciplineTree
    {
        public Trait root;

        public CombatDisciplineTree()
        {
            // ROOT
            root = new Trait("root", "root of combat tree", 0, true);
            Firebolt1 f1 = new Firebolt1(false);
            Firebolt2 f2 = new Firebolt2(false);
            Firebolt3 f3 = new Firebolt3(false);
            HomeseekingEmbers f3_1 = new HomeseekingEmbers(false);
            UnerringBolt f3_2 = new UnerringBolt(false);
            Firebolt4 f4 = new Firebolt4(false);
            Firebolt5 f5 = new Firebolt5(false);
            TwoEmbers f5_1 = new TwoEmbers(false);
            IgneosBirth f5_2 = new IgneosBirth(false);

            link(root, f1);
            link(f1, f2);
            link(f2, f3);
            link(f3, f3_1);
            link(f3, f3_2);
            link(f3_1, f4);
            link(f3_2, f4);
            link(f4, f5);
            link(f5, f5_1);
            link(f5, f5_2);

            LayOnHands1 loh1 = new LayOnHands1(false);
            LayOnHands2 loh2 = new LayOnHands2(false);
            LayOnHands3 loh3 = new LayOnHands3(false);
            BlessedBeTheWeak loh3_1 = new BlessedBeTheWeak(false);
            BlessedBeTheGiver loh3_2 = new BlessedBeTheGiver(false);
            LayOnHands4 loh4 = new LayOnHands4(false);
            LayOnHands5 loh5 = new LayOnHands5(false);
            RadiantTouch loh5_1 = new RadiantTouch(false);
            BoundlessGifts loh5_2 = new BoundlessGifts(false);

            link(root, loh1);
            link(loh1, loh2);
            link(loh2, loh3);
            link(loh3, loh3_1);
            link(loh3, loh3_2);
            link(loh3_1, loh4);
            link(loh3_2, loh4);
            link(loh4, loh5);
            link(loh5, loh5_1);
            link(loh5, loh5_2);

            Hamstring1 h1 = new Hamstring1(false);
            Hamstring2 h2 = new Hamstring2(false);
            Hamstring3 h3 = new Hamstring3(false);
            DeepWound h3_1 = new DeepWound(false);
            Achilles h3_2 = new Achilles(false);
            Hamstring4 h4 = new Hamstring4(false);
            Hamstring5 h5 = new Hamstring5(false);
            Backswing h5_1 = new Backswing(false);
            LeaveItBleeding h5_2 = new LeaveItBleeding(false);

            link(root, h1);
            link(h1, h2);
            link(h2, h3);
            link(h3, h3_1);
            link(h3, h3_2);
            link(h3_1, h4);
            link(h3_2, h4);
            link(f4, f5);
            link(f5, f5_1);
            link(f5, f5_2);
        }

        private void link(Trait parent, Trait child) {
            child.parents.Add(parent);
            parent.children.Add(child);
        } 
    }
}
