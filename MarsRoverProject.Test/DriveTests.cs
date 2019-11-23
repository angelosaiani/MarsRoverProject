using MarsRoverProject.IoC;
using NUnit.Framework;

namespace MarsRoverProject.Test
{
    [TestFixture]
    public class DriveTests
    {
        [Category("MoveForward")]
        [TestCase(0, 0, "N", "RF", "X:1,Y:0,D:E")]
        [TestCase(20, 30, "N", "RFRFF", "X:21,Y:28,D:S")]
        [TestCase(40, 10, "N", "LFFFLFLLFF", "X:37,Y:11,D:N")]
        [TestCase(15, 15, "N", "RFFRFRFLFFRFF", "X:14,Y:12,D:W")]
        public void MoveForward(int xStartPosition, int yStartPosition, string startDirectionFacing, string inputCommands, string expected)
        {
            var position = Mef.Instance.GetPosition(xStartPosition, yStartPosition);
            var planet = Mef.Instance.GetPlanet(50, position);
            var controller = Mef.Instance.GetRoverController(planet, startDirectionFacing);

            controller.GiveCommands(inputCommands);
            var result = controller.Executor.Execute();

            Assert.IsTrue(result.Completed);
            Assert.AreEqual(expected, controller.ActualLocation());
        }

        [Category("MoveBackward")]
        [TestCase(2, 2, "N", "RB", "X:1,Y:2,D:E")]
        [TestCase(20, 30, "N", "RBRBB", "X:19,Y:32,D:S")]
        [TestCase(40, 10, "N", "LBBBLBLLBB", "X:43,Y:9,D:N")]
        [TestCase(15, 15, "N", "RBBRBRBLBBRBB", "X:16,Y:18,D:W")]
        public void MoveBackward(int xStartPosition, int yStartPosition, string startDirectionFacing, string inputCommands, string expected)
        {
            var position = Mef.Instance.GetPosition(xStartPosition, yStartPosition);
            var planet = Mef.Instance.GetPlanet(50, position);
            var controller = Mef.Instance.GetRoverController(planet, startDirectionFacing);

            controller.GiveCommands(inputCommands);
            var result = controller.Executor.Execute();

            Assert.IsTrue(result.Completed);
            Assert.AreEqual(expected, controller.ActualLocation());
        }
    }
}
