using System;

namespace MarsRoverProject.Contracts
{
    public interface ICmdResult
    {
        bool Completed { get; set; }
        bool DetectedObstacle { get; set; }
        IPosition ObstaclePosition { get; set; }
    }
}