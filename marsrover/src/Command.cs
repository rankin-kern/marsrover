namespace marsrover
{
    public enum CommandTypes
    {
        Exit,
        SetLocation,
        MoveAndRotate,
        SetGridSize,
        Run
    }

    public struct Command
    {
        public CommandTypes type;
        public string commandInput;
    }
}
