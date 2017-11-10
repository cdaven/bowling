using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Game
    {
        public bool IsCompleted => frames.All(f => f.IsCompleted);

        private IEnumerable<Frame> frames;

        public Game(int numFrames = 10, int numPins = 10)
        {
            frames = CreateFrames(numFrames, numPins);
        }

        private IEnumerable<Frame> CreateFrames(int number = 10, int pins = 10)
        {
            IList<Frame> frames = new List<Frame>() { new LastFrame(pins) };
            for (var i = 0; i < number - 1; i++)
                frames.Add(new Frame(pins));
            return frames.Reverse();
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
            foreach (var each in GetPreviousSparesIfAny().Concat(GetPreviousStrikesIfAny()))
                each.AddBonus(pins);
        }

        private Frame GetCurrentFrame()
        {
            var frame = frames.FirstOrDefault(f => !f.IsCompleted);
            if (frame == null)
                throw new Exception("Game is already completed, cannot roll more");
            return frame;
        }

        private IEnumerable<Roll> GetPreviousSparesIfAny()
        {
            return GetPreviousRolls().Take(1).Where(r => r.IsSpare);
        }

        private IEnumerable<Roll> GetPreviousStrikesIfAny()
        {
            return GetPreviousRolls().Take(2).Where(r => r.IsStrike);
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
