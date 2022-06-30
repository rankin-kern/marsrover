namespace marsrover.commands
{
    public class GridSizeCommand : IGridCommand
    {
        private Coordinates neCorner;

        public string Execute(Grid grid)
        {
            grid.Corner = neCorner;
            return "Enter starting location";
        }

        public GridSizeCommand(Coordinates neCorner)
        {
            this.neCorner = neCorner;
        }
    }
}

