namespace Rover.Cli
{
    public class RoverPositioning
    {
        public RoverPositioning(int x, int y, string orientation)
        {
            XCoordinate = x;
            YCoordinate = y;
            Orientation = orientation;
        }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Orientation { get; set; }
    }
}
