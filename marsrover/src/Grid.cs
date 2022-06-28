// A class that defines an x,y coordinate based grid
// divided into squares.
using System.Text;

namespace marsrover;

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
    public void handleStartingLocationCommand(string input)
    {
        try
        {
            StartCommand command = CommandParser.ParseStartCommand(input);
            if (this.validator.isSquareOnGrid(command.startCoordinates) && this.validator.isSquareEmpty(command.startCoordinates))
            {
                this.activeRover = new Rover(command.startDirection, command.startCoordinates, this.validator);
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
        // If this is somehow called when we don't have an active rover yet,
        // return early
        if (this.activeRover == null) {
            // todo throw exception?
            return "";
        }

        CompassDirection newDirection = this.activeRover.CurrentDirection;
        Coordinates newCoordinates = this.activeRover.CurrentCoordinates;
        RoverCommand[] commands = CommandParser.ParseRoverCommand(instruction.Trim().ToLower());

        foreach (RoverCommand command in commands) {
            if (command == RoverCommand.Move)
            {
                newCoordinates = this.activeRover.Move();
            }
            else if (command == RoverCommand.Left || command == RoverCommand.Right)
            {
                newDirection = this.activeRover.Rotate(command);
            }
        }

        StringBuilder locationString = new StringBuilder();
        locationString.Append(this.activeRover.CurrentCoordinates.X.ToString() + " "
            + this.activeRover.CurrentCoordinates.Y.ToString() + " " + Converters.CompassDirectionToLetter(this.activeRover.CurrentDirection));
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

