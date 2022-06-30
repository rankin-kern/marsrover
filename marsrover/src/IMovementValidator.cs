namespace marsrover
{
    // Defines an interface for validating that rover movement
    // is valid. Currently that includes checking that the rover will not
    // move off the board or collide with another rover.
    public interface IMovementValidator
    {
        public bool isSquareOnGrid(Coordinates square);
        public bool isSquareEmpty(Coordinates square);
    }
}

