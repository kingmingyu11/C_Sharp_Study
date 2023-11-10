using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace appmaking
{
   
    
  
       
    internal class Program
    {

        static void Main(string[] args)
        {
            string strConn = "Data Source=(DESCRIPTION=" +

               "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +

               "(HOST=localhost)(PORT=1521)))" +

               "(CONNECT_DATA=(SERVER=DEDICATED)" +

               "(SERVICE_NAME=xe)));" +

               "User Id=hr;Password=hr;";

            //1.연결 객체 만들기 Client
            OracleConnection conn = new OracleConnection(strConn);

            //2. 데이터베이스 접속을 위한 연결
            conn.Open();

            //명령객체 생성
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            while(true)
            {
                Console.WriteLine("1.롤 팀 테이블 생성");
                Console.WriteLine("2.롤 팀 테이블 삭제");
                Console.WriteLine("3.롤 팀 테이블 접속");
                
               
                Console.WriteLine("4.프로그램 종료");

                Console.WriteLine("입력 :");
                int n = int.Parse(Console.ReadLine());
               
                string input;


                if( n==1 ) //롤 팀 테이블 생성
                {
                    Console.Write(" 팀 이름 입력 :");
                    input = Console.ReadLine();
                    cmd.CommandText = "CREATE TABLE " + input +

                          "(ID number(4) PRIMARY KEY,  " +

                           "LINE varchar2(20), " +

                           "NAME varchar2(20), AGE NUMBER(4), HEIGHT NUMBER(4)," +

                           "WEIGHT NUMBER(4), MONEY NUMBER(20), REGION varchar2(20))";

                    cmd.ExecuteNonQuery();

                    Console.WriteLine($"{input} 팀 테이블이 생성되었습니다.");
                        
                        
                }
               else  if (n == 2)
                {
                    Console.Write("삭제할팀 입력 :");
                    input = Console.ReadLine();
                    cmd.CommandText = "DROP TABLE" + input;
                    cmd.ExecuteNonQuery ();
                }
                else if (n == 3)
                {
                    Console.Write("어떤 팀에 접속하겠습니까?");
                    input = Console.ReadLine();
                    Console.Clear();
                    string team = input;
                    while(true)
                    {
                        Console.WriteLine($"{team} 팀의 테이블입니다 메뉴에서 원하는사항을 선택하십시오");
                        Console.WriteLine("1. 선수 생성");
                        Console.WriteLine("2. 선수 팔기");


                        if (n == 1)
                        {
                            cmd.CommandText = "INSERT INTO" + team + "values(";

                            Console.WriteLine("선수의 닉네임을 입력하세요:");
                            input = Console.ReadLine();
                            cmd.CommandText += input + ",";

                            Console.WriteLine("선수의 이름을 입력하세요:");
                            input = Console.ReadLine();
                            cmd.CommandText += input + ",";

                            Console.WriteLine("선수의 나이를 입력하세요:");
                            input = Console.ReadLine();
                            cmd.CommandText += input + ",";

                           

                            Console.Write("선수의 라인을 입력하세요 :");
                            input = Console.ReadLine ();
                           cmd.CommandText += input + " ,";

                            Console.Write("선수의 연봉을 입력하세요 :");
                            input = Console.ReadLine();
                            cmd.CommandText += input + " ,";

                            cmd.ExecuteNonQuery();

                       }
                        else if (n == 2)
                        {
                            Console.Write("선수의 폼이 떨어졌습니다 팔아보죠 :");
                            string name = Console.ReadLine();
                            cmd.CommandText = $"DELETE FROM {team}+ where NAME= {name}";
                            Console.WriteLine("방출완료");

                        }
                        break;


                    }
                }
                conn.Close();

            }




        }
        }
    
}