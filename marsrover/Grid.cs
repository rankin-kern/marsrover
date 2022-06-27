// A class that defines an x,y coordinate based grid
// divided into squares.
using System.Text;

namespace marsrover
{
    public enum CompassDirection
    {
        North,
        East,
        South,
        West
    }

    public enum Direction
    {
        Left,
        Right
    }

    public class Grid
    {
        private Coordinates neCorner;
        public Rover? activeRover { get; set; }
        public List<Rover> rovers;

        // int cornerX: the X-coordinate of the top right square
        // int cornerY: the Y-coordinate of the top right square
        public Grid(int cornerX, int cornerY)
        {
            neCorner = new Coordinates(cornerX, cornerY);
            rovers = new List<Rover>();
        }

        // Given a string like '1 2 N', update the corresponding Square in the Grid
        // to have a rover on it
        public void handleStartingLocationCommand(string start)
        {
            // TODO make parsing more robust
            try
            {
                string[] parts = start.Split(' ');
                int x = Int32.Parse(parts[0]);
                int y = Int32.Parse(parts[1]);
                if (x >= 0 && x <= neCorner.X && y >= 0 && y <= neCorner.Y)
                {
                    CompassDirection direction = Converters.LetterToCompassDirection(parts[2]);
                    this.activeRover = new Rover(direction, new Coordinates(x, y));
                    rovers.Add(this.activeRover);
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        // Process an instruction like "LMLMRM"
        // Return a location and direction like "3 2 S"
        public string handleMoveCommand(string instruction)
        {
            // todo: replace string with types
            // If this is somehow called when we don't have an active rover yet,
            // return early
            if (this.activeRover == null) {
                return "";
            }

            CompassDirection newDirection = this.activeRover.currentDirection;
            Coordinates newCoordinates = this.activeRover.currentCoordinates;

            foreach (char c in instruction.ToLower()) {
                // Todo: replace string with types
                if (c == 'm')
                {
                    newCoordinates = this.activeRover.CalculateMove();
                    // Before updating the location of the rover, check that the new location won't move it
                    // off the plateau or collide with another rover.
                    // If it would, the coordinates stay the same and we will move on to the next instruction.
                    if (isSquareOnGrid(newCoordinates) && !isRoverOnSquare(newCoordinates))
                    {
                        this.activeRover.currentCoordinates = newCoordinates;
                    }
                }
                else if (c == 'l' || c == 'r')
                {
                    Direction turnDirection = Converters.LetterToDirection(c.ToString());
                    newDirection = this.activeRover.Rotate(turnDirection);
                }
            }

            StringBuilder locationString = new StringBuilder();
            locationString.Append(this.activeRover.currentCoordinates.X.ToString() + " " + this.activeRover.currentCoordinates.Y.ToString() + " " + Converters.CompassDirectionToLetter(this.activeRover.currentDirection));
            return locationString.ToString();
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
                if (r.currentCoordinates.X == targetCoordinates.X &&
                    r.currentCoordinates.Y == targetCoordinates.Y)
                {
                    return true;
                }
            }

            return false;
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

