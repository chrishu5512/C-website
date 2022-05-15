using Program_Menber.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Program_Menber.Controllers
{
    public class AController : Controller
    {
        // GET: A
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult 抽籤詩()
        {
            抽籤詩 z = new 抽籤詩();

            int y = z.亂數();
            ViewBag.id = y;
            int u = z.亂數2();
            ViewBag.id2 = u;
            int g = z.亂數3();
            ViewBag.id3 = g;


            int idd = y;
            string sql = "select*from 籤詩 where sid=" + idd.ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=mydb;Integrated Security=True";
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

                ViewBag.yy = x;

                con.Close();

            }
            return View();
        }
        public ActionResult pick()
        {
            return View();
        }
        public ActionResult 抽籤()
        {
            抽籤詩 z = new 抽籤詩();
            int y = z.亂數();
            ViewBag.id = y;
            return View();
        }
    }
}