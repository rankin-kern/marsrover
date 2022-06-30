namespace marsrover.commands
{
    // Command for setting the move and rotate commands on the last positioned rover
    // E.g. "LLMMMRML"
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

