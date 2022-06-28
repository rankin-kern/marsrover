namespace marsrover
{
    public static class Converters
    {
        public static CompassDirection LetterToCompassDirection(string direction) => direction.ToLower() switch
        {
            "n" => CompassDirection.North,
            "e" => CompassDirection.East,
            "s" => CompassDirection.South,
            "w" => CompassDirection.West,
            _ => throw new ArgumentOutOfRangeException(direction, "Not a valid direction string"),
        };

        public static string CompassDirectionToLetter(CompassDirection direction) => direction switch
        {
            CompassDirection.North => "N",
            CompassDirection.East => "E",
            CompassDirection.South => "S",
            CompassDirection.West => "W",
            _ => throw new ArgumentOutOfRangeException("Not a valid direction"),
        };

        public static Direction LetterToDirection(string letter) => letter.ToLower() switch
        {
            "l" => Direction.Left,
            "r" => Direction.Right,
            _ => throw new ArgumentOutOfRangeException(letter, "Not a valid direction"),
        };
    }
}

