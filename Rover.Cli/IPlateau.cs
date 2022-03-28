namespace Rover.Cli;

public interface IPlateau
{
    bool IsCoordinatesWithinPlateauPlane(int x, int y);
}