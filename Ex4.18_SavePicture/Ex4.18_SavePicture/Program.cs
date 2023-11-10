using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4._18_SavePicture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Mat img = new Mat(new Size(640,480),MatType.CV_8UC3);
            Mat img = Cv2.ImRead("C:\\Temp\\img\\OpenCV.png");
            bool save;

            ImageEncodingParam[] prms = new ImageEncodingParam[]
            {
                new ImageEncodingParam(ImwriteFlags.JpegQuality,100),
                new ImageEncodingParam (ImwriteFlags.JpegProgressive,1)
            };
            save = Cv2.ImWrite("CV.jpeg", img, prms);
            Console.WriteLine(save);
        }
    }
}
