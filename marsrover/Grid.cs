// A class that defines an x,y coordinate based grid
// divided into squares.

using System;
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
        public int width { get; }
        public int height { get; }
        public Rover? activeRover { get; set; }

        // int cornerX: the X-coordinate of the top right square
        // int cornerY: the Y-coordinate of the top right square
        public Grid(int cornerX, int cornerY)
        {
            width = cornerX;
            height = cornerY;
            //grid = new Square[width, height];
        }

        // Given a string like '1 2 N', update the corresponding Square in the Grid
        // to have a rover on it
        public void setStartingLocation(string start)
        {
            // TODO make parsing more robust
            try
            {
                string[] parts = start.Split(' ');
                int x = Int32.Parse(parts[0]);
                int y = Int32.Parse(parts[1]);
                if (x >= 0 && x <= this.width && y >= 0 && y <= height)
                {
                    CompassDirection direction = ConvertLetterToCompassDirection(parts[2]);
                    activeRover = new Rover(direction);
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        // Process an instruction like "LMLMRM"
        public void processInstruction(string instruction)
        {
            // If this is somehow called when we don't have an active rover yet,
            // return early
            if (this.activeRover == null) {
                return;
            }

            foreach (char c in instruction) {
                if (c == 'M')
                {
                    // todo
                    // processMovement
                }
                else if (c == 'L' || c == 'R')
                {
                    Direction turnDirection = ConvertLetterToDirection(c.ToString());
                    CompassDirection newDirection = this.activeRover.Rotate(turnDirection);
                }
            }
        }

        // todo move this elsewhere
        private static CompassDirection ConvertLetterToCompassDirection(string direction) => direction switch
        {
            "N" => CompassDirection.North,
            "E" => CompassDirection.East,
            "S" => CompassDirection.South,
            "W" => CompassDirection.West,
            _ => throw new ArgumentOutOfRangeException(direction, "Not a valid direction string"),
        };

        private static Direction ConvertLetterToDirection(string letter) => letter switch
        {
            "L" => Direction.Left,
            "R" => Direction.Right,
            _ => throw new ArgumentOutOfRangeException(letter, "Not a valid direction"),
        };

        // Moves the rover one square in its curent direction.
        // If that would move the rover off the grid, do nothing.
        // Return the new coordinates of the rover.
        private Coordinates moveRover()
        {
            if (this.activeRover == null)
            {
                throw new NullReferenceException(message: "Attempted to move before setting rover location");
            }

            Coordinates currentCoords = this.activeRover.currentCoordinates;
            Coordinates newCoords = currentCoords;
            if (this.activeRover.currentDirection == CompassDirection.North)
            {
                newCoords.Y = currentCoords.Y + 1;
                // Check that we are still on the grid.
                if (newCoords.Y < this.height)
                {
                    return newCoords;
                }
                else
                {
                    return currentCoords;
                }
            }
            else if (this.activeRover.currentDirection == CompassDirection.East)
            {
                newCoords.X = currentCoords.X + 1;
                // Check that we are still on the grid
                if (newCoords.X < this.width)
                {
                    return newCoords;
                }
            }

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

