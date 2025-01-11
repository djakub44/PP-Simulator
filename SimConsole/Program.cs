using Simulator.Maps;
using Simulator;

namespace SimConsole
{
    internal class Program
    {
        static void Main()
        {
            Animals kroliki = new() { Description = "Kroliki"};
            Birds strusie = new() { Description = "strusie", CanFly = false };
            Birds orly = new() { Description = "orly", CanFly = true };
            Console.WriteLine(strusie.Info);
            Console.WriteLine(strusie.Symbol);
            Console.WriteLine(orly.Info);
            Console.WriteLine(orly.Symbol);

            SmallTorusMap map = new(8,6);
            List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), kroliki, strusie, orly];
            List<Point> points = [new(2, 5), new(3, 1), new(3, 3), new(4, 3), new(3, 1)];
            string moves = "urldudlrludludr";

            Simulation simulation = new(map, creatures, points, moves) { DebugTurn = true};
            MapVisualizer mapVisualizer = new(simulation.Map);
            
            while (!simulation.Finished)
            {
                
                mapVisualizer.Draw();
                simulation.Turn();
                
            }
            
        }
    }
}
