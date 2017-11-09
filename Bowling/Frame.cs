using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    class Frame
    {
        public IList<Roll> Rolls { get; set; } = new List<Roll>();
        public int Pins => Rolls.Sum(r => r.Pins);
        public int Points => Rolls.Sum(r => r.Pins + r.Bonus);

        public virtual bool Completed => Rolls.Count == 2 || Pins == 10;

        public virtual void Roll(int pins)
        {
            var roll = new Roll()
            {
                Pins = pins
            };

            if (!roll.Strike && Rolls.Any() && Rolls.Last().Pins + pins == 10)
                roll.Spare = true;

            Rolls.Add(roll);
        }

        public override string ToString()
        {
            return string.Join(",", Rolls.Select(f => f.ToString()));
        }
    }

    class TenthFrame : Frame
    {
        public override bool Completed
        {
            get
            {
                if (Rolls.Count < 2)
                    return false;
                else if (Rolls.Count == 2)
                    return Pins < 10;

                return true;
            }
        }

        public override void Roll(int pins)
        {
            base.Roll(pins);

            if (Rolls.Count == 3)
                Rolls.Last().Pins = 0;
            if (Rolls.Count == 2 && Rolls.First().Strike)
                Rolls.Last().Pins = 0;
        }
    }
}
