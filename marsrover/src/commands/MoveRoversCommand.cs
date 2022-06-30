namespace marsrover.commands
{
    // Command for moving rovers in order they were positioned.
    public class MoveRoversCommand : IGridCommand
    {
        public string Execute(IPlateau grid)
        {
            return grid.MoveRovers();
        }
    }
}

