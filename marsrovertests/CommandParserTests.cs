using marsrover;
namespace marsrovertests
{
    public class CommandParserTests
    {
        [Test]
        public void assertInputStringToCommand()
        {
            string testInput = "Q";
            IGridCommand command = CommandParser.ParseInput(testInput);
            Assert.That(command.GetType(), Is.EqualTo(typeof(ExitCommand)));

            testInput = "6 4";
            command = CommandParser.ParseInput(testInput);
            Assert.That(command.GetType(), Is.EqualTo(typeof(GridSizeCommand)));

            testInput = "3 3 S";
            command = CommandParser.ParseInput(testInput);
            Assert.That(command.GetType(), Is.EqualTo(typeof(AddRoverCommand)));

            testInput = "LMRLMMMR";
            command = CommandParser.ParseInput(testInput);
            Assert.That(command.GetType(), Is.EqualTo(typeof(InstructRoverCommand)));
        }

        [Test]
        public void assertInvalidInputThrowsException()
        {
            string badInput = "X";
            try
            {
                CommandParser.ParseInput(badInput);
            } catch (Exception e)
            {
                Assert.IsInstanceOf(typeof(ArgumentException), e);
                Assert.That(e.Message, Is.EqualTo("Invalid command"));
            }
        }


        [Test]
        public void assertValidRoverMovement()
        {
            string input = "LMRLL";
            RoverCommand[] command = CommandParser.ParseRoverCommand(input);
           
            Assert.Multiple(() =>
            {
                Assert.That(command.Length, Is.EqualTo(5));
                Assert.That(command[0], Is.EqualTo(RoverCommand.Left));
                Assert.That(command[1], Is.EqualTo(RoverCommand.Move));
                Assert.That(command[2], Is.EqualTo(RoverCommand.Right));
                Assert.That(command[3], Is.EqualTo(RoverCommand.Left));
                Assert.That(command[4], Is.EqualTo(RoverCommand.Left));
            });
        }
    }
}

