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
        Coordinates result = rover.Move();
        Assert.AreEqual(1, result.X);
        Assert.AreEqual(0, result.Y);

    }

    [Test]
    public void assertRoverDoesNotMoveOffBoard()
    {
        testValidator = new MockValidatorReturnOffGrid();
        Rover rover = new Rover(CompassDirection.East, new Coordinates(0, 0), testValidator);
        Coordinates result = rover.Move();
        Assert.AreEqual(0, result.X);
        Assert.AreEqual(0, result.Y);

    }

    [Test]
    public void assertRoverDoesNotCollide()
    {
        testValidator = new MockValidatorReturnCollision();
        Rover rover = new Rover(CompassDirection.East, new Coordinates(0, 0), testValidator);
        Coordinates result = rover.Move();
        Assert.AreEqual(0, result.X);
        Assert.AreEqual(0, result.Y);

    }

    [Test]
    public void roverFacingNorthTurnRight()
    {
        Rover rover = new Rover(CompassDirection.North, new Coordinates(0, 0), testValidator);
        CompassDirection result = rover.Rotate(RoverCommand.Right);
        Assert.AreEqual(result, CompassDirection.East);
    }

    [Test]
    public void roverFacingNorthTurnLeft()
    {
        Rover rover = new Rover(CompassDirection.North, new Coordinates(0, 0), testValidator);
        CompassDirection result = rover.Rotate(RoverCommand.Left);
        Assert.AreEqual(result, CompassDirection.West);
    }

    [Test]
    public void roverFacingEastTurnLeft()
    {
        Rover rover = new Rover(CompassDirection.East, new Coordinates(0, 0), testValidator);
        CompassDirection result = rover.Rotate(RoverCommand.Left);
        Assert.AreEqual(result, CompassDirection.North);

    }

    [Test]
    public void roverFacingEastTurnRight()
    {
        Rover rover = new Rover(CompassDirection.East, new Coordinates(0, 0), testValidator);
        CompassDirection result = rover.Rotate(RoverCommand.Right);
        Assert.AreEqual(result, CompassDirection.South);
    }

    [Test]
    public void roverFacingSouthTurnLeft()
    {
        Rover rover = new Rover(CompassDirection.South, new Coordinates(0, 0), testValidator);
        CompassDirection result = rover.Rotate(RoverCommand.Left);
        Assert.AreEqual(result, CompassDirection.East);
    }

    [Test]
    public void roverFacingSouthTurnRight()
    {
        Rover rover = new Rover(CompassDirection.South, new Coordinates(0, 0), testValidator);
        CompassDirection result = rover.Rotate(RoverCommand.Right);
        Assert.AreEqual(result, CompassDirection.West);
    }

    [Test]
    public void roverFacingWestTurnLeft()
    {
        Rover rover = new Rover(CompassDirection.West, new Coordinates(0, 0), testValidator);
        CompassDirection result = rover.Rotate(RoverCommand.Left);
        Assert.AreEqual(result, CompassDirection.South);
    }

    [Test]
    public void roverFacingWestTurnRight()
    {
        Rover rover = new Rover(CompassDirection.West, new Coordinates(0, 0), testValidator);
        CompassDirection result = rover.Rotate(RoverCommand.Right);
        Assert.AreEqual(result, CompassDirection.North);
    }
}


