using Oracle.ManagedDataAccess.Client;

namespace OracleApp_insert2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string strConn = "Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=LOCALHOST)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)" +
                "(SERVICE_NAME=xe)));" +
                "User Id=hr;Password=hr;";

            //1. 연결객체만들기

          OracleConnection conn = new OracleConnection(strConn);

            //2. 객체 열기
            conn.Open();

            //3. Query 만들기
            //3-1 Query 를 만들기 위한 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            //3 -2 쿼리 작성
            string query = "INSERT INTO PHONEBOOK (ID, NAME, HP) VALUES (7, '홍길동','010-2222-2222');";
            cmd.CommandText = query;

            //3-3 쿼리 실행
            cmd.ExecuteNonQuery();

            conn.Close();

            Console.WriteLine("쿼리를 실행하였습니다.");
         
            
        }
    }
}