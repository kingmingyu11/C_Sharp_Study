
// See https://aka.ms/new-console-template for more information

interface ILogger
{
    void WriteLog(string message);
}
class ConsoleLogger : ILogger
{
    public void WriteLog(string message)
    {
        Console.WriteLine(DateTime.Now.ToLocalTime() + " " +  message);
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        ILogger logger = new ConsoleLogger();
        logger.WriteLog("사건발생");
    }
}
