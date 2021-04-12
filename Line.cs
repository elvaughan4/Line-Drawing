using System;
using System.Collections.Generic;
using System.Text;

namespace Line_Drawing
{
    class Line
    {
        private Point _p0 = new Point();
        private Point _p1 = new Point();
        private Point _midpoint;
        private double _slope;

        public Point P0
        {
            get { return _p0; }
            set { _p0 = value; }
        }

        public Point P1
        {
            get { return _p1; }
            set { _p1 = value; }
        }

        public Line (Point point0, Point point1)
        {
            P0 = point0;
            P1 = point1;
        }

        public Line(int x0, int y0, int x1, int y1)
        {
            P0.X = x0;
            P0.Y = y0;
            P1.X = x1;
            P1.Y = y1;
        }

        public Line(Point midpoint)
        {
            P0.X = midpoint.X;
            P0.Y = midpoint.Y;
            P1.X = midpoint.X;
            P1.Y = midpoint.Y;
        }

        public Point Midpoint()
        {
             int midX = (P0.X + P1.X) / 2;
             int midY = (P0.Y + P1.Y) / 2;

            _midpoint = new Point(midX, midY);
             return _midpoint;
        }

        public double Slope()
        {
            int steps;
            int dx;
            int dy;

            if ((P0.X - P1.X) > 0)
            {
                dx = P0.X - P1.X;
            }
            else dx = P1.X - P0.X;

            if ((P0.Y - P1.Y) > 0)
            {
                dy = P0.Y - P1.Y;
            }
            else dy = P1.Y - P0.Y;

            if (dx > dy)
            {
                steps = Math.Abs(dx);
            }
            else steps = Math.Abs(dx);

            int xIncrement = dx / steps;
            int yIncrement = dy / steps;

            _slope = xIncrement / yIncrement;
            return _slope;
        }

        public void Draw()
        {
            double steps;
            double dx;
            double dy;
            double xDraw;
            double yDraw;

            dx = P1.X - P0.X;
            dy = P1.Y - P0.Y;

            if (Math.Abs(dx) >= Math.Abs(dy))
            {
                steps = Math.Abs(dx);
            }
            else steps = Math.Abs(dy);

            double xIncrement = dx / steps;
            double yIncrement = dy / steps;

            xDraw = P0.X;
            yDraw = P0.Y;

            for (int i = 1; i <= steps; i++)
            {
                Console.SetCursorPosition((int)xDraw, (int)yDraw); 
                Console.Write("*");
                xDraw += xIncrement;
                yDraw += yIncrement;
            }
        }

        public void Collapse()
        {
            Line collapsedLine = new Line(P0, P1);
            collapsedLine.P0 = Midpoint();
            collapsedLine.P1 = P0;
            P0.Draw();
            P1.Draw();
        }

        public void Perturb()
        {
            Line perturbedLine = new Line(P0, P1);
            int xMin;
            int xMax;
            int yMin;
            int yMax;

            if (P0.X > P1.X)
            {
                xMax = P0.X;
                xMin = P1.X;
            }
            else
            {
                xMax = P1.X;
                xMin = P0.X;
            }
            if (P0.Y > P1.Y)
            {
                yMax = P0.Y;
                yMin = P1.Y;
            }
            else
            {
                yMax = P1.Y;
                yMin = P0.Y;
            }

            Random rand = new Random();

            perturbedLine.P0.X = rand.Next(xMin, xMax + 1);
            perturbedLine.P0.Y = rand.Next(yMin, yMax + 1);
            perturbedLine.P1.X = rand.Next(xMin, xMax + 1);
            perturbedLine.P1.Y = rand.Next(yMin, yMax + 1);

            perturbedLine.Draw();
        }
    }
}
