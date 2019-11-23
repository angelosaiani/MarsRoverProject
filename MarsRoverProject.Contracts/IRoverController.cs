using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Contracts
{
    public interface IRoverController
    {
        IRoverCommandExecutor Executor { get; }
        string ActualLocation();
        void Init(IPlanet planet, string directionFacing);
        void GiveCommands(string inputCommands);
    }
}
