using Oracle.ManagedDataAccess.Client;

using OracleInternal.SqlAndPlsqlParser.LocalParsing;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Windows.Markup;



namespace AddressBook01

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





            
            OracleConnection conn = new OracleConnection(strConn);

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;



            int cnt = 1;

            while (true)

            {

                Console.WriteLine("1.테이블 만들기");

                Console.WriteLine("2.테이블 삭제");

                Console.WriteLine("3.데이터 삽입");

                Console.WriteLine("4.데이터 삭제");

                Console.WriteLine("5.데이터 수정");

                Console.WriteLine("6.데이터 조회");

                Console.Write("메뉴 : ");

                int a = Int32.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("--------------------------------");

                Console.WriteLine();

                if (a == 1)

                {

                    cmd.CommandText = "Create Table ADDRESSBOOK" +

                    "(ID number(4) PRIMARY KEY,  " +

                    "NAME varchar(20), " +

                    "HP varchar(20))";

                    Console.WriteLine("테이블이 생성되었습니다.");

                    //3.3 쿼리 실행하기

                    cmd.ExecuteNonQuery();

                    Console.WriteLine();

                }



                if (a == 2)

                {

                    cmd.CommandText = "DROP TABLE ADDRESSBOOK";

                    Console.WriteLine("테이블이 삭제되었습니다.");

                    cmd.ExecuteNonQuery();

                    Console.WriteLine();

                }



                if (a == 3)

                {

                    Console.Write("이름을 입력해주세요. : ");

                    string name = Console.ReadLine();

                    Console.Write("전화번호를 입력해 주세요. : ");

                    string phone = Console.ReadLine();



                    //3.5업데이트

                    cmd.CommandText = "INSERT INTO ADDRESSBOOK(ID,NAME,HP)" +

                               " VALUES(" + (cnt++) + ",'" + name + "','" + phone + "')";



                    cmd.ExecuteNonQuery();

                    Console.WriteLine();

                }



                if (a == 4)

                {

                    Console.Write("삭제할 이름을 입력하세요 : ");

                    string delname = Console.ReadLine();

                    cmd.CommandText = "DELETE FROM ADDRESSBOOK WHERE NAME = '" + delname + "'";

                    cmd.ExecuteNonQuery();

                }



                if (a == 5)

                {

                    Console.Write("전화번호를 수정할 이름을 입력하세요 : ");

                    string rename = Console.ReadLine();

                    Console.Write("수정할 전화번호를 입력하세요 : ");

                    string rephone = Console.ReadLine();

                    cmd.CommandText = "UPDATE ADDRESSBOOK SET HP = '" + rephone + "' WHERE NAME = '" + rename + "'";

                    cmd.ExecuteNonQuery();

                }



                if (a == 6)

                {

                    cmd.CommandText = "SELECT * FROM ADDRESSBOOK";

                    OracleDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())

                    {

                        //int id = rdr.GetInt32(0); //int나 number로 받을때 

                        //int id = int.Parse(rdr.GetString(0));  // 0이 뜻하는 것은 컬럼의 순서 0부터 첫번째 컬럼

                        //int id = int.Parse(rdr["ID"] as string); //Error

                        int id = int.Parse(rdr["ID"].ToString());

                        string name = rdr["NAME"] as string;

                        string hp = rdr["HP"] as string;

                        Console.WriteLine($"{id} : {name} : {hp}");

                        Console.WriteLine();

                    }

                }

                if (a == 7)

                {

                    break;

                }

            }

        }

    }

}