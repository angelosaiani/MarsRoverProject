using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Contracts
{
    public interface IRoverCommandExecutor
    {
        void AddCommands(IList<ICmd> commandList);
        ICmdResult Execute();
    }
}
