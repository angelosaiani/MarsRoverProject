using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Contracts
{
    public interface IDirection
    {
        IDirection TurnRight();
        IDirection TurnLeft();

        ICmdResult MoveForward();
        ICmdResult MoveBackward();
    }
}
