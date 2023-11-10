
using OpenCvSharp;

namespace OpenCVCoreApp002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point pt1 = new Point(1, 2);
            Point pt2 = new Point(3, 2);

            Console.WriteLine(pt1+pt2);
            Console.WriteLine(pt1 - pt2);
            Console.WriteLine(pt1 == pt2);
            Console.WriteLine(pt1 *0.5);
            
            //거리
            Console.WriteLine(pt1.DistanceTo(pt2));
            //내적
            Console.WriteLine(pt1.DotProduct(pt2));
            //외적
            Console.WriteLine(pt1.CrossProduct(pt2));

            Scalar s1 = new Scalar(255, 127);
            Scalar s2 = Scalar.Yellow;
            Scalar s3 = Scalar.All(99);

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);



        }
    }
}