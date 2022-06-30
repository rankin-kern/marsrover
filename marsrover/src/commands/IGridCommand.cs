namespace marsrover.commands
{
    // Interface for a command parsed from input that
    // will take action on the plateau in some way
    public interface IGridCommand
    {
        public string Execute(Grid grid);
    }
}

