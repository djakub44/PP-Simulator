using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class MapSnapshot
    {
        public Map Map{  get; set; }
        public List<IMappable> Creatures { get; set; }
        public MapSnapshot(Map map)
        {
            Creatures = new List<IMappable>();
            Map = map;
            foreach (IMappable c in map)
            {
                Creatures.Add(c);
            }
        }
        public override string ToString()
        {
            var selectedData = Creatures.Select(c => new
            {
                c.Symbol,
                c.Location.X,
                c.Location.Y
            });

            string jsonString = JsonSerializer.Serialize(selectedData, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: for pretty printing
            });
            return jsonString;
        }

    }
}
