// See https://aka.ms/new-console-template for more information
using marsrover;
using marsrover.commands;

Console.WriteLine("Welcome to Mars Rover. Enter 'q' to quit");
Console.WriteLine("Enter grid size (e.g 5 5)");
Grid grid = new Grid();
IGridCommand command;
string? input;

while ((input = Console.ReadLine()) != null)
{
    try
    {
        command = CommandParser.ParseInput(input);
        Console.WriteLine(command.Execute(grid));
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}


