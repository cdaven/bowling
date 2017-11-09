using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    class Roll
    {
        public int Pins { get; set; } = 0;
        public int Bonus { get; private set; } = 0;
        public int Score => Pins + Bonus;

        public bool Strike => Pins == 10;
        public bool Spare { get; set; } = false;

        public void AddBonus(int pins)
        {
            Bonus += pins;
        }

        public override string ToString()
        {
            var s = Pins.ToString();
            if (Bonus > 0)
                s += $"(+{Bonus})";
            return s;
        }
    }
}
