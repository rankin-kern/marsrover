namespace marsrover.commands
{
    public class AddRoverCommand : IGridCommand
    {
        private StartCommand start;

        public AddRoverCommand(StartCommand startCommand)
        {
            this.start = startCommand;
        }

        public string Execute(Grid grid)
        {
            grid.addRover(start);
            return "Enter starting location of next rover, or 'r' to run commands";
        }
    }
}

