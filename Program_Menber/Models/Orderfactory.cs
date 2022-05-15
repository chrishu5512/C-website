using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Program_Menber.Models
{
    public class Orderfactory
    {

        private void oexecuteSql(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=mydb;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void create(CMorder o)
        {
            string sql = "INSERT INTO memberorder (";
            sql += "odate,";
            sql += "omid,";
            sql += "oname,";
            sql += "oproduct,";
            sql += "otem,";
            sql += "ounit,";
            sql += "opayment,";
            sql += "ofin,";
            sql += "opic,";
            sql += "odetail";
            sql += ")VALUES(";
            sql += "'" + o.odate + "',";
            sql += "'" + o.omid + "',";
            sql += "'" + o.oname + "',";
            sql += "'" + o.oproduct + "',";
            sql += "'" + o.otem + "',";
            sql += "'" + o.ounit + "',";
            sql += "'" + o.opayment + "',";
            sql += "'" + o.ofin + "',";
            sql += "'" + o.opic + "',";
            sql += "'" + o.odetail + "')";

            oexecuteSql(sql);
        }


    }
}