using MarsRoverProject.IoC;
using NUnit.Framework;
using System;
using System.Linq;

namespace MarsRoverProject.Test
{
    [TestFixture]
    public class ObstacleDetectionTests
    {
        [Category("ObstacleDetection")]
        [TestCase(1, 1, "N", new string[] { "5,4" }, "RFLFRFLFFRFF", "X:4,Y:4,D:E")]
        //[TestCase(20, 30, "RFRFF", "X:21,Y:28,D:S")]
        //[TestCase(40, 10, "LFFFLFLLFF", "X:37,Y:11,D:N")]
        //[TestCase(15, 15, "RFFRFRFLFFRFF", "X:14,Y:12,D:W")]
        public void ObstaclesDetection(int xStartPosition, int yStartPosition, string startDirectionFacing, string[] obstablesInput
                                        , string inputCommands, string expected)
        {
            var obstacleList = obstablesInput.Select(z =>
            {
                var arr = z.Split(',');
                var x = Convert.ToInt32(arr.GetValue(0));
                var y = Convert.ToInt32(arr.GetValue(1));

                return Mef.Instance.GetPosition(x, y);
            }).ToList();

            var position = Mef.Instance.GetPosition(xStartPosition, yStartPosition);
            var planet = Mef.Instance.GetPlanet(10, position, obstacleList);
            var controller = Mef.Instance.GetRoverController(planet, startDirectionFacing);

            controller.GiveCommands(inputCommands);
            var result = controller.Executor.Execute();

            Assert.IsFalse(result.Completed);
            Assert.IsTrue(result.DetectedObstacle);
            Assert.AreEqual(expected, controller.ActualLocation());
            TestContext.Out.WriteLine("Detected obstable!");
            TestContext.Out.WriteLine("Obstable position: [{0}]", result.ObstaclePosition);
            TestContext.Out.WriteLine("Rover last position: [{0}]", controller.ActualLocation());

        }
    }
}
