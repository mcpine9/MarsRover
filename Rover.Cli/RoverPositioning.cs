namespace Rover.Cli
{
    public class RoverPositioning
    {
        public readonly string[] orientationConstraints = new string[4] { "N", "W", "S", "E" };
        protected IPlateau Plateau { get; set; }

        public RoverPositioning(IPlateau plateau, int x, int y, string orientation)
        {
            Plateau = plateau;
            XCoordinate = x;
            YCoordinate = y;
            Orientation = orientation;
        }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Orientation { get; set; }


        public void Move(char[] seriesOfMoves)
        {
            int currentOrientation = Array.IndexOf(orientationConstraints, Orientation);
            foreach (var move in seriesOfMoves)
            {
                switch (move.ToString().ToUpper())
                {
                    case "M":
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
                    case "L":
                        if (currentOrientation == 0)
                        {
                            currentOrientation = orientationConstraints.Length - 1;
                        }
                        else
                        {
                            currentOrientation--;
                        }
                        break;
                    case "R":
                        if (currentOrientation == orientationConstraints.Length - 1)
                        {
                            currentOrientation = 0;
                        }
                        else
                        {
                            currentOrientation++;
                        }
                        break;

                }

                Orientation = orientationConstraints[currentOrientation];
            }

            Console.WriteLine($"{XCoordinate} {YCoordinate} {Orientation}");

            if (!Plateau.IsCoordinatesWithinPlateauPlane(XCoordinate, YCoordinate))
            {
                throw new FallOffPlateauException("Error! The plateau doesn't reach that far! You fell off. :-(");
            }
        }
    }
}
