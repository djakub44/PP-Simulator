using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole
{
    internal class LogVisulizer
    {
        //public Map Map { get; private set; }
        SimulationHistory Log { get; }
        public LogVisulizer(SimulationHistory log)
        {
            Log = log;
        }

        public void dddDraw(int turnIndex)
        {
            
        }


        public void Draw(int turnNumber)
        {
            DrawHorizontalLineTopOrBottom(true);
            for (int j = Log.SizeY; j > 0; j--)
            {
                if (j != Log.SizeY)
                {
                    DrawHorizontalLineMiddle();
                }
                NextLine();

                for (int i = 0; i < Log.SizeX; i++)
                {
                    DrawSeparator();
                    DrawCreatures(CreaturesOnPoint(new Point(i, j), turnNumber));
                }
                DrawSeparator();
                NextLine();
            }
            DrawHorizontalLineTopOrBottom(false);
        }

        private void DrawHorizontalLineTopOrBottom(bool top)
        {
            if (top)
                DrawCorner(1);
            else
                DrawCorner(3);

            for (int i = 0; i < (Log.SizeX - 1); i++)
            {
                Console.Write(Box.Horizontal);
                if (top)
                    Console.Write(Box.TopMid);
                else
                    Console.Write(Box.BottomMid);
            }
            Console.Write(Box.Horizontal);

            if (top)
                DrawCorner(2);
            else
                DrawCorner(4);

        }
        private void DrawHorizontalLineMiddle()
        {

            Console.Write(Box.MidLeft);

            for (int i = 0; i < (Log.SizeX - 1); i++)
            {
                Console.Write(Box.Horizontal);
                Console.Write(Box.Cross);
            }
            Console.Write(Box.Horizontal);

            Console.Write(Box.MidRight);
        }
        private static void DrawCorner(int type)
        {
            switch (type)
            {
                case 1:
                    Console.Write(Box.TopLeft); break;
                case 2:
                    Console.Write(Box.TopRight); break;
                case 3:
                    Console.Write(Box.BottomLeft); break;
                case 4:
                    Console.Write(Box.BottomRight); break;
                default:
                    break;
            }
        }
        private static void DrawSeparator()
        {
            Console.Write(Box.Vertical);
        }
        private static void NextLine()
        {
            Console.WriteLine();
        }
        private static void DrawCreatures(char symbol)
        {
            //char charToDraw;
            //if (C.Count == 0)
            //{
            //    charToDraw = ' ';
            //}
            //else if (C.Count == 1)
            //{
            //    charToDraw = C.First().Symbol;
            //}
            //else
            //{
            //    charToDraw = 'X';
            //}
            Console.Write(symbol);
        }
        private char CreaturesOnPoint(Point point, int TurnNumber)
        {
            if (Log.TurnLogs[TurnNumber].Symbols.TryGetValue(point, out var symbol))
            {
                return symbol;
            }
            return ' ';
        }

    }
}
