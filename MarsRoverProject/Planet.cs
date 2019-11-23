using MarsRoverProject.Contracts;
using MarsRoverProject.IoC;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject
{
    [Export(typeof(IPlanet))]
    public class Planet : IPlanet
    {
        #region Constructor
        protected Planet()
        {
            Id = Guid.NewGuid().ToString();
        }
        #endregion

        #region Public properties
        public int GridSize { get; private set; }
        public IPosition Position { get; private set; }
        public IEnumerable<IPosition> Obstacles { get; private set; }
        public string Id { get; private set; }
        #endregion

        #region Public methods
        public void Init(int gridSize, IPosition startPosition = null, List<IPosition> obstables = null)
        {
            GridSize = gridSize;

            if (startPosition == null)
                Position = Mef.Instance.GetPosition(0,0);
            else
                Position = startPosition;

            if (obstables == null)
                Obstacles = new List<IPosition>();
            else
                Obstacles = obstables;
        }

        public ICmdResult MoveYBackward()
        {
            var tempNewY = MoveRoverBackwardsOnCoordinate(Position.Y);
            var tempNewPosition = Mef.Instance.GetPosition(Position.X, tempNewY);
            var cmdResult = DetectionObstacles(tempNewPosition);

            if (cmdResult.Completed && !cmdResult.DetectedObstacle)
                Position.Y = tempNewY;

            return cmdResult;
        }

        public ICmdResult MoveXBackward()
        {
            var tempNewX = MoveRoverBackwardsOnCoordinate(Position.X);
            var tempNewPosition = Mef.Instance.GetPosition(tempNewX, Position.Y);
            var cmdResult = DetectionObstacles(tempNewPosition);

            if (cmdResult.Completed && !cmdResult.DetectedObstacle)
                Position.X = tempNewX;

            return cmdResult;
        }

        public string GridDimension()
        {
            return string.Format("{0}x{1}", GridSize, GridSize);
        }

        public ICmdResult MoveYForward()
        {
            var tempNewY = MoveRoverForwardsOnCoordinate(Position.Y);
            var tempNewPosition = Mef.Instance.GetPosition(Position.X, tempNewY);
            var cmdResult = DetectionObstacles(tempNewPosition);

            if (cmdResult.Completed && !cmdResult.DetectedObstacle)
                Position.Y = tempNewY;

            return cmdResult;
        }

        public ICmdResult MoveXForward()
        {
            var tempNewX = MoveRoverForwardsOnCoordinate(Position.X);
            var tempNewPosition = Mef.Instance.GetPosition(tempNewX, Position.Y);
            var cmdResult = DetectionObstacles(tempNewPosition);

            if (cmdResult.Completed && !cmdResult.DetectedObstacle)
                Position.X = tempNewX;

            return cmdResult;
        }
        #endregion

        #region Private methods
        private int MoveRoverForwardsOnCoordinate(int valueCoordinate)
        {
            return valueCoordinate < GridSize ? (valueCoordinate + 1) : 0;
        }

        private int MoveRoverBackwardsOnCoordinate(int valueCoordinate)
        {
            return valueCoordinate >= 1 ? (valueCoordinate - 1) : GridSize;
        } 

        private ICmdResult DetectionObstacles(IPosition inputPosition)
        {
            ICmdResult cmdResult = Mef.Instance.GetCmdResult();

            if (Obstacles.Count(o => o.Equals(inputPosition)) > 0)
            {
                cmdResult.Completed = false;
                cmdResult.DetectedObstacle = true;
                cmdResult.ObstaclePosition = inputPosition;
            }

            return cmdResult;
        }
        #endregion
    }
}
