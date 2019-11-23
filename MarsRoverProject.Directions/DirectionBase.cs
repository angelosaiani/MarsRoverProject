using MarsRoverProject.Contracts;

namespace MarsRoverProject.Directions
{
    public abstract class DirectionBase
    {
        protected IPlanet Planet;
        public DirectionCodeEnum Code { get; protected set; }

        protected DirectionBase(IPlanet planet)
        {
            Planet = planet;
        }
    }
}
