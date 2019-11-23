using MarsRoverProject.Contracts;
using MarsRoverProject.IoC;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace MarsRoverProject
{
    [Export(typeof(ICommandParser))]
    public class CommandParser : ICommandParser
    {
        #region Constructor
        protected CommandParser()
        {

        } 
        #endregion

        #region Properties
        private IRover _rover;
        private Dictionary<string, ICmd> _dicCommands = null; 
        #endregion

        #region Public methods
        public void Init(IRover rover)
        {
            _rover = rover;
            LoadCommands();
        }

        public IList<ICmd> ParseCommands(string commands)
        {
            ParseCommands(commands, out IList<ICmd> outputRoverCommands);
            return outputRoverCommands;
        } 
        #endregion

        #region Private methods
        private void ParseCommands(string roverCommands, out IList<ICmd> outputRoverCommands)
        {
            outputRoverCommands = new List<ICmd>();
            for (var i = 0; i < roverCommands.Length; i++)
            {
                var command = ParseCommand(roverCommands[i].ToString());
                outputRoverCommands.Add(command);
            }
        }

        private ICmd ParseCommand(string command)
        {
            return _dicCommands[command];
        }

        private void LoadCommands()
        {
            var commands = Mef.Instance.GetCommands(_rover);
            _dicCommands = commands.ToDictionary(x => x.Code, x => x);
        } 
        #endregion
    }
}