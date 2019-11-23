using MarsRoverProject.Contracts;
using MarsRoverProject.Directions;
using MarsRoverProject.IoC;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject
{
    [Export(typeof(IRover))]
    public class Rover : IRover
    {
        #region Constructor
        protected Rover()
        { }
        #endregion

        #region Properties
        private IDirection direction;
        private IPlanet planet; 

        public string Id { get; private set; }
        #endregion

        #region Public methods
        public void Init(IPlanet planetInput, string directionFacing)
        {
            Id = Guid.NewGuid().ToString();
            planet = planetInput;
            direction = GetStartDirectionFacing(directionFacing);
        }

        public string ActualLocation()
        {
            return string.Format("{0},D:{1}", planet.Position, direction.ToString());
        }

        public ICmdResult MoveForward()
        {
            return direction.MoveForward();
        }

        public ICmdResult MoveBackward()
        {
            return direction.MoveBackward();
        }

        public ICmdResult TurnRight()
        {
            var cmdResult = Mef.Instance.GetCmdResult();

            direction = direction.TurnRight();

            return cmdResult;
        }

        public ICmdResult TurnLeft()
        {
            var cmdResult = Mef.Instance.GetCmdResult();

            direction = direction.TurnLeft();

            return cmdResult;
        }
        #endregion

        #region Private methods

        private IDirection GetStartDirectionFacing(string directionFacing)
        {
            var directionCode = (DirectionCodeEnum)Enum.Parse(typeof(DirectionCodeEnum), directionFacing.ToUpper());
            switch (directionCode)
            {
                case DirectionCodeEnum.N:
                    return new North(planet);
                case DirectionCodeEnum.S:
                    return new South(planet);
                case DirectionCodeEnum.E:
                    return new East(planet);
                case DirectionCodeEnum.W:
                    return new West(planet);
                default:
                    return null;
            }
        }

        #endregion
    }
}
