using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseEventOpenCv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat src = new Mat(new Size(500, 500), MatType.CV_8UC3, new Scalar(255, 255, 255));

            Cv2.ImShow("draw", src);
            //마우스 이벤트 콜백 객체 생성
            MouseCallback mouseCallback = new MouseCallback(Event);
            //부착 및 등록
            Cv2.SetMouseCallback("draw", mouseCallback, src.CvPtr);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

        }
        static void Event(MouseEventTypes @event,int x, int y, MouseEventFlags flags, IntPtr userdata)
        {

            switch (@event)
            {
                case MouseEventTypes.LButtonDown:
                Console.WriteLine("마우스 왼쪽 버튼누르기");
                    break;
                case MouseEventTypes.LButtonDoubleClick:

                    Console.WriteLine("마우스 왼쪽 버튼 더블 클릭");

                    break;

                case MouseEventTypes.RButtonDown:

                    Console.WriteLine("마우스 오른쪽 버튼 눌림");

                    break;

                case MouseEventTypes.RButtonUp:

                    Console.WriteLine("마우스 오른쪽 버튼 뗌");

                    break;

                case MouseEventTypes.RButtonDoubleClick:

                    Console.WriteLine("마우스 오른쪽 버튼 더블 클릭");

                    break;

            }
            
        }
    }

}
