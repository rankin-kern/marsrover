namespace marsrover;

public interface IMovementValidator
{
    public bool isSquareOnGrid(Coordinates square);
    public bool isSquareEmpty(Coordinates square);
}

