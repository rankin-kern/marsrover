namespace marsrover.commands
{
    public class ExitCommand : IGridCommand
    {
        public string Execute(IPlateau grid)
        {
            Environment.Exit(0);
            return "Goodbye";
        }
    }
}

