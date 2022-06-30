using marsrover;
namespace marsrovertests
{
    public class ConverterTests
    {
        [Test]
        public void assertLetterToCompassDirection()
        {
            Assert.That(Converters.LetterToCompassDirection("E"), Is.EqualTo(CompassDirection.East));
            Assert.That(Converters.LetterToCompassDirection("N"), Is.EqualTo(CompassDirection.North));
            Assert.That(Converters.LetterToCompassDirection("S"), Is.EqualTo(CompassDirection.South));
            Assert.That(Converters.LetterToCompassDirection("W"), Is.EqualTo(CompassDirection.West));

        }

        [Test]
        public void assertCompassDirectionToLetter()
        {
            Assert.That(Converters.CompassDirectionToLetter(CompassDirection.North), Is.EqualTo("N"));
            Assert.That(Converters.CompassDirectionToLetter(CompassDirection.East), Is.EqualTo("E"));
            Assert.That(Converters.CompassDirectionToLetter(CompassDirection.South), Is.EqualTo("S"));
            Assert.That(Converters.CompassDirectionToLetter(CompassDirection.West), Is.EqualTo("W"));
        }
    }
}

