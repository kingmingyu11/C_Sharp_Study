using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string path = "C:\\Temp\\img\\video1.avi";
            VideoCapture capture = new VideoCapture(0);
            capture.Set(VideoCaptureProperties.FrameWidth, 320);
            capture.Set(VideoCaptureProperties.FrameHeight, 240);
            Mat frame = new Mat();

            while (true)
            {
                if (capture.IsOpened() == true)
                {
                    capture.Read(frame);
                    Cv2.ImShow("VideoFrame", frame);
                    if (Cv2.WaitKey(33) == 'q') break;

                }
                capture.Release();
                Cv2.DestroyAllWindows();

            }
        }
    }
}

