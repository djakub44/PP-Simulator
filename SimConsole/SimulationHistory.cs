
using Simulator;
using Simulator.Maps;

namespace SimConsole
{
    public class SimulationHistory
    {
        private Simulation _simulation { get; }
        public int SizeX { get; }
        public int SizeY { get; }
        public List<SimulationTurnLog> TurnLogs { get; } = [];
        // store starting positions at index 0

        public SimulationHistory(Simulation simulation)
        {
            _simulation = simulation ??
                throw new ArgumentNullException(nameof(simulation));
            SizeX = _simulation.Map.SizeX;
            SizeY = _simulation.Map.SizeY;
            Run();
        }

        private void Run()
        {
            if (_simulation.DebugTurn == true)
            {
                throw new ArgumentException("Simulation debug mode cannot be set to true");
            }
            List<Map> maps = new List<Map>();
            do
            {
                TurnLogs.Add(new SimulationTurnLog() { Mappable = _simulation.CurrentCreature.ToString(), Move = _simulation.CurrentMoveName, Symbols = _simulation.SymbolsOnPoint()});
                _simulation.Turn();
            } while (!_simulation.Finished);
        }
    }

    /// <summary>
    /// State of map after single simulation turn.
    /// </summary>
    public class SimulationTurnLog
    {
        /// <summary>
        /// Text representastion of moving object in this turn.
        /// CurrentMappable.ToString()
        /// </summary>
        public required string Mappable { get; init; }
        /// <summary>
        /// Text representation of move in this turn.
        /// CurrentMoveName.ToString();
        /// </summary>
        public required string Move { get; init; }
        /// <summary>
        /// Dictionary of IMappable.Symbol on the map in this turn.
        /// </summary>
        public required Dictionary<Point, char> Symbols { get; init; }

        public override string ToString()
        {
            return $"{Mappable} --- {Move} --- {Symbols.First().Value}";
        }
    }
}
