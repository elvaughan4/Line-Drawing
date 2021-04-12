using System;
using System.Collections.Generic;
using System.Text;

namespace Line_Drawing
{
    class Point
    {
        private int _x;
        private int _y;

        public int X
        {
            get { return _x; }
            set
            {
                if (value < 0)
                    _x = 0;
                else
                    _x = value;
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                if (value < 0)
                    _y = 0;
                else
                    _y = value;
            }
        }

        public Point(int newX = 0, int newY = 0)
        {
            X = newX;
            Y = newY;
        }

        public void Draw()
        {
            Console.SetCursorPosition(_x, _y);
            Console.WriteLine("*");
        }
    }
}
