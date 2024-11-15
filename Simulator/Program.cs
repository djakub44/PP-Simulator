namespace Simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Simulator!\n");
            Creature c = new Creature();
            Console.WriteLine(c.Name);
            Console.WriteLine(c.Level);
        }
    }
}
