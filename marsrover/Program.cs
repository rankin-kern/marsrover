// See https://aka.ms/new-console-template for more information
using marsrover;

Console.WriteLine("Enter grid size (e.g 5 5)");
string? command = Console.ReadLine();
Grid grid;
// process grid size command. todo: error handling
if (command != null)
{
    int width = Int32.Parse(command[0].ToString());
    int height = Int32.Parse(command[2].ToString());
    
    grid = new Grid(width, height);

    while ((command = Console.ReadLine()) != null)
    {
        // todo: add better validation
        if (Char.IsNumber(command[0])) {
            grid.setStartingLocation(command);
        }

        if (command.StartsWith('L') || command.StartsWith('R') || command.StartsWith('M'))
        {
            grid.processInstruction(command);
        }
    }
}

