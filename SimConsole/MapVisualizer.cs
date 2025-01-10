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
        private int Size { get; set; }
        public SmallMap Map { get; init; }
        public MapVisualizer(SmallMap map)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Map = map;
            Size = map.Size;
        }
        private Dictionary<Creature, Point> CreaturesOnPoint(Point point) => Map.Creatures.Where(c => c.Value.Equals(point)).ToDictionary();

        public void Draw()
        {
            DrawHorizontalLineTopOrBottom(true);
            for (int i = 0; i < Size; i++)
            {
                if (i != 0)
                {
                    DrawHorizontalLineMiddle();
                }
                NextLine();

                for (int j = 0; j < Size; j++)
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
         
            for (int i = 0; i < (Size-1); i++)
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

            for (int i = 0; i < (Size-1);  i++)
            {
                Console.Write(Box.Horizontal);
                Console.Write(Box.Cross);
            }
            Console.Write(Box.Horizontal);

            Console.Write(Box.MidRight);
        }
        private void DrawCorner(int type)
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
        private void DrawSeparator()
        {
            Console.Write(Box.Vertical);
        }
        private void NextLine()
        {
            Console.WriteLine();
        }

        private void DrawCreatures(Dictionary<Creature, Point> C)
        {
            string charToDraw = "";
            if (C.Count == 0)
            {
                charToDraw = " ";
            }
            else if (C.Count == 1)
            {
                if (C.First().Key.GetType() == typeof(Elf))
                {
                    charToDraw = "E";
                }
                else if (C.First().Key.GetType() == typeof(Orc))
                {
                    charToDraw = "O";
                }
            }
            else
            {
                charToDraw = "X";
            }
            Console.Write(charToDraw);
        }

    }
}
