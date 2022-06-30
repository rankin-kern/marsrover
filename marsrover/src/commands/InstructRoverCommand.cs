﻿namespace marsrover.commands
{
    public class InstructRoverCommand : IGridCommand
    {
        private RoverCommand[] commands;

        public InstructRoverCommand(RoverCommand[] commands)
        {
            this.commands = commands;
        }

        public string Execute(IPlateau grid)
        {
            grid.SetRoverCommands(this.commands);

            return "Enter starting location of next rover, or 'r' to run commands";
        }
    }
}

