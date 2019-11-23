using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Contracts
{
    public interface ICmd
    {
        string Code { get; }
        void Init(IRover r);
        ICmdResult Execute();
    }
}
