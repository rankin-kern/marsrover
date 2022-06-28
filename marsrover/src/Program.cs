// See https://aka.ms/new-console-template for more information
using marsrover;

Console.WriteLine("Welcome to Mars Rover. Enter 'q' to quit");
Console.WriteLine("Enter grid size (e.g 5 5)");
Grid? grid = null;
Command command;
string? input;

    

Console.WriteLine("Enter starting location");

while ((input = Console.ReadLine()) != null)
{
    try
    {
        command = CommandParser.Parse(input);

        if (command.type == CommandTypes.SetGridSize)
        {
            int width = Int32.Parse(command.commandInput[0].ToString());
            int height = Int32.Parse(command.commandInput[2].ToString());

            grid = new Grid(width, height);

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

            grid.handleStartingLocationCommand(command.commandInput);
            Console.WriteLine("Enter rover instructions");
        }

        if (command.type == CommandTypes.MoveAndRotate)
        {
            if (grid == null)
            {
                Console.WriteLine("Plateau size must be input first");
                continue;
            }

            // TODO: ensure rover position set first?

            Console.WriteLine(grid.handleMoveCommand(command.commandInput));
            Console.WriteLine("Enter starting location");
        }
    }
    catch (ArgumentException)
    {
        Console.WriteLine("Invalid command");
    }
}


