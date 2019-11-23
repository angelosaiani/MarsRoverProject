using MarsRoverProject.IoC;
using NUnit.Framework;

namespace MarsRoverProject.Test
{
    [TestFixture]
    public class WrappingEdgeTests
    {
        [Category("WrappingEdgeX")]
        [TestCase(10, 10, "N", "RF", "X:0,Y:10,D:E")]
        [TestCase(5, 5, "N", "LFFFFFF", "X:10,Y:5,D:W")]
        public void WrappingEdgeX(int xStartPosition, int yStartPosition, string startDirectionFacing, string inputCommands, string expected)
        {
            var position = Mef.Instance.GetPosition(xStartPosition, yStartPosition);
            var planet = Mef.Instance.GetPlanet(10, position);
            var controller = Mef.Instance.GetRoverController(planet, startDirectionFacing);

            controller.GiveCommands(inputCommands);
            var result = controller.Executor.Execute();

            Assert.IsTrue(result.Completed);
            Assert.AreEqual(expected, controller.ActualLocation());
        }

        [Category("WrappingEdgeY")]
        [TestCase(6, 8, "N", "FFF", "X:6,Y:0,D:N")]
        [TestCase(10, 5, "N", "BBBBBBRR", "X:10,Y:10,D:S")]
        public void WrappingEdgeY(int xStartPosition, int yStartPosition, string startDirectionFacing, string inputCommands, string expected)
        {
            var position = Mef.Instance.GetPosition(xStartPosition, yStartPosition);
            var planet = Mef.Instance.GetPlanet(10, position);
            var controller = Mef.Instance.GetRoverController(planet, startDirectionFacing);

            controller.GiveCommands(inputCommands);
            var result = controller.Executor.Execute();

            Assert.IsTrue(result.Completed);
            Assert.AreEqual(expected, controller.ActualLocation());
        }

        [Category("WrappingEdgeXY")]
        [TestCase(6, 8, "N", "FFFFRFFFFFFF", "X:2,Y:1,D:E")]
        public void WrappingEdgeXY(int xStartPosition, int yStartPosition, string startDirectionFacing, string inputCommands, string expected)
        {
            var position = Mef.Instance.GetPosition(xStartPosition, yStartPosition);
            var planet = Mef.Instance.GetPlanet(10, position);
            var controller = Mef.Instance.GetRoverController(planet, startDirectionFacing);

            controller.GiveCommands(inputCommands);
            var result = controller.Executor.Execute();

            Assert.IsTrue(result.Completed);
            Assert.AreEqual(expected, controller.ActualLocation());
        }
    }
}
