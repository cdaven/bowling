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

        public virtual bool IsCompleted => Rolls.Count == 2 || Pins == NumPins;

        protected readonly int NumPins;

        public Frame(int numPins = 10)
        {
            NumPins = numPins;
        }

        public virtual void Roll(int pins)
        {
            if (pins < 0 || pins > NumPins)
                throw new Exception("Can only roll 0-10 pins");

            var roll = new Roll(pins);
            Rolls.Add(roll);
            roll.IsSpare = IsSpare();
        }

        private bool IsSpare()
        {
            if (Rolls.Count < 2)
                return false;

            var lastTwoRolls = Rolls.Reverse().Take(2);
            return NumPins == lastTwoRolls.Sum(r => r.Pins)
                && !lastTwoRolls.Any(r => r.IsStrike);
        }

        public override string ToString()
        {
            return string.Join(",", Rolls.Select(f => f.ToString()));
        }
    }

    class LastFrame : Frame
    {
        public LastFrame(int numPins = 10)
            : base(numPins)
        {
        }

        public override bool IsCompleted
        {
            get
            {
                if (Rolls.Count < 2)
                    return false;
                else if (Rolls.Count == 2)
                    return Pins < NumPins;
                else
                    return true;
            }
        }

        public override int Score
        {
            get
            {
                if (!Rolls.Any())
                    return 0;
                else if (Rolls.First().IsStrike)
                    // If the first roll was a strike, we don't count the rolls after it
                    return Rolls.First().Score;
                else
                    // Otherwise, we count the first 2 rolls
                    return Rolls.Take(2).Sum(r => r.Score);
            }
        }

        public override void Roll(int pins)
        {
            base.Roll(pins);
        }
    }
}
