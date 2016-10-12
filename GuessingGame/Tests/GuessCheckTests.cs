using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGame;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GuessCheckTests
    {

        [Test]
        public void GuessIsHigh()
        {
            GuessCheck guessCheck = new GuessCheck(10);
            string response = guessCheck.Guess(12);
            Assert.AreEqual("guess was too high.", response);
        }

        //[Test]
        //public void InvalidGuess()
        //{
        //    guessCheck = new GuessCheck();
        //    string response = guessCheck.GuessChecker("sdjkfgajhkfv", 10);
        //    Assert.AreEqual("invalid number please try again.", response);
        //}

        [Test]
        public void GuessIsLow()
        {
            GuessCheck guessCheck = new GuessCheck(10);
            string response = guessCheck.Guess(8);
            Assert.AreEqual("guess was too low.", response);
        }

        [Test]
        public void GuessIsCorrect()
        {
            GuessCheck guessCheck = new GuessCheck(10);
            string response = guessCheck.Guess(10);
            Assert.AreEqual("congratulations!", response);
        }
    }
}
