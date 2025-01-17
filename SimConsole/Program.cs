﻿using Simulator.Maps;
using Simulator;

namespace SimConsole
{
    internal class Program
    {
        static void Main()
        {


            //Orc c = new("Elfff");
            //SmallSquareMap map = new(5);
            //Point p1 = new Point(0, 0);
            //Point p2 = new Point(1, 0);

            //((IMappable)c).SetMap(map,p1);

            //Console.WriteLine(map.CreatureExistsOnMap(c));
            //foreach (IMappable i in map.Creatures[p1])
            //    Console.WriteLine(i.Location.ToString());

            //((IMappable)c).Go(Direction.Right);

            //Console.WriteLine(map.CreatureExistsOnMap(c));
            //foreach (IMappable i in map.Creatures[p1])
            //    Console.WriteLine(i.ToString());
            //foreach (IMappable i in map.Creatures[p2])
            //    Console.WriteLine(i.ToString());

            //Animals kroliki = new() { Description = "Kroliki" };
            Birds strusie = new() { Description = "strusie", CanFly = false };
            Birds strusie2 = new() { Description = "strusie", CanFly = false };
            //Birds orly = new() { Description = "orly", CanFly = true };
            //Console.WriteLine(strusie.Info);
            //Console.WriteLine(strusie.Symbol);
            //Console.WriteLine(orly.Info);
            //Console.WriteLine(orly.Symbol);

            BigBounceMap map = new(8, 6);
            BigBounceMap map2 = new(8, 6);
            //List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), kroliki, strusie, orly];
            //List<Point> points = [new(2, 5), new(3, 1), new(3, 3), new(4, 3), new(3, 1)];

            List<IMappable> creatures = [strusie];//[new Orc("Gorbag")];
            List<IMappable> creatures2 = [strusie2];//[new Orc("Gorbag")];
            List<Point> points = [new(4, 4)];
            List<Point> points2 = [new(4, 4)];

            //string moves = "urldudlrludludr";
            string moves = "rrrrrr";
            Simulation simulation = new(map, creatures, points, moves) { DebugTurn = true };
            Simulation simulation2 = new(map2, creatures2, points2, moves) { DebugTurn = false };
            MapVisualizer mapVisualizer = new(simulation.Map);
            
            SimulationHistory history = new(simulation2);
            
            int i = 0;
            do
            {  
                
                mapVisualizer.Draw();
                Console.WriteLine(history.TurnLogs[i].ToString());
                simulation.Turn();
                i++;

            } while (!simulation.Finished);

        }
    }
}
