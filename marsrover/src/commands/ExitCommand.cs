namespace marsrover.commands
{
    public class ExitCommand : IGridCommand
    {
        public string Execute(Grid grid)
        {
            Environment.Exit(0);
            return "Goodbye";
        }
    }
}

