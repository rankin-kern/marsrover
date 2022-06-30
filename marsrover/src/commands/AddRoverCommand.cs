namespace marsrover.commands
{
    public class AddRoverCommand : IGridCommand
    {
        private StartCommand start;

        public AddRoverCommand(StartCommand startCommand)
        {
            this.start = startCommand;
        }

        public string Execute(IPlateau grid)
        {
            grid.AddRover(start);
            return "Enter rover instructions";
        }
    }
}

