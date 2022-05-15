using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Program_Menber.Models
{
    public class CMorderfactory
    {
        private void executeSql(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=mydb;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public CMorder queryByFid(int mid)
        {
            List<CMorder> list = queryBySql("SELECT * FROM memberorder WHERE oid=" + mid.ToString());
            if (list.Count == 0)
                return null;
            return list[0];
        }


        private List<CMorder> queryBySql(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=mydb;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CMorder> list = new List<CMorder>();
            while (reader.Read())
            {
                CMorder x = new CMorder()
                {
                    oid = (int)reader["oid"],
                    odate = reader["odate"].ToString(),
                    omid = (int)reader["omid"],
                    oname = reader["oname"].ToString(),
                    oproduct = reader["oproduct"].ToString(),
                    otem = reader["otem"].ToString(),
                    ounit = (int)reader["ounit"],
                    opayment = (int)reader["opayment"],
                    ofin = reader["ofin"].ToString(),
                    odetail = reader["odetail"].ToString(),
                    omemail = reader["omemail"].ToString(),
                };
                list.Add(x);
            }
            con.Close();
            return list;
        }



    }
}