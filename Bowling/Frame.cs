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
        public virtual int Score => Rolls.Sum(r => r.Score);

        public virtual bool Completed => Rolls.Count == MaxRolls || Pins == NumPins;

        protected readonly int MaxRolls;
        protected readonly int NumPins;

        public Frame(int maxRolls = 2, int numPins = 10)
        {
            MaxRolls = maxRolls;
            NumPins = numPins;
        }

        public virtual void Roll(int pins)
        {
            if (pins < 0 || pins > NumPins)
                throw new Exception("Can only roll 0-10 pins");

            var roll = new Roll()
            {
                Pins = pins
            };

            roll.Spare = IsSpare(roll);

            Rolls.Add(roll);
        }

        private bool IsSpare(Roll roll)
        {
            if (!Rolls.Any())
                return false;
            if (roll.Strike)
                return false;

            return NumPins == Rolls.Last().Pins + roll.Pins;
        }

        public override string ToString()
        {
            return string.Join(",", Rolls.Select(f => f.ToString()));
        }
    }

    class LastFrame : Frame
    {
        public LastFrame(int maxRolls = 3, int numPins = 10)
            : base(maxRolls, numPins)
        {
        }

        public override bool Completed
        {
            get
            {
                if (Rolls.Count < 2)
                    return false;
                else if (Rolls.Count == 2)
                    return Pins < NumPins;

                return true;
            }
        }

        public override int Score {
            get
            {
                if (Rolls.Any())
                {
                    // The 3rd frame never counts,
                    // and neither does the 2nd if the 1st is a strike.
                    return Rolls.Sum(r => r.Score);
                }
                else
                {
                    return 0;
                }
            }
        }

        public override void Roll(int pins)
        {
            base.Roll(pins);

            if (Rolls.Count == MaxRolls)
                Rolls.Last().Pins = 0;
            if (Rolls.Count == 2 && Rolls.First().Strike)
                Rolls.Last().Pins = 0;

        }
    }
}
