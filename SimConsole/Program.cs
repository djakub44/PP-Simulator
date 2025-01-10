using Simulator.Maps;
using Simulator;

namespace SimConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SmallSquareMap map = new(5);
            List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
            List<Point> points = [new(2, 2), new(3, 1)];
            string moves = "dlrludl";

            Simulation simulation = new(map, creatures, points, moves);
            simulation.DebugTurn = true;
            MapVisualizer mapVisualizer = new(simulation.Map);
            
            while (!simulation.Finished)
            {
                //Console.WriteLine(simulation.ToString());
                mapVisualizer.Draw();
                simulation.Turn();
                
            }
            
        }
    }
}
