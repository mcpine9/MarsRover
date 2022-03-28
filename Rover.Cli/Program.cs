using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

namespace Rover.Cli
{


    public class Program
    {
        public static void Main(string[] args)
        {

            Console.Write("Enter upper right coordinates for Mars Rectangular Plateau. \n\rx?  ");
            string? x = Console.ReadLine();
            EntryValidation(x, "x", out var entryX);

            Console.Write("y?  ");
            var y = Console.ReadLine();
            EntryValidation(y, "y", out var entryY);

            CreateHostBuilder(args, entryX, entryY).Build().Run();



            bool oneMoreRover = false;
            do
            {
                Console.WriteLine("Enter a Mars Rover current positioning (Xcoord Ycoord and Orientation) separated by a space: \n\r");
                string currentPositioning = Console.ReadLine();

                string[] entered = currentPositioning.Split(" ");
                bool loop = false;
                do
                {
                    try
                    {
                        var positioning = new RoverPositioning(int.Parse(entered[0]), int.Parse(entered[1]), entered[2]);
                        if (!positioning.orientationConstraints.Contains(entered[2]))
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception e)
                    {
                        loop = true;
                        Console.WriteLine("Something went wrong. Please re-enter Mars Rover position.\n\r");
                    }

                } while (loop);

                Console.WriteLine("Enter a series of moves for this rover not separated (i.e. LLMMLMRM):\n\r ");
                var seriesEntry = Console.ReadLine();
                if (seriesEntry != null)
                    if (Regex.IsMatch(seriesEntry, "[lmrLMR]"))
                    {
                        seriesEntry.ToArray().ToList();
                    }



                Console.WriteLine("Enter another rover position and series of moves? Y or N?");
                var answer = Console.ReadLine();
                if (answer.ToUpper() == "Y")
                {
                    oneMoreRover = true;
                }

            } while (oneMoreRover);


            Console.WriteLine("Enter a series of moves (L, R, M) separated by a space: \n\r");
            string series = Console.ReadLine();


        }

        public static IHostBuilder CreateHostBuilder(string[] args, int x, int y) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddSingleton<IPlateau>(new MarsPlateau(x, y));

                    });


        public static void EntryValidation(string? entry, string axisName, out int entryNumber)
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

    }

}


