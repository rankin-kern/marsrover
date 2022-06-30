namespace marsrover
{
    // Responsible for parsing command line arguments into command abstractions
    public static class CommandParser
    {
        const int GRID_SIZE_ARGS = 2;
        const int MAX_STARTING_LOCATION_INPUT = 5;

        public static Command ParseInput(string inputCommand)
        {
            inputCommand = inputCommand.Trim().ToLower();
            Command command = new Command();
            command.commandInput = inputCommand;
            if (inputCommand == "q")
            {
                command.type = CommandTypes.Exit;
            }
            else if (inputCommand == "r")
            {
                command.type = CommandTypes.Run;
            }
            else if (isValidGridSizeCommand(inputCommand)) {
                command.type = CommandTypes.SetGridSize;
            }
            else if (isValidLocationCommand(inputCommand))
            {
                command.type = CommandTypes.SetLocation;
            }
            else if (isValidMovementCommand(inputCommand))
            {
                command.type = CommandTypes.MoveAndRotate;
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }

            return command;
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

        public static StartCommand ParseStartCommand(string input)
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

        public static Coordinates ParseGridSizeCommand(string input)
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

            return true;
        }

        private static bool isValidLocationCommand(string input)
        {
            if (input.Length != MAX_STARTING_LOCATION_INPUT)
            {
                return false;
            }

            if (!Char.IsNumber(input[0]))
            {
                return false;
            }

            if (input[1] != ' ')
            {
                return false;
            }

            if (!Char.IsNumber(input[2]))
            {
                return false;
            }

            char[] validDirections = { 'n', 'e', 's', 'w' };
            if (Array.IndexOf(validDirections, input[4]) == -1)
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

