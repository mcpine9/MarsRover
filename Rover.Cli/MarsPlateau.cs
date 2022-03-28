namespace Rover.Cli
{
    public class MarsPlateau : IPlateau
    {
        public MarsPlateau(int xCoordinate, int yCoordinate)
        {
            UpperRightCoordinates = new Dictionary<string, int>()
            {
                { "x", xCoordinate },
                { "y", yCoordinate }
            };
        }
        public Dictionary<string, int> BaseCoordinates =>
            new()
            {
                { "x", 0 },
                { "y", 0 }
            };

        public Dictionary<string, int> UpperRightCoordinates { get; }

        public bool IsCoordinatesWithinPlateauPlane(int x = 0, int y = 0)
        {
            if (x > BaseCoordinates["x"] && x < UpperRightCoordinates["x"] &&
                y > BaseCoordinates["y"] && y < UpperRightCoordinates["y"])
                return true;

            return false;
        }
    }
}
