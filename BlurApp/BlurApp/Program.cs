using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlurApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Temp\\img\\moon.jpg";
            Mat src = Cv2.ImRead(path);
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);

            //Cv2.GaussianBlur(src, dst, new Size(9, 9),3,3,BorderTypes.Isolated);  

            //양방향 필터

            Cv2.BilateralFilter(src, dst, 100, 33, 11,
                BorderTypes.Isolated);

            Cv2.ImShow("src", src);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
            
        }
    }
}
