using System;

namespace Line_Drawing
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p0 = new Point(5,  13);
            Point p1 = new Point(33, 13);
            Point p2 = new Point(67,  1);
            Point p3 = new Point(77, 15);
            Point p4 = new Point(51, 26);
            Point p5 = new Point(42, 17);
            Point p6 = new Point(29, 26);
            Point p7 = new Point(8,  20);

            Polygon newPolygon = new Polygon();
                newPolygon.Add(p0);
                newPolygon.Add(p1);
                newPolygon.Add(p2);
                newPolygon.Add(p3);
                newPolygon.Add(p4);
                newPolygon.Add(p5);
                newPolygon.Add(p6);
                newPolygon.Add(p7);

                newPolygon.Closed = true;

                newPolygon.Draw();
                Console.ReadKey();
        }
    }
}
