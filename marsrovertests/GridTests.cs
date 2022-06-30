namespace marsrovertests;
using marsrover;

public class GridTests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void assertStartingLocation()
    {
        Grid testGrid = new Grid(5, 5);
        StartCommand start = new StartCommand
        {
            startCoordinates = { X = 0, Y = 0 },
            startDirection = CompassDirection.North
        };

        testGrid.addRover(start);
        Assert.That(testGrid.activeRover, Is.Not.Null);
        Assert.That(testGrid.activeRover.CurrentCoordinates, Is.EqualTo(new Coordinates(0, 0)));
        Assert.That(testGrid.activeRover.CurrentDirection, Is.EqualTo(CompassDirection.North));
    }

    [Test]
    public void assertProcessInstructionValid()
    {
        Grid testGrid = new Grid(5, 5);
        StartCommand start = new StartCommand
        {
            startCoordinates = { X = 1, Y = 2 },
            startDirection = CompassDirection.North
        };

        testGrid.addRover(start);
        RoverCommand[] command1 = {
            RoverCommand.Left,
            RoverCommand.Move,
            RoverCommand.Left,
            RoverCommand.Move,
            RoverCommand.Left,
            RoverCommand.Move,
            RoverCommand.Left,
            RoverCommand.Move,
            RoverCommand.Move
        };
        Assert.IsNotNull(testGrid.activeRover);

        testGrid.activeRover.Commands = command1;

        start = new StartCommand
        {
            startCoordinates = { X = 3, Y = 3 },
            startDirection = CompassDirection.East
        };

        testGrid.addRover(start);

        RoverCommand[] command2 = {
            RoverCommand.Move,
            RoverCommand.Move,
            RoverCommand.Right,
            RoverCommand.Move,
            RoverCommand.Move,
            RoverCommand.Right,
            RoverCommand.Move,
            RoverCommand.Right,
            RoverCommand.Right,
            RoverCommand.Move
        };

        testGrid.activeRover.Commands = command2;
        string result = testGrid.moveRovers();
        Assert.That(result, Is.EqualTo("1 3 N" + Environment.NewLine + "5 1 E" + Environment.NewLine));
    }

    [Test]
    public void assertRoverGridEdge()
    {
        Grid testGrid = new Grid(8, 8);
        StartCommand start = new StartCommand
        {
            startCoordinates = { X = 7, Y = 7 },
            startDirection = CompassDirection.East
        };

        testGrid.addRover(start);

        RoverCommand[] move1 =
        {
            RoverCommand.Move
        };

        Assert.IsNotNull(testGrid.activeRover);
        testGrid.activeRover.Commands = move1;
        string result = testGrid.moveRovers();
        Assert.That(result, Is.EqualTo("8 7 E" + Environment.NewLine));

        testGrid.activeRover.Commands = move1;
        result = testGrid.moveRovers();
        Assert.That(result, Is.EqualTo("8 7 E" + Environment.NewLine));

        RoverCommand[] move2 =
        {
            RoverCommand.Left,
            RoverCommand.Move
        };

        testGrid.activeRover.Commands = move2;
        result = testGrid.moveRovers();
        Assert.That(result, Is.EqualTo("8 8 N" + Environment.NewLine));

        testGrid.activeRover.Commands = move2;
        testGrid.moveRovers();
        Assert.That(result, Is.EqualTo("8 8 N" + Environment.NewLine));
    }

    [Test]
    public void assertRoversCantCollide()
    {
        Grid testGrid = new Grid(5, 5);
        StartCommand start = new StartCommand
        {
            startCoordinates = { X = 0, Y = 0 },
            startDirection = CompassDirection.North
        };

        testGrid.addRover(start);
        RoverCommand[] move =
        {
            RoverCommand.Right,
            RoverCommand.Move
        };
        Assert.IsNotNull(testGrid.activeRover);

        testGrid.activeRover.Commands = move;

        start = new StartCommand
        {
            startCoordinates = { X = 1, Y = 1 },
            startDirection = CompassDirection.East
        };
        testGrid.addRover(start);

        testGrid.activeRover.Commands = move;

        string result = testGrid.moveRovers();
        Assert.That(result, Is.EqualTo("1 0 E" + Environment.NewLine + "1 1 S" + Environment.NewLine));
    }
}
