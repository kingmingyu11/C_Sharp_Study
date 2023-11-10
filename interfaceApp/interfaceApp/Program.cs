using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceApp
{
    interface ILogger 
    {
        void WriteLog(string message);
    }
    class ConsoleLogger { } //방법 1

    class FIleLogger : ILogger
    {
        private StreamWriter writer;
        //생성자
        public FIleLogger(string path)
        {
            writer = File.CreateText(path);
            writer.AutoFlush = true;
        }
        public void WriteLog(string message)
        {
            writer.WriteLine(DateTime.Now.ToShortTimeString() + " " + message);
        }
    } //방법2
    class ClimateMonitor //대상 객체 
    {
        private ILogger logger; //IS-A 상속 관계 HAS-A 포함관계
        public ClimateMonitor(ILogger logger)
            {
                this.logger = logger;
            } 
        public void start()
        {
            //핵심 메소드
            while (true)
            {
                Console.Write("온도를 입력해주세요 :");
                String temperature = Console.ReadLine();

                if (temperature == "")
                    break;

                logger.WriteLog("현재 온도 : " +  temperature);
            }
        }
        
    } 
    internal class Program
    {
        static void Main(string[] args)
        {
            //객체가 콘솔로그 또는파일로그 중 1개를 선택해서 로그만들기
            ClimateMonitor monitor = new ClimateMonitor(new FIleLogger("MyLog.txt"));
            monitor.start();
        }
    }
}
