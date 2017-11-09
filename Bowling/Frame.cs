﻿using System;
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

        public virtual bool Completed => Rolls.Count == 2 || Pins == 10;

        public virtual void Roll(int pins)
        {
            var roll = new Roll()
            {
                Pins = pins
            };

            if (IsSpare(roll))
                roll.Spare = true;

            Rolls.Add(roll);
        }

        private bool IsSpare(Roll roll)
        {
            if (!Rolls.Any())
                return false;
            if (roll.Strike)
                return false;

            return Rolls.Last().Pins + roll.Pins == 10;
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

        public override int Score {
            get
            {
                if (Rolls.Any())
                {
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

            if (Rolls.Count == 3)
                Rolls.Last().Pins = 0;
            if (Rolls.Count == 2 && Rolls.First().Strike)
                Rolls.Last().Pins = 0;

        }
    }
}
