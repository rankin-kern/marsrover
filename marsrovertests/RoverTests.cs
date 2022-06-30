using marsrover;
namespace marsrovertests;

public class MockValidatorBaseCase : IMovementValidator
{
    public virtual bool isSquareEmpty(Coordinates square)
    {
        return true;
    }

    public virtual bool isSquareOnGrid(Coordinates square)
    {
        return true;
    }
}

public class MockValidatorReturnOffGrid : MockValidatorBaseCase
{
    public override bool isSquareOnGrid(Coordinates square)
    {
        return false;
    }
}

public class MockValidatorReturnCollision : MockValidatorBaseCase
{
    public override bool isSquareEmpty(Coordinates square)
    {
        return false;
    }
}

public class RoverTests
{
    private IMovementValidator? testValidator;
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void assertRoverMovement()
    {
        testValidator = new MockValidatorBaseCase();
        Rover rover = new Rover(CompassDirection.East, new Coordinates(0, 0), testValidator);
        RoverCommand[] commands = new RoverCommand[]
        {
            RoverCommand.Move
        };
        rover.Commands = commands;
        rover.ProcessCommands();
        Assert.That(rover.CurrentCoordinates.X, Is.EqualTo(1));
        Assert.That(rover.CurrentCoordinates.Y, Is.EqualTo(0));

    }

    [Test]
    public void assertRoverDoesNotMoveOffBoard()
    {
        testValidator = new MockValidatorReturnOffGrid();
        Rover rover = new Rover(CompassDirection.East, new Coordinates(0, 0), testValidator);
        RoverCommand[] commands = new RoverCommand[]
        {
            RoverCommand.Move
        };
        rover.Commands = commands;
        rover.ProcessCommands();
        Assert.That(rover.CurrentCoordinates.X, Is.EqualTo(0));
        Assert.That(rover.CurrentCoordinates.Y, Is.EqualTo(0));

    }

    [Test]
    public void assertRoverDoesNotCollide()
    {
        testValidator = new MockValidatorReturnCollision();
        Rover rover = new Rover(CompassDirection.East, new Coordinates(0, 0), testValidator);
        RoverCommand[] commands = new RoverCommand[]
        {
            RoverCommand.Move
        };
        rover.Commands = commands;
        rover.ProcessCommands();
        Assert.That(rover.CurrentCoordinates.X, Is.EqualTo(0));
        Assert.That(rover.CurrentCoordinates.Y, Is.EqualTo(0));
    }

    [Test]
    public void roverFacingNorthTurnRight()
    {
        testValidator = new MockValidatorBaseCase();
        Rover rover = new Rover(CompassDirection.North, new Coordinates(0, 0), testValidator);
        RoverCommand[] commands = new RoverCommand[]
        {
            RoverCommand.Right
        };
        rover.Commands = commands;
        rover.ProcessCommands();
        Assert.That(rover.CurrentDirection, Is.EqualTo(CompassDirection.East));
    }

    [Test]
    public void roverFacingNorthTurnLeft()
    {
        testValidator = new MockValidatorBaseCase();
        Rover rover = new Rover(CompassDirection.North, new Coordinates(0, 0), testValidator);
        RoverCommand[] commands = new RoverCommand[]
        {
            RoverCommand.Left
        };
        rover.Commands = commands;
        rover.ProcessCommands();
        Assert.That(rover.CurrentDirection, Is.EqualTo(CompassDirection.West));
    }

    [Test]
    public void roverFacingEastTurnLeft()
    {
        testValidator = new MockValidatorBaseCase();
        Rover rover = new Rover(CompassDirection.East, new Coordinates(0, 0), testValidator);
        RoverCommand[] commands = new RoverCommand[]
        {
            RoverCommand.Left
        };
        rover.Commands = commands;
        rover.ProcessCommands();
        Assert.That(rover.CurrentDirection, Is.EqualTo(CompassDirection.North));

    }

    [Test]
    public void roverFacingEastTurnRight()
    {
        testValidator = new MockValidatorBaseCase();
        Rover rover = new Rover(CompassDirection.East, new Coordinates(0, 0), testValidator);
        RoverCommand[] commands = new RoverCommand[]
        {
            RoverCommand.Right
        };
        rover.Commands = commands;
        rover.ProcessCommands();
        Assert.That(rover.CurrentDirection, Is.EqualTo(CompassDirection.South));
    }

    [Test]
    public void roverFacingSouthTurnLeft()
    {
        testValidator = new MockValidatorBaseCase();
        Rover rover = new Rover(CompassDirection.South, new Coordinates(0, 0), testValidator);
        RoverCommand[] commands = new RoverCommand[]
        {
            RoverCommand.Left
        };
        rover.Commands = commands;
        rover.ProcessCommands();
        Assert.That(rover.CurrentDirection, Is.EqualTo(CompassDirection.East));
    }

    [Test]
    public void roverFacingSouthTurnRight()
    {
        testValidator = new MockValidatorBaseCase();
        Rover rover = new Rover(CompassDirection.South, new Coordinates(0, 0), testValidator);
        RoverCommand[] commands = new RoverCommand[]
        {
            RoverCommand.Right
        };
        rover.Commands = commands;
        rover.ProcessCommands();
        Assert.That(rover.CurrentDirection, Is.EqualTo(CompassDirection.West));
    }

    [Test]
    public void roverFacingWestTurnLeft()
    {
        testValidator = new MockValidatorBaseCase();
        Rover rover = new Rover(CompassDirection.West, new Coordinates(0, 0), testValidator);
        RoverCommand[] commands = new RoverCommand[]
        {
            RoverCommand.Left
        };
        rover.Commands = commands;
        rover.ProcessCommands();
        Assert.That(rover.CurrentDirection, Is.EqualTo(CompassDirection.South));
    }

    [Test]
    public void roverFacingWestTurnRight()
    {
        testValidator = new MockValidatorBaseCase();
        Rover rover = new Rover(CompassDirection.West, new Coordinates(0, 0), testValidator);

        RoverCommand[] commands = new RoverCommand[]
        {
            RoverCommand.Right
        };
        rover.Commands = commands;
        rover.ProcessCommands();
        Assert.That(rover.CurrentDirection, Is.EqualTo(CompassDirection.North));
    }
}


