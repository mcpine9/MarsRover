using Rover.Cli;

MarsPlateau plateau;
Console.Write("Enter upper right coordinates for Mars Rectangular Plateau. \n\rx?  ");
string? x = Console.ReadLine();
EntryValidation(x, "x", out var entryX);

Console.Write("y?  ");
var y = Console.ReadLine();
EntryValidation(y, "y", out var entryY);
plateau = new MarsPlateau(entryX, entryY);


void EntryValidation(string? entry, string axisName, out int entryNumber)
{
    int result;
    bool entryIsNumber;
    do
    {
        entryIsNumber = int.TryParse(entry, out result);
        if (!entryIsNumber)
        {
            Console.WriteLine($"'{entry ?? "[empty]"}' is not a number. \n\r Try again. {axisName}?");
            entry = Console.ReadLine();
        }
    } while (!entryIsNumber);

    entryNumber = result;
}