using System;
using System.Collections.Generic;
using System.Text;

namespace Line_Drawing
{
    class Rectangle
    {
        private Line [] _lines = new Line[4];
        int _length;
        int _width;
        int _area;

        //TODO CREATE PRIVATE FIELD & GET ONLY PROPERTY FOR THE AREA
        public int Area
        {
            get { return _area; }
        }

        public Rectangle(int x, int y, int length, int width)
        {
            Point p0 = new Point(x, y);
            Point p1 = new Point(p0.X + width - 1, p0.Y);
            Point p2 = new Point(p0.X, p0.Y + length - 1);
            Point p3 = new Point(p0.X + width, p0.Y + length);

            _lines[0] = new Line(p0, p1);
            _lines[1] = new Line(p0, p2);
            _lines[2] = new Line(p1, p3);
            _lines[3] = new Line(p2, p3);

            _length = length;
            _width = width;
            _area = _length * _width;
        }

        public Rectangle(Point p0, int length, int width)
        {
            Point p1 = new Point(p0.X + width-1, p0.Y);
            Point p2 = new Point(p0.X, p0.Y + length-1);
            Point p3 = new Point(p0.X + width, p0.Y + length);

            _lines[0] = new Line(p0, p1); _lines[0].Draw();
            _lines[1] = new Line(p0, p2); _lines[1].Draw();
            _lines[2] = new Line(p1, p3); _lines[2].Draw();
            _lines[3] = new Line(p2, p3); _lines[3].Draw();

            _length = length;
            _width = width;
            _area = _length * _width;
        }  

        public Rectangle(Point p0, Point p1, Point p2, Point p3)
        {
            _lines[0] = new Line(p0, p1);
            _lines[1] = new Line(p0, p2);
            _lines[2] = new Line(p1, p3);
            _lines[3] = new Line(p2, p3);
        }              

        public Rectangle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            _lines[0] = new Line(x1, y1, x2, y2);
            _lines[1] = new Line(x1, y1, x3, y3);
            _lines[2] = new Line(x3, y3-1, x4, y4);
            _lines[3] = new Line(x2-1, y2, x4-1, y4);
        }

        //MOVES RECTANGLE TO A NEW POSITION
        public void Move(int newX, int newY)
        {
            _lines[0].P0.X += newX; _lines[0].P0.Y += newY;
            _lines[0].P1.X += newX; _lines[0].P1.Y += newY;
            
            _lines[1].P0.X += newX; _lines[1].P0.Y += newY;
            _lines[1].P1.X += newX; _lines[1].P1.Y += newY;
            
            _lines[2].P0.X += newX; _lines[2].P0.Y += newY;
            _lines[2].P1.X += newX; _lines[2].P1.Y += newY;
            
            _lines[3].P0.X += newX; _lines[3].P0.Y += newY;
            _lines[3].P1.X += newX; _lines[3].P1.Y += newY;
        }

        //CHANGES DIMENSIONS OF THE RECT
        public void Reform(Point x1, int length, int width)
        {
            Point p1 = new Point(x1.X + width - 1, x1.Y);
            Point p2 = new Point(x1.X, x1.Y + length - 1);
            Point p3 = new Point(x1.X + width, x1.Y + length);

            _lines[0] = new Line(x1, p1);
            _lines[1] = new Line(x1, p2);
            _lines[2] = new Line(p1, p3);
            _lines[3] = new Line(p2, p3);
        }

        public void Reform(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            Point p0 = new Point(x1, y1);
            Point p1 = new Point(x2 - 1, y2);
            Point p2 = new Point(x3, y3 - 1);
            Point p3 = new Point(x4, y4);
            _lines[0] = new Line(p0, p1);
            _lines[1] = new Line(p0, p2);
            _lines[2] = new Line(p1, p3);
            _lines[3] = new Line(p2, p3);
        }

        public void Draw()
        {
            for (int i = 0; i < _lines.Length; i++)
            {
                _lines[i].Draw();
            }
        }
    }
}
