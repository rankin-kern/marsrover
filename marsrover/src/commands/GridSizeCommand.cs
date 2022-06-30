namespace marsrover.commands
{
    // Command for setting the coordinates that define
    // the NE corner of the grid
    public class GridSizeCommand : IGridCommand
    {
        private Coordinates neCorner;

        public string Execute(IPlateau grid)
        {
            grid.Bounds = neCorner;
            return "Enter starting location";
        }

        public GridSizeCommand(Coordinates neCorner)
        {
            this.neCorner = neCorner;
        }
    }
}

