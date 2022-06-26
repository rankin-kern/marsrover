namespace marsrovertests;
using marsrover;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Test1()
    {
        Grid testGrid = new Grid(5, 5);
        Assert.AreEqual(5, testGrid.height);
        Assert.AreEqual(5, testGrid.width);
    }
}
