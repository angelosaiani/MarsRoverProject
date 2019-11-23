using MarsRoverProject.Contracts;
using MarsRoverProject.IoC;
using NUnit.Framework;

namespace MarsRoverProject.Test
{
    public class BaseTest
    {
        protected IRoverController Controller;
        protected IPlanet Planet;

        public void Given(string startDirectionFacing)
        {
            Planet = Mef.Instance.GetPlanet(10);
            Controller = Mef.Instance.GetRoverController(Planet, startDirectionFacing);
        }

        protected void AssertExpectedLocation(string expected, bool result)
        {
            Assert.IsTrue(result);
            Assert.AreEqual(expected, Controller.ActualLocation());
        }
    }

    [TestFixture]
    public class TurningTests : BaseTest
    {
        [Category("TurningLeft")]
        [TestCase("N", "L", "X:0,Y:0,D:W")]
        [TestCase("N", "LL", "X:0,Y:0,D:S")]
        [TestCase("N", "LLL", "X:0,Y:0,D:E")]
        [TestCase("N", "LLLL", "X:0,Y:0,D:N")]
        [TestCase("S", "L", "X:0,Y:0,D:E")]
        [TestCase("S", "LL", "X:0,Y:0,D:N")]
        [TestCase("S", "LLL", "X:0,Y:0,D:W")]
        [TestCase("S", "LLLL", "X:0,Y:0,D:S")]
        [TestCase("E", "L", "X:0,Y:0,D:N")]
        [TestCase("E", "LL", "X:0,Y:0,D:W")]
        [TestCase("E", "LLL", "X:0,Y:0,D:S")]
        [TestCase("E", "LLLL", "X:0,Y:0,D:E")]
        [TestCase("W", "L", "X:0,Y:0,D:S")]
        [TestCase("W", "LL", "X:0,Y:0,D:E")]
        [TestCase("W", "LLL", "X:0,Y:0,D:N")]
        [TestCase("W", "LLLL", "X:0,Y:0,D:W")]
        public void TurnLeft(string startDirectionFacing, string inputCommands, string expected)
        {
            Given(startDirectionFacing);
            Controller.GiveCommands(inputCommands);
            var result = Controller.Executor.Execute();

            AssertExpectedLocation(expected, result.Completed);
        }

        [Category("TurningRight")]
        [TestCase("N", "R", "X:0,Y:0,D:E")]
        [TestCase("N", "RR", "X:0,Y:0,D:S")]
        [TestCase("N", "RRR", "X:0,Y:0,D:W")]
        [TestCase("N", "RRRR", "X:0,Y:0,D:N")]
        [TestCase("S", "R", "X:0,Y:0,D:W")]
        [TestCase("S", "RR", "X:0,Y:0,D:N")]
        [TestCase("S", "RRR", "X:0,Y:0,D:E")]
        [TestCase("S", "RRRR", "X:0,Y:0,D:S")]
        [TestCase("E", "R", "X:0,Y:0,D:S")]
        [TestCase("E", "RR", "X:0,Y:0,D:W")]
        [TestCase("E", "RRR", "X:0,Y:0,D:N")]
        [TestCase("E", "RRRR", "X:0,Y:0,D:E")]
        [TestCase("W", "R", "X:0,Y:0,D:N")]
        [TestCase("W", "RR", "X:0,Y:0,D:E")]
        [TestCase("W", "RRR", "X:0,Y:0,D:S")]
        [TestCase("W", "RRRR", "X:0,Y:0,D:W")]
        public void TurnRight(string startDirectionFacing, string inputCommands, string expected)
        {
            Given(startDirectionFacing);
            Controller.GiveCommands(inputCommands);
            var result = Controller.Executor.Execute();

            AssertExpectedLocation(expected, result.Completed);
        }
    }
}
