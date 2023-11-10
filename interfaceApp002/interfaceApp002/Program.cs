// See https://aka.ms/new-console-template for more information

interface IWing //인터페이스는 구현 받았다.상속아님. 클래스앞에 I를 붙임.
{
    public void Fly();
}
class Horse
{

}
class Unicon : Horse, IWing
{
    public void Fly()
    {
        Console.WriteLine("유니콘이 날다");
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Unicon unicon = new Unicon();
        unicon.Fly();
    }
}