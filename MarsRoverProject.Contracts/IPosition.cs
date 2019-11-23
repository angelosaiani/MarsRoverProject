using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Contracts
{
    public interface IPosition
    {
        void Init(int x, int y);
        int X { get; set; }
        int Y { get; set; }
    }
}
