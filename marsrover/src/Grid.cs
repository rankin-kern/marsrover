// A class that defines an x,y coordinate based grid
// divided into squares.
using System.Text;

namespace marsrover
{
    public class Grid
    {
        private Coordinates neCorner;
        public IRover? activeRover { get; set; }
        private List<IRover> rovers;
        private IMovementValidator validator;

        // int cornerX: the X-coordinate of the top right square
        // int cornerY: the Y-coordinate of the top right square
        public Grid(int cornerX, int cornerY)
        {
            neCorner = new Coordinates(cornerX, cornerY);
            activeRover = null;
            rovers = new List<IRover>();
            validator = new MovementValidator(this);
        }

        // Given a string like '1 2 N', update the corresponding Square in the Grid
        // to have a rover on it
        public void addRover(StartCommand command)
        {
            if (this.validator.isSquareOnGrid(command.startCoordinates) && this.validator.isSquareEmpty(command.startCoordinates))
            {
                this.activeRover = new Rover(command.startDirection, command.startCoordinates, this.validator);
                rovers.Add(this.activeRover);
            }
        }

        // Process an instruction like "LMLMRM"
        // Return a location and direction like "3 2 S"
        public string moveRovers()
        {
            // If this is somehow called when we don't have an active rover yet,
            // return early
            if (this.activeRover == null)
            {
                throw new InvalidOperationException("Rover location must be set first");
            }

            StringBuilder outputBuilder = new StringBuilder();
            foreach (Rover rover in this.rovers)
            {
                outputBuilder.AppendLine(rover.ProcessCommands());
            }

            return outputBuilder.ToString();
        }

        public bool isSquareOnGrid(Coordinates targetCoordinates)
        {
            return (targetCoordinates.X >= 0 && targetCoordinates.X <= this.neCorner.X) &&
                   (targetCoordinates.Y >= 0 && targetCoordinates.Y <= this.neCorner.Y);
        }

        public bool isRoverOnSquare(Coordinates targetCoordinates)
        {
            foreach (Rover r in this.rovers)
            {
                if (r.CurrentCoordinates.X == targetCoordinates.X &&
                    r.CurrentCoordinates.Y == targetCoordinates.Y)
                {
                    return true;
                }
            }

            return false;
        }


        public Coordinates getBounds()
        {
            return this.neCorner;
        }

        public List<IRover> getRovers()
        {
            return this.rovers;
        }
    }

    public struct Coordinates
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}



