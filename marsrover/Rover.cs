using System;
namespace marsrover
{
    public class Rover
    {
        public CompassDirection currentDirection { set; get; }

        public Coordinates currentCoordinates { set; get; }

        public Rover(CompassDirection direction, Coordinates coordinates)
        {
            currentDirection = direction;
            currentCoordinates = coordinates;
        }

        public CompassDirection Rotate(Direction turnDirection)
        {
            CompassDirection newDirection;
            
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
                newDirection = turnDirection == Direction.Left ? CompassDirection.South : CompassDirection.North;
            }

            this.currentDirection = newDirection;
            return newDirection;
        }

        // Returns the grid square the rover would move to
        // if a move command was processed.
        public Coordinates CalculateMove()
        {
            Coordinates currentCoords = this.currentCoordinates;
            Coordinates newCoords = currentCoords;
            if (this.currentDirection == CompassDirection.North)
            {
               newCoords.Y = currentCoords.Y + 1;
            }
            else if (this.currentDirection == CompassDirection.East)
            {
                newCoords.X = currentCoords.X + 1;
            }
            else if (this.currentDirection == CompassDirection.South)
            {
                newCoords.Y = currentCoords.Y - 1;
            }
            else if (this.currentDirection == CompassDirection.West)
            {
                newCoords.X = currentCoords.X - 1;
            }

            return newCoords;
        }
    }
}

