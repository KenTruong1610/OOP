using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class Triangle : ITriangle
    {
        public Point3D A { get; set; }
        public Point3D B { get; set; }
        public Point3D C { get; set; }

        public Triangle(Point3D p1, Point3D p2, Point3D p3)
        {
            A = p1;
            B = p2;
            C = p3;
        }

        public string CheckType()
        {
            double a = A.CalcDistance(B);
            double b = B.CalcDistance(C);
            double c = C.CalcDistance(A);

            if (a == b && b == c) return "Tam giác đều";
            if (a == b || b == c || a == c)
            {
                if (Math.Abs(Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) < 1e-6 ||
                    Math.Abs(Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) < 1e-6 ||
                    Math.Abs(Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) < 1e-6)
                {
                    return "Tam giác vuông cân";
                }
                return "Tam giác cân";
            }
            if (Math.Abs(Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) < 1e-6 ||
                Math.Abs(Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) < 1e-6 ||
                Math.Abs(Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) < 1e-6)
            {
                return "Tam giác vuông";
            }

            return "Tam giác thường";
        }
    }
}
