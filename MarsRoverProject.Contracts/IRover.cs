using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Contracts
{
    public interface IRover
    {
        string Id { get; }

        string ActualLocation();

        void Init(IPlanet planetInput, string directionFacing);

        ICmdResult MoveForward();
        ICmdResult MoveBackward();

        ICmdResult TurnRight();
        ICmdResult TurnLeft();
    }
}
