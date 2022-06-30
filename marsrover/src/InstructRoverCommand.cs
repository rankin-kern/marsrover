using System;
namespace marsrover
{
    public class InstructRoverCommand : IGridCommand
    {
        private RoverCommand[] commands;

        public InstructRoverCommand(RoverCommand[] commands)
        {
            this.commands = commands;
        }

        public string Execute(Grid grid)
        {
            if (grid.activeRover == null)
            {
                throw new InvalidOperationException("rover position not set");
            }

            grid.activeRover.Commands = this.commands;

            return "Enter starting location of next rover, or 'r' to run commands";
        }
    }
}

