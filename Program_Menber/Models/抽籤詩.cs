using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace Program_Menber.Models
{
    public class 抽籤詩
    {
        public int 亂數()
        {
            Random r = new Random();
            int id = r.Next(1, 34);
            return id;

        }
        public int 亂數2()
        {
            Thread.Sleep(20);
            Random r2 = new Random();
            int id = r2.Next(1, 5);
            return id;
        }

        public int 亂數3()
        {
            Thread.Sleep(20);
            Random r1 = new Random();
            int id = r1.Next(1, 6);
            return id;
        }

        public void 抽籤詩方法(int idd)
        {

            string sql = "select*from 籤詩 where sid=" + idd.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-R0387CA\MSSQLSERVER01;Initial Catalog=mydb;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //放在if內就是有查到資料才會載入記憶體(建立物件)
                C籤詩 x = new C籤詩();
                x.sid = (int)reader["sid"];
                x.s籤號 = (string)reader["s籤號"];
                x.s籤等 = (string)reader["s籤等"];
                x.s內文 = (string)reader["s內文"];
                x.s籤解 = (string)reader["s籤解"];

            }
            con.Close();



        }
    }
    public class 抽籤詩2
    {

    }
}
