using System;
using System.Collections.Generic;
using System.Text;

namespace Line_Drawing
{
    class Triangle
    {
        private Line[] _lines = new Line[3];
        int _length;
        int _width;
        int _area;
        Point _startingPoint;

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Area
        {
            get { return _area; }
            set { _area = value; }
        }

        private Point StartingPoint
        {
            get { return _startingPoint; }
            set { _startingPoint = value; }
        }

        public Triangle (Point p0, int length, int width)
        {
            Point p1 = new Point(p0.X + width, p0.Y);
            Point p2 = new Point(p0.X, p0.Y + length - 1);
            
            _lines[0] = new Line(p0, p1);
            _lines[1] = new Line(p0, p2);
            _lines[2] = new Line(p2, p1);
            _length = length;
            _width = width;
            _area = _length * _width / 2;
            _startingPoint = p0;
        }

        public Triangle(int x, int y, int length, int width)
        {
            Point p0 = new Point(x, y);
            Point p1 = new Point(p0.X + width, p0.Y);
            Point p2 = new Point(p0.X, p0.Y + length - 1);

            _lines[0] = new Line(p0, p1);
            _lines[1] = new Line(p0, p2);
            _lines[2] = new Line(p2, p1);
            _length = length;
            _width = width;
            _area = _length * _width / 2;
            _startingPoint = p0;
        }

        public void Draw()
        {
            for (int i = 0; i < _lines.Length; i++)
            {
                _lines[i].Draw();
            }
        }

        public void Move(int newX, int newY)
        {
            _lines[0].P0.X += newX; _lines[0].P0.Y += newY;
            _lines[0].P1.X += newX; _lines[0].P1.Y += newY;

            _lines[1].P0.X += newX; _lines[1].P0.Y += newY;
            _lines[1].P1.X += newX; _lines[1].P1.Y += newY;

            _lines[2].P0.X += newX; _lines[2].P0.Y += newY;
            _lines[2].P1.X += newX; _lines[2].P1.Y += newY;
        }

        public void Fill()
        {
            int timer;
            int counter = 0;

            if (_length <= _width)
            {
                timer = _length;
            }
            else timer = _width;

            Console.CursorVisible = false;

            while (timer > 1)
            {
                Triangle shade = new Triangle(StartingPoint, Length - counter, Width - counter);
                shade._length = _length - 1;
                shade._width = _width - 1;
                shade.Draw();
                timer--;
                counter++;

                for (int j = 0; j < 10000000; j++) ;         
            }
        }
        public void Shade()
        {       
            int counter = 0;

            ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor .Yellow,
                                 ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.DarkMagenta, ConsoleColor.DarkBlue, ConsoleColor.Green};

            Triangle shadedT = new Triangle(StartingPoint, Length - counter, Width - counter);

            Console.CursorVisible = false;

            for (int i = 0; i < colors.Length; i++)
            {
                for (int j = 0; j < 500000000; j++) ;

                Console.ForegroundColor = colors[i];
                shadedT.Fill();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;
        }
    }
}
