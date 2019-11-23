using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Contracts
{
    public interface ICommandParser
    {
        void Init(IRover rover);
        IList<ICmd> ParseCommands(string commands);
    }
}
