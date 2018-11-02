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

        public Firebolt1 firebolt1;
        public Firebolt2 firebolt2;
        public Firebolt3 firebolt3;
        public HomeseekingEmbers homeseekingEmbers;
        public UnerringBolt unerringBolt;
        public Firebolt4 firebolt4;
        public Firebolt5 firebolt5;
        public TwoEmbers twoEmbers;
        public IgneosBirth igneosBirth;

        public LayOnHands1 layOnHands1;
        public LayOnHands2 layOnHands2;
        public LayOnHands3 layOnHands3;
        public BlessedBeTheWeak blessedBeTheWeak;
        public BlessedBeTheGiver blessedBeTheGiver;
        public LayOnHands4 layOnHands4;
        public LayOnHands5 layOnHands5;
        public RadiantTouch radiantTouch;
        public BoundlessGifts boundlessGifts;

        public Hamstring1 hamstring1;
        public Hamstring2 hamstring2;
        public Hamstring3 hamstring3;
        public DeepWound deepWound;
        public Achilles achilles;
        public Hamstring4 hamstring4;
        public Hamstring5 hamstring5;
        public Backswing backswing;
        public LeaveItBleeding leaveItBleeding;

        public CombatDisciplineTree()
        {
            // ROOT
            root = new Trait("root", "root of combat tree", 0, TraitStatus.active);

            firebolt1 = new Firebolt1(TraitStatus.inactive);
            firebolt2 = new Firebolt2(TraitStatus.inactive);
            firebolt3 = new Firebolt3(TraitStatus.inactive);
            homeseekingEmbers = new HomeseekingEmbers(TraitStatus.inactive);
            unerringBolt = new UnerringBolt(TraitStatus.inactive);
            firebolt4 = new Firebolt4(TraitStatus.inactive);
            firebolt5 = new Firebolt5(TraitStatus.inactive);
            twoEmbers = new TwoEmbers(TraitStatus.inactive);
            igneosBirth = new IgneosBirth(TraitStatus.inactive);

            link(root, firebolt1);
            link(firebolt1, firebolt2);
            link(firebolt2, firebolt3);
            link(firebolt3, homeseekingEmbers);
            link(firebolt3, unerringBolt);
            link(homeseekingEmbers, firebolt4);
            link(unerringBolt, firebolt4);
            link(firebolt4, firebolt5);
            link(firebolt5, twoEmbers);
            link(firebolt5, igneosBirth);

            layOnHands1 = new LayOnHands1(TraitStatus.inactive);
            layOnHands2 = new LayOnHands2(TraitStatus.inactive);
            layOnHands3 = new LayOnHands3(TraitStatus.inactive);
            blessedBeTheWeak = new BlessedBeTheWeak(TraitStatus.inactive);
            blessedBeTheGiver = new BlessedBeTheGiver(TraitStatus.inactive);
            layOnHands4 = new LayOnHands4(TraitStatus.inactive);
            layOnHands5 = new LayOnHands5(TraitStatus.inactive);
            radiantTouch = new RadiantTouch(TraitStatus.inactive);
            boundlessGifts = new BoundlessGifts(TraitStatus.inactive);

            link(root, layOnHands1);
            link(layOnHands1, layOnHands2);
            link(layOnHands2, layOnHands3);
            link(layOnHands3, blessedBeTheWeak);
            link(layOnHands3, blessedBeTheGiver);
            link(blessedBeTheWeak, layOnHands4);
            link(blessedBeTheGiver, layOnHands4);
            link(layOnHands4, layOnHands5);
            link(layOnHands5, radiantTouch);
            link(layOnHands5, boundlessGifts);

            hamstring1 = new Hamstring1(TraitStatus.inactive);
            hamstring2 = new Hamstring2(TraitStatus.inactive);
            hamstring3 = new Hamstring3(TraitStatus.inactive);
            deepWound  = new DeepWound(TraitStatus.inactive);
            achilles = new Achilles(TraitStatus.inactive);
            hamstring4 = new Hamstring4(TraitStatus.inactive);
            hamstring5 = new Hamstring5(TraitStatus.inactive);
            backswing = new Backswing(TraitStatus.inactive);
            leaveItBleeding = new LeaveItBleeding(TraitStatus.inactive);

            link(root, hamstring1);
            link(hamstring1, hamstring2);
            link(hamstring2, hamstring3);
            link(hamstring3, deepWound);
            link(hamstring3, achilles);
            link(deepWound, hamstring4);
            link(achilles, hamstring4);
            link(hamstring4, hamstring5);
            link(hamstring5, backswing);
            link(hamstring5, leaveItBleeding);
        }

        private void link(Trait parent, Trait child)
        {
            child.parents.Add(parent);
            parent.children.Add(child);
        }
    }
}
