
using OpenCvSharp;

internal class Program
{
    
    private static void Main(string[] args)
    {
        //Console.WriteLine(Cv2.GetVersionString());

        //Vec4d vecotr1 = new Vec4d(1.0,2.0,3.0,4.0);
        //Vec4d vector2 = new Vec4d(1.0, 2.0, 3.0, 4.0);
        //Console.WriteLine(vecotr1);
        //Console.WriteLine(vecotr1.Item0);
        //Console.WriteLine(vecotr1.Item1);

        //Console.WriteLine(vecotr1.Equals(vector2));
        Vec3i v1 = new Vec3i(1, 2, 3);
        Vec3f v2 = new Vec3f(1.1f, 2.2f, 3.3f);
        
        Console.WriteLine(v1);
        Console.WriteLine(v2);

        Point3d point3D = new Point3d(1.0, 2.0, 3.0);
        Point3d pt2 = point3D;
        Console.WriteLine(point3D);
        Console.WriteLine(pt2);


    }
}