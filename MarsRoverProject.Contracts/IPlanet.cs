using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Contracts
{
    public interface IPlanet
    {
        IPosition Position { get; }
        IEnumerable<IPosition> Obstacles { get; }
        int GridSize { get; }
        string Id { get; }

        void Init(int gridSize, IPosition startPosition = null, List<IPosition> obstables = null);
        ICmdResult MoveYForward();
        ICmdResult MoveXForward();

        ICmdResult MoveYBackward();
        ICmdResult MoveXBackward();

        string GridDimension();
    }
}
