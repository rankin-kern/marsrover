// See https://aka.ms/new-console-template for more information
using marsrover;


Console.WriteLine("Welcome to Mars Rover. Enter 'q' to quit");
Console.WriteLine("Enter grid size (e.g 5 5)");
Grid? grid = null;
Command command;
string? input;

while ((input = Console.ReadLine()) != null)
{
    try
    {
        command = CommandParser.ParseInput(input);

        if (command.type == CommandTypes.SetGridSize)
        {
            Coordinates neCorner = CommandParser.ParseGridSizeCommand(command.commandInput);

            grid = new Grid(neCorner.X, neCorner.Y);

            Console.WriteLine("Enter starting location");
        }

        if (command.type == CommandTypes.Exit)
        {
            Environment.Exit(0);
        }

        if (command.type == CommandTypes.SetLocation)
        {
            if (grid == null)
            {
                Console.WriteLine("Plateau size must be input first");
                continue;
            }

            StartCommand start = CommandParser.ParseStartCommand(command.commandInput);
            grid.addRover(start);
            Console.WriteLine("Enter rover instructions");
        }

        if (command.type == CommandTypes.MoveAndRotate)
        {
            if (grid == null)
            {
                Console.WriteLine("Plateau size must be input first");
                continue;
            }

            if (grid.activeRover == null)
            {
                Console.WriteLine("Rover position must be input first");
                continue;
            }

            RoverCommand[] commands = CommandParser.ParseRoverCommand(command.commandInput);
            grid.activeRover.Commands = commands;
            
            Console.WriteLine("Enter starting location of next rover, or 'r' to run commands");
        }

        if (command.type == CommandTypes.Run)
        {
            if (grid == null)
            {
                Console.WriteLine("Plateau and rovers must be input first");
                continue;
            }

            Console.Write(grid.moveRovers());
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}


