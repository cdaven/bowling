using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    class Roll
    {
        const int MAX_PINS = 10;
        
        public int Pins { get; set; } = 0;
        public int Bonus { get; private set; } = 0;
        public int Score => Pins + Bonus;

        public bool Strike => Pins == MAX_PINS;
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
