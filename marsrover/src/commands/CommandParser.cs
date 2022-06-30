namespace marsrover.commands
{
    // Responsible for parsing command line arguments into command abstractions
    public static class CommandParser
    {
        const int MAX_GRID_HEIGHT = 999;
        const int MAX_GRID_WIDTH = 999;
        const int GRID_SIZE_ARGS = 2;
        const int START_ARGS = 3;

        public static IGridCommand ParseInput(string inputCommand)
        {
            inputCommand = inputCommand.Trim().ToLower();
            IGridCommand? gridCommand = null;

            if (inputCommand == "q")
            {
                gridCommand = new ExitCommand();
            }
            else if (inputCommand == "r")
            {
                gridCommand = new MoveRoversCommand();
            }
            else if (isValidGridSizeCommand(inputCommand)) {
                gridCommand = new GridSizeCommand(ParseGridSizeCommand(inputCommand));
            }
            else if (isValidStartCommand(inputCommand))
            {
                gridCommand = new AddRoverCommand(ParseStartCommand(inputCommand));
                
            }
            else if (isValidMovementCommand(inputCommand))
            {
                gridCommand = new InstructRoverCommand(ParseRoverCommand(inputCommand));
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }

            return gridCommand;
        }

        public static RoverCommand[] ParseRoverCommand(string input)
        {
            input = input.Trim().ToLower();

            RoverCommand[] commands = new RoverCommand[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'l')
                {
                    commands[i] = RoverCommand.Left;
                } else if (input[i] == 'r') {
                    commands[i] = RoverCommand.Right;
                } else if (input[i] == 'm')
                {
                    commands[i] = RoverCommand.Move;
                }
            }

            return commands;

        }

        private static StartCommand ParseStartCommand(string input)
        {
            input = input.Trim().ToLower();
            string[] parts = input.Split(' ');
            int x = Int32.Parse(parts[0]);
            int y = Int32.Parse(parts[1]);
            Coordinates start = new Coordinates(x, y);
            CompassDirection direction = Converters.LetterToCompassDirection(parts[2]);

            return new StartCommand
            {
                startCoordinates = start,
                startDirection = direction
            };
        }

        private static Coordinates ParseGridSizeCommand(string input)
        {
            string[] parts = input.Split(' ');
            int x = Int32.Parse(parts[0]);
            int y = Int32.Parse(parts[1]);
            return new Coordinates
            {
                X = x,
                Y = y
            };
        }

        private static bool isValidGridSizeCommand(string input)
        {
            string[] parts = input.Split(' ');
            if (parts.Length != GRID_SIZE_ARGS)
            {
                return false;
            }

            int x;
            if (!Int32.TryParse(parts[0], out x))
            {
                return false;
            }

            int y;
            if (!Int32.TryParse(parts[1], out y))
            {
                return false;
            }

            if (x <= 0 || y <= 0) {
                return false;
            }

            if (x > MAX_GRID_WIDTH || y > MAX_GRID_HEIGHT)
            {
                return false;
            }

            return true;
        }

        private static bool isValidStartCommand(string input)
        {
            string[] parts = input.Split(' ');

            if (parts.Length != START_ARGS)
            {
                return false;
            }

            if (!Int32.TryParse(parts[0], out int x))
            {
                return false;
            }

            if (!Int32.TryParse(parts[1], out int y))
            {
                return false;
            }

            string[] validDirections = { "n", "e", "s", "w" };
            if (Array.IndexOf(validDirections, parts[2]) == -1)
            {
                return false;
            }

            return true;
        }

        private static bool isValidMovementCommand(string input)
        {
            char[] validInputs = { 'l', 'r', 'm' };
            foreach (char c in input)
            {
                if (Array.IndexOf(validInputs, c) == -1)
                {
                    return false;
                }
            }

            return true;
        }
        
    }

}

