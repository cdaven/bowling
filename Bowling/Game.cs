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

        public Game(int numFrames = 10, int numPins = 10)
        {
            frames = CreateFrames(numFrames, numPins);
        }

        private IList<Frame> CreateFrames(int number = 10, int pins = 10)
        {
            var frames = new List<Frame>();
            for (var i = 0; i < number - 1; i++)
            {
                frames.Add(new Frame(numPins: pins));
            }
            frames.Add(new LastFrame(numPins: pins));
            return frames;
        }

        public void Roll(int pins)
        {
            GetCurrentFrame().Roll(pins);

            foreach (var each in FindBonusRolls())
                each.AddBonus(pins);
        }

        public int Score()
        {
            return frames.Sum(f => f.Score);
        }

        private Frame GetCurrentFrame()
        {
            var frame = frames.FirstOrDefault(f => !f.Completed);
            if (frame == null)
                throw new Exception("Game is already completed, cannot roll more");
            return frame;
        }

        private IEnumerable<Roll> FindBonusRolls()
        {
            var previousRolls = frames.SelectMany(f => f.Rolls)
                .Reverse()
                .Skip(1);

            var bonusRolls = new List<Roll>();
            bonusRolls.AddRange(previousRolls.Take(1).Where(r => r.Spare));
            bonusRolls.AddRange(previousRolls.Take(2).Where(r => r.Strike));
            return bonusRolls;
        }

        public override string ToString()
        {
            return string.Join(" | ", frames.Select(f => f.ToString()));
        }
    }
}
