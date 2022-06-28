using System;
namespace marsrover
{
    public enum CommandTypes
    {
        Exit,
        SetLocation,
        MoveAndRotate,
        SetGridSize
    }

    public struct Command
    {
        public CommandTypes type;
        public string commandInput;
    }

    

    // Responsible for parsing command line arguments into command abstractions
    public static class CommandParser
    {
        const int MAX_GRID_SIZE_INPUT = 3;
        const int MAX_STARTING_LOCATION_INPUT = 5;

        public static Command Parse(string inputCommand)
        {
            inputCommand = inputCommand.Trim().ToLower();
            Command command = new Command();
            command.commandInput = inputCommand;
            if (inputCommand == "q")
            {
                command.type = CommandTypes.Exit;
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

        private static bool isValidGridSizeCommand(string input)
        {
            if (input.Length != MAX_GRID_SIZE_INPUT)
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

