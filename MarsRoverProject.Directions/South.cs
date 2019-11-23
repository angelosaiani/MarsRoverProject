using MarsRoverProject.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Directions
{
    public class South : DirectionBase, IDirection
    {
        public South(IPlanet planet) : base(planet)
        {
            Code = DirectionCodeEnum.S;
        }

        public IDirection TurnRight()
        {
            return new West(Planet);
        }

        public IDirection TurnLeft()
        {
            return new East(Planet);
        }

        public ICmdResult MoveForward()
        {
            return Planet.MoveYBackward();
        }

        public ICmdResult MoveBackward()
        {
            return Planet.MoveYForward();
        }

        public override string ToString()
        {
            return Code.ToString();
        }
    }
}
