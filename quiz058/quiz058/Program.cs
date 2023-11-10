using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace quiz058
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Temp\\myLog.txt";
            string strConn = "Data Source=(DESCRIPTION=" +

                 "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +

                 "(HOST=localhost)(PORT=1521)))" +

                 "(CONNECT_DATA=(SERVE=DEDICATED)" +

                 "(SERVICE_NAME=xe)));" +

                 "User Id=hr;Password=hr;";
            OracleConnection conn = new OracleConnection(strConn);

            conn.Open();

            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            int count = 1;
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                for (int i = 0; i < 6; i++)
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "정상 동작 중!!");
                    sw.Flush();
                    cmd.CommandText = $"INSERT INTO LOGDATA VALUES({count++}," +
                        $"'{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}'," +
                        $"'정상동작중!!!')";
                    cmd.ExecuteNonQuery();
                    Thread.Sleep(1000);
                }
                sw.Close();

                fs = new FileStream(path,FileMode.Open);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                string str = sr.ReadToEnd();
                Console.WriteLine(str);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
