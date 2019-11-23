using MarsRoverProject.Contracts;
using System.ComponentModel.Composition;

namespace MarsRoverProject.Commands
{
    [Export(typeof(ICmd))]
    public class ForwardCmd : ICmd
    {
        private IRover rover;

        public void Init(IRover r)
        {
            rover = r;
        }

        public ICmdResult Execute()
        {
            return rover.MoveForward();
        }

        public string Code { get { return "F"; } }
    }
}