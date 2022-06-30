using System.Text;
using marsrover.commands;

namespace marsrover
{
    // Implementation of a Rover, which can update its position based on
    // commands passed in.
    public class Rover : IRover
    {
        private CompassDirection currentDirection;
        public CompassDirection CurrentDirection
        {
            get => currentDirection;
        }

        private Coordinates currentCoordinates;
        public Coordinates CurrentCoordinates
        {
            get => currentCoordinates;
        }

        private RoverCommand[]? commands;
        public RoverCommand[] Commands
        {
            set => commands = value;
        }

        private IMovementValidator validator;

        public Rover(CompassDirection direction, Coordinates coordinates, IMovementValidator validator)
        {
            this.currentDirection = direction;
            this.currentCoordinates = coordinates;
            this.validator = validator;
        }

        public string ProcessCommands()
        {
            if (this.commands == null)
            {
                throw new InvalidOperationException("Commands must be set on rover before processing");
            }

            
            foreach (RoverCommand command in this.commands)
            {
                if (command == RoverCommand.Move)
                {
                    this.Move();
                }
                else if (command == RoverCommand.Left || command == RoverCommand.Right)
                {
                    this.Rotate(command);
                }
            }

            // Clear out commands once they have been processed.
            this.commands = null;

            StringBuilder locationString = new StringBuilder();
            locationString.Append(this.currentCoordinates.X.ToString() + " "
                + this.currentCoordinates.Y.ToString() + " " + Converters.CompassDirectionToLetter(this.currentDirection));

            return locationString.ToString();
        }

        private void Rotate(RoverCommand command)
        {
            if (!(command.Equals(RoverCommand.Left) || command.Equals(RoverCommand.Right)))
            {
                throw new ArgumentException("Command is not a turn direction");
            }

            CompassDirection newDirection;

            if (currentDirection == CompassDirection.North)
            {
                newDirection = command == RoverCommand.Left ? CompassDirection.West : CompassDirection.East;
            }
            else if (currentDirection == CompassDirection.East)
            {
                newDirection = command == RoverCommand.Left ? CompassDirection.North : CompassDirection.South;
            }
            else if (currentDirection == CompassDirection.South)
            {
                newDirection = command == RoverCommand.Left ? CompassDirection.East : CompassDirection.West;
            }
            else // currentDirection == CompassDirection.West
            {
                newDirection = command == RoverCommand.Left ? CompassDirection.South : CompassDirection.North;
            }

            this.currentDirection = newDirection;
        }

        private void Move()
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

            // Before updating the location of the rover, check that the new location won't move it
            // off the plateau or collide with another rover.
            // If it would, the coordinates stay the same and we will move on to the next instruction.
            if (this.validator.isSquareOnGrid(newCoords) && this.validator.isSquareEmpty(newCoords))
            {
                this.currentCoordinates = newCoords;
            }
        }
    }
}

