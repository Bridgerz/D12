using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Inventory.Scripts.ItemObject
{
    [Serializable]
    public class SlotLocation : ICloneable
    {
        public SlotLocation(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public SlotLocation()
        {
            X = 0;
            Y = 0;
        }

        public SlotLocation(SlotLocation right)
        {
            X = right.X;
            Y = right.Y;
        }

        public object Clone()
        {
            return new SlotLocation(this);
        }
    }
}
