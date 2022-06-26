using System;
namespace marsrover
{
    public class Rover
    {
        public CompassDirection currentDirection { set; get; }

        public Coordinates currentCoordinates { set; get; }

        public Rover(CompassDirection direction)
        {
            currentDirection = direction;
        }

        public CompassDirection Rotate(Direction turnDirection)
        {
            CompassDirection newDirection;
            // todo: maybe store direction as a compass heading and add / subtract 90?
            if (currentDirection == CompassDirection.North)
            {
                newDirection = turnDirection == Direction.Left ? CompassDirection.West : CompassDirection.East;
            }
            else if (currentDirection == CompassDirection.East)
            {
                newDirection = turnDirection == Direction.Left ? CompassDirection.North : CompassDirection.South;
            }
            else if (currentDirection == CompassDirection.South)
            {
                newDirection = turnDirection == Direction.Left ? CompassDirection.East : CompassDirection.West;
            }
            else // currentDirection == CompassDirection.West
            {
                newDirection = turnDirection == Direction.Left ? CompassDirection.South : CompassDirection.East;
            }

            return newDirection;
        }
    }
}

