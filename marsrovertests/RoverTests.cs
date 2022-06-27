using marsrover;
namespace marsrovertests;

public class RoverTests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void assertRoverMovement()
    {
        Rover rover = new Rover(CompassDirection.East, new Coordinates(0, 0));
        Coordinates result = rover.CalculateMove();
        Assert.AreEqual(1, result.X);
        Assert.AreEqual(0, result.Y);

    }

    [Test]
    public void roverFacingNorthTurnRight()
    {
        Rover rover = new Rover(CompassDirection.North, new Coordinates(0, 0));
        CompassDirection result = rover.Rotate(Direction.Right);
        Assert.AreEqual(result, CompassDirection.East);
    }

    [Test]
    public void roverFacingNorthTurnLeft()
    {
        Rover rover = new Rover(CompassDirection.North, new Coordinates(0, 0));
        CompassDirection result = rover.Rotate(Direction.Left);
        Assert.AreEqual(result, CompassDirection.West);
    }

    [Test]
    public void roverFacingEastTurnLeft()
    {
        Rover rover = new Rover(CompassDirection.East, new Coordinates(0, 0));
        CompassDirection result = rover.Rotate(Direction.Left);
        Assert.AreEqual(result, CompassDirection.North);

    }

    [Test]
    public void roverFacingEastTurnRight()
    {
        Rover rover = new Rover(CompassDirection.East, new Coordinates(0, 0));
        CompassDirection result = rover.Rotate(Direction.Right);
        Assert.AreEqual(result, CompassDirection.South);
    }

    [Test]
    public void roverFacingSouthTurnLeft()
    {
        Rover rover = new Rover(CompassDirection.South, new Coordinates(0, 0));
        CompassDirection result = rover.Rotate(Direction.Left);
        Assert.AreEqual(result, CompassDirection.East);
    }

    [Test]
    public void roverFacingSouthTurnRight()
    {
        Rover rover = new Rover(CompassDirection.South, new Coordinates(0, 0));
        CompassDirection result = rover.Rotate(Direction.Right);
        Assert.AreEqual(result, CompassDirection.West);
    }

    [Test]
    public void roverFacingWestTurnLeft()
    {
        Rover rover = new Rover(CompassDirection.West, new Coordinates(0, 0));
        CompassDirection result = rover.Rotate(Direction.Left);
        Assert.AreEqual(result, CompassDirection.South);
    }

    [Test]
    public void roverFacingWestTurnRight()
    {
        Rover rover = new Rover(CompassDirection.West, new Coordinates(0, 0));
        CompassDirection result = rover.Rotate(Direction.Right);
        Assert.AreEqual(result, CompassDirection.North);
    }
}


