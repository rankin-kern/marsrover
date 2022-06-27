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
        testGrid.handleStartingLocationCommand("0 0 N");
        Assert.AreEqual(testGrid.activeRover.currentCoordinates, new Coordinates(0, 0));
        Assert.AreEqual(testGrid.activeRover.currentDirection, CompassDirection.North);
    }

    [Test]
    public void assertProcessInstructionValid()
    {
        Grid testGrid = new Grid(5, 5);
        testGrid.handleStartingLocationCommand("1 2 N");
        string result = testGrid.handleMoveCommand("LMLMLMLMM");
        Assert.AreEqual("1 3 N", result);
        testGrid.handleStartingLocationCommand("3 3 E");
        result = testGrid.handleMoveCommand("MMRMMRMRRM");
        Assert.AreEqual("5 1 E", result);
    }

    [Test]
    public void assertRoverGridEdge()
    {
        Grid testGrid = new Grid(8, 8);
        testGrid.handleStartingLocationCommand("7 7 E");
        string result = testGrid.handleMoveCommand("M");
        Assert.AreEqual("8 7 E", result);
        result = testGrid.handleMoveCommand("M");
        Assert.AreEqual("8 7 E", result);
        result = testGrid.handleMoveCommand("LM");
        Assert.AreEqual("8 8 N", result);
        testGrid.handleMoveCommand("M");
        Assert.AreEqual("8 8 N", result);
    }

    [Test]
    public void assertRoversCantCollide()
    {
        Grid testGrid = new Grid(5, 5);
        testGrid.handleStartingLocationCommand("0 0 N");
        string result = testGrid.handleMoveCommand("RM");
        Assert.AreEqual("1 0 E", result);
        testGrid.handleStartingLocationCommand("1 1 E");
        result = testGrid.handleMoveCommand("RM");
        Assert.AreEqual("1 1 S", result);
        

    }
}
