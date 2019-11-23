using MarsRoverProject.Contracts;

namespace MarsRoverProject.Directions
{
    public class North : DirectionBase, IDirection
    {
        public North(IPlanet planet) : base(planet)
        {
            Code = DirectionCodeEnum.N;
        }

        public IDirection TurnRight()
        {
            return new East(Planet);
        }

        public IDirection TurnLeft()
        {
            return new West(Planet);
        }

        public ICmdResult MoveForward()
        {
            return Planet.MoveYForward();
        }

        public ICmdResult MoveBackward()
        {
            return Planet.MoveYBackward();
        }

        public override string ToString()
        {
            return Code.ToString();
        }
    }
}
