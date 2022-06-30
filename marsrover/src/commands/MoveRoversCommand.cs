namespace marsrover.commands
{
    public class MoveRoversCommand : IGridCommand
    {
        public string Execute(Grid grid)
        {
            return grid.moveRovers();
        }
    }
}

