using marsrover.commands;

namespace marsrover
{
    public interface IRover
    {
        public Coordinates CurrentCoordinates { get; }
        public CompassDirection CurrentDirection { get; }
        public RoverCommand[] Commands { set; }


        public string ProcessCommands();
    }
}


