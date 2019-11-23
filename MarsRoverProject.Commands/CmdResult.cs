using MarsRoverProject.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject.Commands
{
    [Export(typeof(ICmdResult))]
    public class CmdResult : ICmdResult
    {
        public bool Completed { get; set; } = true;
        public bool DetectedObstacle { get; set; } = false;
        public IPosition ObstaclePosition { get; set; } = null;
    }
}
