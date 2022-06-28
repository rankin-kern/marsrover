using System;
namespace marsrover;

public enum CommandTypes
{
    Exit,
    SetLocation,
    MoveAndRotate,
    SetGridSize
}

public struct Command
{
    public CommandTypes type;
    public string commandInput;
}
