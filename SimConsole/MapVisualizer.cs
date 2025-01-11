using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace SimConsole
{
    public class MapVisualizer
    {
        //najbrzydszy kod jaki w zyciu napisalem ale konczyl mi sie czas
        private int SizeX { get; set; }
        private int SizeY { get; set; }
        public Map Map { get; init; }
        public MapVisualizer(SmallMap map)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Map = map;
            SizeX = map.SizeX;
            SizeY = map.SizeY;
        }
        private Dictionary<IMappable, Point> CreaturesOnPoint(Point point) => Map.Creatures.Where(c => c.Value.Equals(point)).ToDictionary();

        public void Draw()
        {
            DrawHorizontalLineTopOrBottom(true);
            for (int i = 0; i < SizeY; i++)
            {
                if (i != 0)
                {
                    DrawHorizontalLineMiddle();
                }
                NextLine();

                for (int j = 0; j < SizeX; j++)
                {
                    DrawSeparator();
                    DrawCreatures(CreaturesOnPoint(new Point(i, j)));
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
         
            for (int i = 0; i < (SizeX-1); i++)
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

            for (int i = 0; i < (SizeX-1);  i++)
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

        private static void DrawCreatures(Dictionary<IMappable, Point> C)
        {
            char charToDraw;
            if (C.Count == 0)
            {
                charToDraw = ' ';
            }
            else if (C.Count == 1)
            {
                charToDraw = C.First().Key.Symbol;
            }
            else
            {
                charToDraw = 'X';
            }
            Console.Write(charToDraw);
        }

    }
}
