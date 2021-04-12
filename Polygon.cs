using System;
using System.Collections.Generic;
using System.Text;

namespace Line_Drawing
{
    class Polygon
    {
        private bool _closed = false;
        private LinkedList _pointList = new LinkedList();

        public bool Closed 
        { get { return _closed; } 
          set { _closed = value; } 
        }

        public void Add(Point newPoint)
        {
            _pointList.Add(newPoint);
        }

        public void Add(int x, int y)
        {
            Point point = new Point(x, y);
        }

        public void Draw()
        {
            Point p0 = new Point();
            Point p1 = new Point();

            for (int i = 0; i < _pointList.Count-1; i++)
            {
                p0 = (Point)_pointList[i];               
                p1 = (Point)_pointList[i + 1];
                              
                Line line = new Line(p0, p1);
                line.Draw();
            }

            if (Closed == true)
            {
                Line line = new Line(p1, (Point)_pointList[0]);
                line.Draw();
            }
        }
    }
}
