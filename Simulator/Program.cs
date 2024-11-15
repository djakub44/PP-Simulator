namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator!\n");
            //Creature c = new Creature("Daniel");
            Creature c = new();
            Console.WriteLine(c.Name);
            Console.WriteLine(c.Level);
            c.SayHi();
            Console.WriteLine(c.Info);

        }
    }
}
