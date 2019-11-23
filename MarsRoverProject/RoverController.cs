using MarsRoverProject.Contracts;
using MarsRoverProject.IoC;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject
{
    [Export(typeof(IRoverController))]
    public class RoverController : IRoverController
    {
        #region Constructor
        protected RoverController()
        {

        }
        #endregion

        #region Properties
        private IRover rover;

        public IRoverCommandExecutor Executor { get; private set; }
        #endregion

        #region Public methods
        public void Init(IPlanet planet, string directionFacing)
        {
            Executor = Mef.Instance.GetRoverCommandExecutor();
            rover = Mef.Instance.GetRover(planet, directionFacing);
        }

        public void GiveCommands(string roverCommands)
        {
            var commandParser = Mef.Instance.GetCommandParser(rover); //new CommandParser(rover);
            var commands = commandParser.ParseCommands(roverCommands);

            Executor.AddCommands(commands);
        }

        public string ActualLocation()
        {
            return rover.ActualLocation();
        } 
        #endregion
    }
}