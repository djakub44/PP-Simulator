using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator
{
    public class Simulation
    {
        private int CurrentTurn { get; set; } = 0;
        public bool DebugTurn {  get; set; } = true;
        private Direction[] Directions {  get; set; }
        /// <summary>
        /// Simulation's map.
        /// </summary>
        public Map Map { get; init; }

        /// <summary>
        /// Creatures moving on the map.
        /// </summary>
        public List<IMappable> Creatures { get; init; }

        /// <summary>
        /// Starting positions of creatures.
        /// </summary>
        public List<Point> Positions { get; init; }

        /// <summary>
        /// Cyclic list of creatures moves. 
        /// Bad moves are ignored - use DirectionParser.
        /// First move is for first creature, second for second and so on.
        /// When all creatures make moves, 
        /// next move is again for first creature and so on.
        /// </summary>
        public string Moves { get; init; }

        /// <summary>
        /// Has all moves been done? 
        /// </summary>
        public bool Finished = false;

        /// <summary>
        /// Creature which will be moving current turn.
        /// </summary>
        public IMappable CurrentCreature { get; set; }

        /// <summary>
        /// Lowercase name of direction which will be used in current turn.
        /// </summary>
        public string CurrentMoveName { get; set; } 

        /// <summary>
        /// Simulation constructor.
        /// Throw errors:
        /// if creatures' list is empty,
        /// if number of creatures differs from 
        /// number of starting positions.
        /// </summary>
        public Simulation(Map map, List<IMappable> creatures, List<Point> positions, string moves)
        {
            if (creatures is null || creatures.Count == 0 || creatures.Count != positions.Count)
            {
                throw new Exception("error simulation");
            }
            else
            {

                Map = map;
                Creatures = creatures;
                Positions = positions;
                Moves = moves;
                CurrentCreature = Creatures.First();
                Directions = DirectionParser.Parse(moves);
                CurrentMoveName = moves[0].ToString();

                AddCreaturesToMap();
            }   
        }
        /// <summary>
        /// Adds List of creatures to the map
        /// </summary>
        private void AddCreaturesToMap()
        {
            for(int i = 0; i < Creatures.Count; i++)
            {
                Creatures[i].SetMap(Map, Positions[i]);
            }
        }

        //CurrentTurn should be already incremented
        private IMappable NextCreature()
        {
            if (CurrentTurn < (Creatures.Count-1))
            {
                return Creatures[CurrentTurn];
            }
            else
            {
                return Creatures[(CurrentTurn) % Creatures.Count];
            }
        }
        //CurrentTurn should be already incremented
        private string NextMoveName()
        {
            return Moves[CurrentTurn].ToString();
        }

        /// <summary>
        /// Makes one move of current creature in current direction.
        /// Throw error if simulation is finished.
        /// </summary>
        public void Turn()
        {
            //move creature 
            CurrentCreature.Go(Directions[CurrentTurn]);
            
            //change turn number
            CurrentTurn++;

            //check if finished
            if (CurrentTurn < Directions.Length)
            {
                //change current creature
                CurrentCreature = NextCreature();
                //change current move
                CurrentMoveName = NextMoveName();

            }
            else
                Finished = true;
            if (DebugTurn)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.WriteLine();
                Console.Clear();
            }
        }
    }
}
