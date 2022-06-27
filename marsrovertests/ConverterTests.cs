using marsrover;
namespace marsrovertests;

public class ConverterTests
{
    [Test]
    public void assertLetterToCompassDirection()
    {
        Assert.AreEqual(CompassDirection.East, Converters.LetterToCompassDirection("E"));
        Assert.AreEqual(CompassDirection.North, Converters.LetterToCompassDirection("N"));
        Assert.AreEqual(CompassDirection.South, Converters.LetterToCompassDirection("S"));
        Assert.AreEqual(CompassDirection.West, Converters.LetterToCompassDirection("W"));

    }

    [Test]
    public void assertCompassDirectionToLetter()
    {
        Assert.AreEqual("N", Converters.CompassDirectionToLetter(CompassDirection.North));
        Assert.AreEqual("E", Converters.CompassDirectionToLetter(CompassDirection.East));
        Assert.AreEqual("S", Converters.CompassDirectionToLetter(CompassDirection.South));
        Assert.AreEqual("W", Converters.CompassDirectionToLetter(CompassDirection.West));
    }
}

