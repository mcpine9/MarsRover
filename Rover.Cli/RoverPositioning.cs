namespace Rover.Cli
{
    public class RoverPositioning
    {
        public readonly string[] orientationConstraints = new string[4] { "N", "W", "S", "E" };
        protected IPlateau Plateau { get; set; }

        public RoverPositioning(int x, int y, string orientation)
        {
            XCoordinate = x;
            YCoordinate = y;
            Orientation = orientation;
        }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Orientation { get; set; }


        public void Move(List<PositioningSeriesType> seriesOfMoves)
        {
            int currentOrientation = Array.IndexOf(orientationConstraints, Orientation);
            foreach (var move in seriesOfMoves)
            {
                switch (move)
                {
                    case PositioningSeriesType.M:
                        switch (Orientation)
                        {
                            case "N":
                                YCoordinate++;
                                break;
                            case "S":
                                YCoordinate--;
                                break;
                            case "W":
                                XCoordinate++;
                                break;
                            case "E":
                                XCoordinate--;
                                break;
                            default:
                                break;
                        }
                        break;
                    case PositioningSeriesType.L:
                        if (currentOrientation == 0)
                        {
                            currentOrientation = 4;
                        }
                        currentOrientation--;
                        break;
                    case PositioningSeriesType.R:
                        if (currentOrientation == orientationConstraints.Length)
                        {
                            currentOrientation = 0;
                        }
                        currentOrientation++;
                        break;

                }
            }

            if (!Plateau.IsCoordinatesWithinPlateauPlane(XCoordinate, YCoordinate))
            {
                throw new FallOffPlateauException("Error! The plateau doesn't reach that far!");
            }
        }
    }
}
