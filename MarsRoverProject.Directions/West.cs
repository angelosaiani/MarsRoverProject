using MarsRoverProject.Contracts;

namespace MarsRoverProject.Directions
{
    public class West : DirectionBase, IDirection
    {
        public West(IPlanet planet) : base(planet)
        {
            Code = DirectionCodeEnum.W;
        }

        public IDirection TurnRight()
        {
            return new North(Planet);
        }

        public IDirection TurnLeft()
        {
            return new South(Planet);
        }

        public ICmdResult MoveForward()
        {
            return Planet.MoveXBackward();
        }

        public ICmdResult MoveBackward()
        {
            return Planet.MoveXForward();
        }

        public override string ToString()
        {
            return Code.ToString();
        }
    }
}
