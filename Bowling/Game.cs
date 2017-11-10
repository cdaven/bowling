using System;
using System.Collections.Generic;
using System.Linq;

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
                frames.Add(new Frame(pins));
            }
            frames.Add(new LastFrame(pins));
            return frames;
        }

        public void Roll(int pins)
        {
            GetCurrentFrame().Roll(pins);
            AddBonusesToPreviousRolls(pins);
        }

        public int Score()
        {
            return frames.Sum(f => f.Score);
        }

        private void AddBonusesToPreviousRolls(int pins)
        {
            var sparesAndStrikes = GetPreviousSparesIfAny()
                .Concat(GetPreviousStrikesIfAny());

            foreach (var each in sparesAndStrikes)
                each.AddBonus(pins);
        }

        private Frame GetCurrentFrame()
        {
            var frame = frames.FirstOrDefault(f => !f.Completed);
            if (frame == null)
                throw new Exception("Game is already completed, cannot roll more");
            return frame;
        }

        private IEnumerable<Roll> GetPreviousSparesIfAny(int lookBack = 1)
        {
            return GetPreviousRolls().Take(lookBack).Where(r => r.IsSpare);
        }

        private IEnumerable<Roll> GetPreviousStrikesIfAny(int lookBack = 2)
        {
            return GetPreviousRolls().Take(lookBack).Where(r => r.IsStrike);
        }

        private IEnumerable<Roll> GetPreviousRolls()
        {
            return frames.SelectMany(f => f.Rolls)
                .Reverse()
                .Skip(1);
        }

        public override string ToString()
        {
            return string.Join(" | ", frames.Select(f => f.ToString()));
        }
    }
}
