using marsrover.commands;
namespace marsrover
{
    public interface IPlateau
    {
        public Coordinates Bounds { get; set; }
        public List<IRover> Rovers { get; }

        // Set the initial position of a rover
        public void AddRover(StartCommand start);

        public void SetRoverCommands(RoverCommand[] commands);

        public string MoveRovers();
    }
}

