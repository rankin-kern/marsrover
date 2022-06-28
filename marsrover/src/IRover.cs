using System;
namespace marsrover;

public interface IRover
{
    public Coordinates CurrentCoordinates { get; }
    public CompassDirection CurrentDirection { get;  }

    public Coordinates Move();
    public CompassDirection Rotate(RoverCommand command);
}

