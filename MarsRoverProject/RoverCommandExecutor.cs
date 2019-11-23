using MarsRoverProject.Contracts;
using MarsRoverProject.IoC;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace MarsRoverProject
{
    [Export(typeof(IRoverCommandExecutor))]
    public class RoverCommandExecutor : IRoverCommandExecutor
    {
        #region Constructor
        protected RoverCommandExecutor()
        {

        }
        #endregion

        #region Properties
        private IList<ICmd> _commandList;
        #endregion

        #region Public mehtods
        public void AddCommands(IList<ICmd> commandList)
        {
            _commandList = commandList;
        }

        public ICmdResult Execute()
        {
            ICmdResult cmdResult = Mef.Instance.GetCmdResult();

            foreach (var cmd in _commandList)
            {
                cmdResult = cmd.Execute();
                if (cmdResult.DetectedObstacle)
                    break;
            }

            return cmdResult;
        } 
        #endregion
    }
}
