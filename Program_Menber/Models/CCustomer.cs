using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Program_Menber.Models
{
    public class CCustomer
    {
        //新增會員
        public void create(CMember p)
        {
            string sql = "INSERT INTO member (";
            sql += "mname,";
            sql += "mbirth,";
            sql += "mgender,";
            sql += "memail,";
            sql += "mphone,";
            sql += "mpw,";
            sql += "mcity,";
            sql += "mpic";
            sql += ")VALUES(";
            sql += "'" + p.mname + "',";
            sql += "'" + p.mbirth + "',";
            sql += "'" + p.mgender + "',";
            sql += "'" + p.memail + "',";
            sql += "'" + p.mphone + "',";
            sql += "'" + p.mpw + "',";
            sql += "'" + p.mcity + "',";
            sql += "'" + p.mpic + "')";

            executeSql(sql);
        }

        private void executeSql(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=mydb;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

      

        public CMember queryByFid(int mid)
        {
            List<CMember> list = queryBySql("SELECT * FROM member WHERE mid=" + mid.ToString());
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public CMorder orderqueryByFid1(int oid)
        {
            List<CMorder> list = orderqueryBySql("SELECT * FROM memberorder WHERE oid=" + oid.ToString());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public List<CMember> queryAll()
        {
            return queryBySql("SELECT * FROM member");
        }

        //internal List<CMember> queryByKeyword(string keyword)
        //{
        //    string sql = "SELECT * FROM tCustomer WHERE fName LIKE '%" + keyword + "%'";
        //    sql += " OR fPhone LIKE '%" + keyword + "%'";
        //    sql += " OR fEmail LIKE '%" + keyword + "%'";
        //    sql += " OR fAddress LIKE '%" + keyword + "%'";
        //    return queryBySql(sql);
        //}

        //internal CMember queryByEmail(string email)
        //{
        //    List<CMember> list = queryBySql("SELECT * FROM member WHERE fEmail='" + email + "'");
        //    if (list.Count == 0)
        //        return null;
        //    return list[0];
        //}

        private List<CMember> queryBySql(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=mydb;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CMember> list = new List<CMember>();
            while (reader.Read())
            {
                CMember x = new CMember()
                {
                    mid = (int)reader["mid"],
                    mname = reader["mname"].ToString(),
                    mbirth = reader["mbirth"].ToString(),
                    mgender = reader["mgender"].ToString(),
                    memail = reader["memail"].ToString(),
                    mphone = reader["mphone"].ToString(),
                    mpw = reader["mpw"].ToString(),
                    mcity = reader["mcity"].ToString(),
                };
                list.Add(x);
            }
            con.Close();
            return list;
        }

        public CMember MqueryByFid(int mid)
        {
            List<CMember> list = queryBySql("SELECT mid,mname FROM member WHERE mid=" + mid.ToString());
            if (list.Count == 0)
                return null;
            return list[0];
        }


        public void update(CMember p)
        {
            

            string sql = "UPDATE member SET ";
            sql += "mname='" + p.mname + "',";
            sql += "mbirth='" + p.mbirth + "',";
            sql += "mgender='" + p.mgender + "',";
            sql += "memail='" + p.memail + "',";
            sql += "mpw='" + p.mpw+ "',";
            sql += "mcity='" + p.mcity + "',";
            sql += "mpic='" + p.mpic + "',";
            sql += "mphone='" + p.mphone + "'";
            sql += " WHERE mid=" + p.mid.ToString();

            executeSql(sql);
        }

        public void orderupdate(CMorder p)
        {
            string sql = "UPDATE memberorder SET ";
            sql += "opayment='" + p.ounit*300 + "',";
            sql += "ounit='" + p.ounit + "'";
            sql += " WHERE oid=" + p.oid.ToString();

            executeSql(sql);
        }

        public List<CMorder> orderqueryByFid(int omid)
        {
            
            return orderqueryBySql("SELECT * FROM memberorder WHERE omid=" + omid.ToString());
        }

        //public List<CMorder> orderqueryAll()
        //{
        //    return orderqueryBySql("SELECT * FROM memberorder");
        //}

        private List<CMorder> orderqueryBySql(string sql)
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
                    ounit = (int)reader["ounit"],
                    opayment = (int)reader["opayment"],
                    otem = reader["otem"].ToString(),
                    ofin = reader["ofin"].ToString(),
                    opic = reader["opic"].ToString(),
                };
                list.Add(x);
            }
            con.Close();
            return list;
        }


        public void delete(int oid)
        {
            string sql = "DELETE FROM memberorder WHERE oid=" + oid.ToString();
            executeSql(sql);
        }
    }
}