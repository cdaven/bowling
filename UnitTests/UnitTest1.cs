using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEmpty()
        {
            var game = new Game();
            Assert.AreEqual(0, game.Score());
            Assert.IsFalse(game.Completed);
        }

        [TestMethod]
        public void TestZeroes()
        {
            var game = new Game();
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            Assert.AreEqual(0, game.Score());
            Assert.IsTrue(game.Completed);
        }

        [TestMethod]
        public void TestOnes()
        {
            var game = new Game();
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            Assert.AreEqual(20, game.Score());
            Assert.IsTrue(game.Completed);
        }

        [TestMethod]
        public void TestSpares()
        {
            var game = new Game();
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            game.Roll(0);
            Assert.AreEqual(19 * 5 + 9 * 5, game.Score());
            Assert.IsTrue(game.Completed);
        }

        [TestMethod]
        public void TestStrikes()
        {
            var game = new Game();
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            Assert.AreEqual(30+20+10, game.Score());
            Assert.IsTrue(game.Completed);
        }

        [TestMethod]
        public void TestMix()
        {
            var game = new Game();
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            game.Roll(10);
            Assert.AreEqual(200, game.Score());
            Assert.IsTrue(game.Completed);
        }

        [TestMethod]
        public void TestPerfectTens()
        {
            var game = new Game();
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            Assert.AreEqual(300, game.Score());
            Assert.IsTrue(game.Completed);
        }

        [TestMethod]
        public void TestBadValues()
        {
            var game = new Game();

            bool threwError;
            try
            {
                threwError = false;
                game.Roll(-1);
            }
            catch (Exception)
            {
                threwError = true;
            }
            Assert.IsTrue(threwError);

            try
            {
                threwError = false;
                game.Roll(11);
            }
            catch (Exception)
            {
                threwError = true;
            }
            Assert.IsTrue(threwError);

            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);
            game.Roll(1);

            try
            {
                threwError = false;
                game.Roll(1);
            }
            catch (Exception)
            {
                threwError = true;
            }
            Assert.IsTrue(threwError);
        }
    }
}
