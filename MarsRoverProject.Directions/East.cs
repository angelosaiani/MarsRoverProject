using MarsRoverProject.Contracts;

namespace MarsRoverProject.Directions
{
    public class East : DirectionBase, IDirection
    {
        public East(IPlanet planet) : base(planet)
        {
            Code = DirectionCodeEnum.E;
        }

        public IDirection TurnRight()
        {
            return new South(Planet);
        }

        public IDirection TurnLeft()
        {
            return new North(Planet);
        }

        public ICmdResult MoveForward()
        {
            return Planet.MoveXForward();
        }

        public ICmdResult MoveBackward()
        {
            return Planet.MoveXBackward();
        }

        public override string ToString()
        {
            return Code.ToString();
        }
    }
}
