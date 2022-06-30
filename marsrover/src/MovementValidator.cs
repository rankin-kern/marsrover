namespace marsrover
{
    public class MovementValidator : IMovementValidator
    {
        private Grid grid;

        public MovementValidator(Grid grid)
        {
            this.grid = grid;
        }

        public bool isSquareOnGrid(Coordinates square)
        {
            return (square.X >= 0 && square.X <= this.grid.Corner.X) &&
                       (square.Y >= 0 && square.Y <= this.grid.Corner.Y);
        }

        public bool isSquareEmpty(Coordinates square)
        {
            foreach (Rover r in this.grid.getRovers())
            {
                if (r.CurrentCoordinates.X == square.X &&
                    r.CurrentCoordinates.Y == square.Y)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

