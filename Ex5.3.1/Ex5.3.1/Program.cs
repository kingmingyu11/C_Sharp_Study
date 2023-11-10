using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Ex5._3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat src = Cv2.ImRead("C:\\Temp\\img\\tomato.jpg");
            Mat hsv = new Mat(src.Size(), MatType.CV_8UC3);
            Mat dst = new Mat(src.Size(), MatType.CV_8SC3);

            //BGR --> HSV
            Cv2.CvtColor(src, hsv, ColorConversionCodes.BGR2HSV);
            //HSV 각각 채널을 분리
            // Hue(색상) : 색깔에 해당하는 시각적 감각의 속성
            // Saturation(채도) : 색상의 깊이로 얼마나 순수한 색상이냐를 구분,
            // Value(명도) : 밝고 어두운 정도인데 명도가 높을수록 인식률 이 좋다.
            Mat[] Hsv = Cv2.Split(hsv); 
            
            Mat H_orange = new Mat(src.Size(),MatType.CV_8SC1);
            Cv2.InRange(Hsv[0], new Scalar(8), new Scalar(20), H_orange);
           
            Cv2.BitwiseAnd(hsv,hsv,dst,H_orange);
            Cv2.CvtColor(dst,dst,ColorConversionCodes.HSV2BGR);

            Cv2.ImShow("dst", dst);
            Cv2.WaitKey();
            


        }
    }
}
