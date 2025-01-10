namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {
        public Dictionary<Creature, Point> Creatures {  get; set; }
        public SmallMap(int size) : base(size, 20) 
        {
            Creatures = new Dictionary<Creature, Point>();
        }
        
        public bool AddCreature(Creature c,Point p)
        {
            if (this.Exist(p) && !Creatures.ContainsKey(c))
            {
                Creatures[c] = p;
                return true;
            }
            else
                return false;
        }
        public void Remove(Creature c)
        {
            if (Creatures.ContainsKey(c))
            {
                Creatures.Remove(c);
                c.RemoveMap();
            }
        }
        public void Move(Creature c, Point p)
        {
            if (Creatures.ContainsKey(c))
            {
                Creatures[c] = p;
            }
        }
        public List<Creature> At(Point p) => this.At(p.X, p.Y);
        public List<Creature> At(int x, int y)
        {
            Point p = new Point(x, y);
            return Creatures.Where(kvp => kvp.Value.Equals(p)).Select(kvp => kvp.Key).ToList();
        }

        // public Point At(int x, int y) 



    }
}
