using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            IPoint[] points = new IPoint[10];

            points[0] = new Point2D(1.0, 2.0);
            points[1] = new Point2D(3.0, 4.0);
            points[2] = new Point2D(5.0, 6.0);
            points[3] = new Point3D(0.0, 0.0, 3.0);
            points[4] = new Point3D(0.0, 3.0, 0.0);
            points[5] = new Point3D(0.0, 0.0, 0.0);
            points[6] = new Point3D(4.0, 0.0, 0.0);
            points[7] = new Point3D(1.0, 2.0, 3.0);
            points[8] = new Point3D(4.0, 5.0, 6.0);
            points[9] = new Point3D(7.0, 8.0, 9.0);

            // In ra thông tin các điểm
            Console.WriteLine("Thông tin các điểm:");
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] is Point2D p2d)
                {
                    Console.WriteLine($"Point2D {i + 1}: X = {p2d.X}, Y = {p2d.Y}");
                }
                else if (points[i] is Point3D p3d)
                {
                    Console.WriteLine($"Point3D {i + 1}: X = {p3d.X}, Y = {p3d.Y}, Z = {p3d.Z}");
                }
            }

            // In ra khoảng cách giữa các cặp điểm cùng loại
            Console.WriteLine("\nKhoảng cách giữa các cặp điểm cùng loại:");
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    if (points[i].GetType() == points[j].GetType())
                    {
                        double distance = points[i].CalcDistance(points[j]);
                        Console.WriteLine($"Khoảng cách giữa điểm {i + 1} và điểm {j + 1}: {distance}");
                    }
                }
            }
            Console.WriteLine("\nCác tam giác được tạo thành từ các điểm Point3D:");
            for (int i = 3; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    for (int k = j + 1; k < points.Length; k++)
                    {
                        Triangle triangle = new Triangle((Point3D)points[i], (Point3D)points[j], (Point3D)points[k]);
                        Console.WriteLine($"Tam giác được tạo bởi điểm {i + 1}, {j + 1}, {k + 1}: {triangle.CheckType()}");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}

