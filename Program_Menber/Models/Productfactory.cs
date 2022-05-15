using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Program_Menber.Models
{
    public class Productfactory
    {
        public List<Product> pquerybysql(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=mydb;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> list = new List<Product>();
            while (reader.Read())
            {
                Product x = new Product()
                {
                    pid = (int)reader["pid"],
                    parea = reader["parea"].ToString(),
                    pcity = reader["pcity"].ToString(),
                    pcate = reader["pcate"].ToString(),
                    ptemp = reader["ptemp"].ToString(),
                    pname = reader["pname"].ToString(),
                    pprice = reader["pprice"].ToString(),
                    ppic = reader["ppic"].ToString(),
                };
                list.Add(x);
            }
            con.Close();
            return list;

        }

        private void pexecuteSql(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=mydb;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Product> pQueryByKeyword(string area , string cat)
        {
            string sql = "select * from product where parea like '%"
                + area + "%'";
            sql += "and pcate like '%" + cat + "%'";
            return pquerybysql(
                sql);
        }

        public List<Product> pQueryAll()
        {
            return pquerybysql("select * from product");
        }
    }
}