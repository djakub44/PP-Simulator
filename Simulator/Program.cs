using System.Diagnostics.Tracing;

namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Starting Simulator!\n");
            //Creature c = new Creature("d", 0);
            //Creature d = new Creature("d1D", 8);
            //Console.WriteLine(c.Name);
            //Console.WriteLine(c.Level);
            //c.Upgrade();

            //d.Upgrade();
            //c.SayHi();
            //Console.WriteLine(c.Info);
            //d.SayHi();

            //Creature c = new() { Name = "   Shrek    ", Level = 20 };
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //c = new("  ", -5);
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //c = new("  donkey ") { Level = 7 };
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //c = new("Puss in Boots – a clever and brave cat.");
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //c = new("a                            troll name", 5);
            //c.SayHi();
            //c.Upgrade();
            //Console.WriteLine(c.Info);

            //var a = new Animals() { Description = "   Cats " };
            //Console.WriteLine(a.Info);

            //a = new() { Description = "Mice           are great", Size = 40 };
            //Console.WriteLine(a.Info);
            //c.Go([Directions.Up, Directions.Left, Directions.Right, Directions.Down]);
            Creature c = new("Shrek", 7);
            c.SayHi();

            Console.WriteLine("\n* Up");
            c.Go(Direction.Up);

            Console.WriteLine("\n* Right, Left, Left, Down");
            Direction[] directions = {
                Direction.Right, Direction.Left, Direction.Left, Direction.Down
            };
            c.Go(directions);

            Console.WriteLine("\n* LRL");
            c.Go("LRL");

            Console.WriteLine("\n* xxxdR lyyLTyu");
            c.Go("xxxdR lyyLTyu");
        }

    }
}
