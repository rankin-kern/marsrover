namespace marsrover
{
    public class MovementValidator : IMovementValidator
    {
        private IPlateau grid;

        public MovementValidator(IPlateau grid)
        {
            this.grid = grid;
        }

        public bool isSquareOnGrid(Coordinates square)
        {
            return (square.X >= 0 && square.X <= this.grid.Bounds.X) &&
                       (square.Y >= 0 && square.Y <= this.grid.Bounds.Y);
        }

        public bool isSquareEmpty(Coordinates square)
        {
            foreach (Rover r in this.grid.Rovers)
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

