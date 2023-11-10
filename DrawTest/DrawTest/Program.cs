using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int value = 0;

            //Opencv용 윈도우
            Cv2.NamedWindow("Palette");
            Cv2.CreateTrackbar("Color", "Palette", ref value, 255);

            while(true)
            {
                int pixel = Cv2.GetTrackbarPos("Color", "Palette");
                Mat src = new Mat(new Size(500, 500), MatType.CV_8UC3,
                                    new Scalar(pixel, value, value));
                Cv2.ImShow("Palette", src);

                if (Cv2.WaitKeyEx(33) == 'q')
                    break;

            }
            Cv2.DestroyAllWindows();
        }
    }
}
