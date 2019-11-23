using MarsRoverProject.Contracts;
using System.ComponentModel.Composition;

namespace MarsRoverProject.Commands
{
    [Export(typeof(ICmd))]
    public class BackwardCmd : ICmd
    {
        private IRover rover;

        public void Init(IRover r)
        {
            rover = r;
        }

        public ICmdResult Execute()
        {
           return rover.MoveBackward();
        }

        public string Code { get { return "B"; } }
    }
}