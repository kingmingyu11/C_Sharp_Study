﻿using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redtomato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("C:\\Temp\\img\\tomato.jpg");
            Mat hsv = new Mat(src.Size(),MatType.CV_8UC3);
            //어두운 붉은색
            Mat lower_red = new Mat(src.Size(), MatType.CV_8UC3);
            // 밝은 붉은색
            Mat upper_red = new Mat(src.Size(), MatType.CV_8UC3);
            // 합성한 어둡고 밝은 붉은색 mask
            Mat added_red = new Mat(src.Size(), MatType.CV_8UC3);
            // 결과
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);

            Cv2.CvtColor(src, hsv, ColorConversionCodes.BGR2HSV);

            Cv2.InRange(hsv, new Scalar(0, 100, 100), new Scalar(5,255,255),lower_red);

            Cv2.InRange(hsv, new Scalar(170, 100, 100), new Scalar(179, 255, 255), upper_red);

            Cv2.AddWeighted(lower_red, 1.0, upper_red, 1.0, 0.0, added_red);

            Cv2.BitwiseAnd(hsv, hsv, dst, added_red);

            Cv2.CvtColor(dst, dst, ColorConversionCodes.HSV2BGR);
            

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey();
        }
    }
}
