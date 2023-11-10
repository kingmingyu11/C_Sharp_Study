using System;
using System.Collections.Generic;
using OpenCvSharp;

class Program
{
    static void DrawRotatedRect(Mat img, RotatedRect mr, Scalar color, int thickness = 2)
    {
        Point2f[] pts2f = mr.Points(); // Point2f 배열 가져오기

        // Point2f를 Point로 변환
        Point[] pts = new Point[4];
        for (int i = 0; i < 4; i++)
        {
            pts[i] = new Point((int)pts2f[i].X, (int)pts2f[i].Y);
        }

        for (int i = 0; i < 4; i++)
        {
            Cv2.Line(img, pts[i], pts[(i + 1) % 4], color, thickness);
        }
    }

    static Mat Preprocessing(Mat image)
    {
        Mat gray = new Mat();
        Mat thImg = new Mat();
        Mat morph = new Mat();
        Mat kernel = new Mat(5, 15, MatType.CV_8U, new Scalar(1)); // 닫힘 연산 마스크
        Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY); // 명암도 영상 변환
        Cv2.Blur(gray, gray, new Size(5, 5)); // 블러링
        Cv2.Sobel(gray, gray, MatType.CV_8U, 1, 0, 3); // 소벨 에지 검출
        Cv2.Threshold(gray, thImg, 120, 255, ThresholdTypes.Binary); // 이진화 수행
        Cv2.MorphologyEx(thImg, morph, MorphTypes.Close, kernel, new Point(-1, -1), 2); // 열림 연산 수행

        Cv2.ImShow("th_img", thImg);
        Cv2.ImShow("morph", morph);

        return morph;
    }

    static bool VerifyPlate(RotatedRect mr)
    {
        float size = mr.Size.Width * mr.Size.Height; // 넓이 계산
        float aspect = (float)mr.Size.Height / mr.Size.Width; // 종횡비 계산
        if (aspect < 1) aspect = 1 / aspect;

        bool ch1 = size > 2000 && size < 30000; // 번호판 넓이 조건
        bool ch2 = aspect > 1.0 && aspect < 6.4; // 번호판 종횡비 조건

        return ch1 && ch2;
    }

    static void FindCandidates(Mat img, List<RotatedRect> candidates)
    {
        List<List<Point>> contours = new List<List<Point>>(); // 외곽선을 저장할 리스트
        Mat hierarchy = new Mat(); // Hierarchy 정보를 저장할 Mat

        Cv2.FindContours(img.Clone(), out contours, hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

        for (int i = 0; i < contours.Count; i++) // 검출 외곽선 조회
        {
            RotatedRect rotRect = Cv2.MinAreaRect(contours[i]); // 외곽선 최소영역 회전사각형
            if (VerifyPlate(rotRect)) // 번호판 검증
                candidates.Add(rotRect); // 회전사각형 저장
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("1. 차량 번호판 검출");
        Console.Write("메뉴를 선택하세요 (1): ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            if (choice == 1)
            {
                Console.Write("차량 번호를 입력하세요 (0-20): ");
                if (int.TryParse(Console.ReadLine(), out int carNo) && carNo >= 0 && carNo <= 20)
                {
                    string fn = string.Format("../image/test_car/{0:D2}.jpg", carNo);
                    Mat image = new Mat(fn, ImreadModes.Color);
                    if (image.Empty())
                    {
                        Console.WriteLine("이미지 파일을 찾을 수 없습니다.");
                        return;
                    }

                    Mat morph = Preprocessing(image);
                    List<RotatedRect> candidates = new List<RotatedRect>();
                    FindCandidates(morph, candidates);

                    foreach (var candidate in candidates)
                    {
                        DrawRotatedRect(image, candidate, new Scalar(0, 255, 0), 2);
                    }

                    if (candidates.Count == 0)
                    {
                        Console.WriteLine("번호판 후보를 찾지 못했습니다.");
                    }

                    Cv2.ImShow("image", image);
                    Cv2.WaitKey();
                }
                else
                {
                    Console.WriteLine("잘못된 번호를 입력했습니다. 0에서 20 사이의 번호를 입력하세요.");
                }
            }
            else
            {
                Console.WriteLine("잘못된 메뉴 선택입니다. 1을 선택하세요.");
            }
        }
        else
        {
            Console.WriteLine("메뉴 선택은 숫자로 입력하세요.");
        }
    }
}
