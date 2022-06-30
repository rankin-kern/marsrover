using marsrover;
using marsrover.commands;

namespace marsrovertests
{
    public class GridTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void assertStartingLocation()
        {
            Grid testGrid = new Grid();
            testGrid.Bounds = new Coordinates { X = 5, Y = 5 };
            StartCommand start = new StartCommand
            {
                startCoordinates = { X = 0, Y = 0 },
                startDirection = CompassDirection.North
            };

            testGrid.AddRover(start);
            IRover rover = testGrid.Rovers[0];
            Assert.That(rover.CurrentCoordinates, Is.EqualTo(new Coordinates(0, 0)));
            Assert.That(rover.CurrentDirection, Is.EqualTo(CompassDirection.North));
        }

        [Test]
        public void assertProcessInstructionValid()
        {
            Grid testGrid = new Grid();
            testGrid.Bounds = new Coordinates { X = 5, Y = 5 };
            StartCommand start = new StartCommand
            {
                startCoordinates = { X = 1, Y = 2 },
                startDirection = CompassDirection.North
            };

            testGrid.AddRover(start);
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
            testGrid.SetRoverCommands(command1);

            start = new StartCommand
            {
                startCoordinates = { X = 3, Y = 3 },
                startDirection = CompassDirection.East
            };

            testGrid.AddRover(start);

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

            testGrid.SetRoverCommands(command2);
            string result = testGrid.MoveRovers();
            Assert.That(result, Is.EqualTo("1 3 N" + Environment.NewLine + "5 1 E" + Environment.NewLine));
        }

        [Test]
        public void assertRoverGridEdge()
        {
            Grid testGrid = new Grid();
            testGrid.Bounds = new Coordinates { X = 8, Y = 8 };
            StartCommand start = new StartCommand
            {
                startCoordinates = { X = 7, Y = 7 },
                startDirection = CompassDirection.East
            };

            testGrid.AddRover(start);

            RoverCommand[] move1 =
            {
                RoverCommand.Move
            };

            testGrid.SetRoverCommands(move1);
            string result = testGrid.MoveRovers();
            Assert.That(result, Is.EqualTo("8 7 E" + Environment.NewLine));

            testGrid.SetRoverCommands(move1);
            result = testGrid.MoveRovers();
            Assert.That(result, Is.EqualTo("8 7 E" + Environment.NewLine));

            RoverCommand[] move2 =
            {
                RoverCommand.Left,
                RoverCommand.Move
            };

            testGrid.SetRoverCommands(move2);
            result = testGrid.MoveRovers();
            Assert.That(result, Is.EqualTo("8 8 N" + Environment.NewLine));

            testGrid.SetRoverCommands(move2);
            testGrid.MoveRovers();
            Assert.That(result, Is.EqualTo("8 8 N" + Environment.NewLine));
        }

        [Test]
        public void assertRoversCantCollide()
        {
            Grid testGrid = new Grid();
            testGrid.Bounds = new Coordinates { X = 5, Y = 5 };
            StartCommand start = new StartCommand
            {
                startCoordinates = { X = 0, Y = 0 },
                startDirection = CompassDirection.North
            };

            testGrid.AddRover(start);
            RoverCommand[] move =
            {
                RoverCommand.Right,
                RoverCommand.Move
            };
            testGrid.SetRoverCommands(move);

            start = new StartCommand
            {
                startCoordinates = { X = 1, Y = 1 },
                startDirection = CompassDirection.East
            };
            testGrid.AddRover(start);

            testGrid.SetRoverCommands(move);

            string result = testGrid.MoveRovers();
            Assert.That(result, Is.EqualTo("1 0 E" + Environment.NewLine + "1 1 S" + Environment.NewLine));
        }

        [Test]
        public void assertRoverCantBePlacedOffGrid()
        {
            Grid testGrid = new Grid();
            testGrid.Bounds = new Coordinates { X = 10, Y = 10 };
            StartCommand start = new StartCommand
            {
                startCoordinates = { X = 11, Y = 9 },
                startDirection = CompassDirection.North
            };
            try
            {
                testGrid.AddRover(start);
            } catch (Exception e)
            {
                Assert.That(e.GetType(), Is.EqualTo(typeof(InvalidOperationException)));
                Assert.That(e.Message, Is.EqualTo("Start location invalid"));
            }
        }

        [Test]
        public void assertRoverCanBePlacedInCorner()
        {
            Grid testGrid = new Grid();
            testGrid.Bounds = new Coordinates { X = 10, Y = 10 };
            StartCommand start = new StartCommand
            {
                startCoordinates = { X = 10, Y = 10 },
                startDirection = CompassDirection.North
            };
            testGrid.AddRover(start);
            Assert.That(testGrid.Rovers[0].CurrentCoordinates.X, Is.EqualTo(10));
            Assert.That(testGrid.Rovers[0].CurrentCoordinates.Y, Is.EqualTo(10));
        }
    }
}

