using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling;

namespace UnitTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestSevenFramesZeroes()
        {
            var game = new Game(numFrames: 7);
            game.Roll(0); game.Roll(0);
            game.Roll(0); game.Roll(0);
            game.Roll(0); game.Roll(0);
            game.Roll(0); game.Roll(0);
            game.Roll(0); game.Roll(0);
            game.Roll(0); game.Roll(0);
            game.Roll(0); game.Roll(0);
            Assert.AreEqual(0, game.Score());
            Assert.IsTrue(game.IsCompleted);
        }

        [TestMethod]
        public void TestSevenFramesStrikes()
        {
            var game = new Game(numFrames: 7);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10); 
            Assert.AreEqual(7 * 30, game.Score());
            Assert.IsTrue(game.IsCompleted);
        }
    }
}
