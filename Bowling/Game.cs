using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game
    {
        public bool Completed => frames.All(f => f.Completed);

        private IList<Frame> frames;

        public Game()
        {
            frames = new List<Frame>() {
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new TenthFrame()
            };
        }

        public void Roll(int pins)
        {
            if (Completed)
                throw new Exception("Game already completed, can't roll any more");
            if (pins < 0 || pins > 10)
                throw new Exception("Can only throw 0-10 pins");

            foreach (var each in FindBonusRolls())
                each.AddBonus(pins);

            GetCurrentFrame().Roll(pins);
        }

        public int Score()
        {
            return frames.Sum(f => f.Score);
        }

        private Frame GetCurrentFrame()
        {
            return frames.FirstOrDefault(f => !f.Completed);
        }

        private IEnumerable<Roll> FindBonusRolls()
        {
            var lastRolls = frames.SelectMany(f => f.Rolls).Reverse();

            var bonusRolls = new List<Roll>();
            bonusRolls.AddRange(lastRolls.Take(1).Where(r => r.Spare));
            bonusRolls.AddRange(lastRolls.Take(2).Where(r => r.Strike));
            return bonusRolls;
        }

        public override string ToString()
        {
            return string.Join(" | ", frames.Select(f => f.ToString()));
        }
    }
}
