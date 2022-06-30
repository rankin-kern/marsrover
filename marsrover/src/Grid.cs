using System.Text;
using marsrover.commands;

namespace marsrover
{
    // A class that defines an x,y coordinate based grid
    // divided into squares. Implements the IPlateau interface
    // used by other components to interact with the plateau and rovers on it.
    public class Grid : IPlateau
    {
        public Coordinates Bounds { get; set; }

        private IRover? activeRover;

        private List<IRover> rovers;
        public List<IRover> Rovers
        {
            get => rovers;
        }

        private IMovementValidator validator;

        public Grid()
        {
            activeRover = null;
            rovers = new List<IRover>();
            validator = new MovementValidator(this);
        }


        // Given a string like '1 2 N', update the corresponding Square in the Grid
        // to have a rover on it
        public void AddRover(StartCommand command)
        {
            if (this.validator.isSquareOnGrid(command.startCoordinates) && this.validator.isSquareEmpty(command.startCoordinates))
            {
                this.activeRover = new Rover(command.startDirection, command.startCoordinates, this.validator);
                rovers.Add(this.activeRover);
            }
            else
            {
                throw new InvalidOperationException("Start location invalid");
            }
        }

        // Process an instruction like "LMLMRM"
        // Return a location and direction like "3 2 S"
        public string MoveRovers()
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
            return (targetCoordinates.X >= 0 && targetCoordinates.X <= Bounds.X) &&
                   (targetCoordinates.Y >= 0 && targetCoordinates.Y <= Bounds.Y);
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

        public void SetRoverCommands(RoverCommand[] commands)
        {
            if (this.activeRover == null)
            {
                throw new InvalidOperationException("Rover location not set");
            }

            this.activeRover.Commands = commands;
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



