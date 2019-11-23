using MarsRoverProject.Contracts;
using System.ComponentModel.Composition;

namespace MarsRoverProject.Commands
{
    [Export(typeof(ICmd))]
    public class TurnRightCmd : ICmd
    {
        private IRover rover;

        public void Init(IRover r)
        {
            rover = r;
        }

        public ICmdResult Execute()
        {
            return rover.TurnRight();
        }

        public string Code { get { return "R"; } }
    }
}
