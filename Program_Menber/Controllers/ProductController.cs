using Program_Menber.Models;
using Program_Menber.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Program_Menber.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        
        mydbEntities db = new mydbEntities();
        
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult pList()
        {
            string area = Request.Form["txtarea"];
            string cat = Request.Form["txtcat"];
            List<Product> list = null;
            if(area=="b" && cat=="a" )
            {
                list = (new Productfactory()).pQueryAll();
            }
            else
            {
                list = (new Productfactory()).pQueryByKeyword(area,cat);
            }
            return View(list);
        }

        public ActionResult pdetail(int id)
        {
            Product x = null;
            if (id != null)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=.;Initial Catalog=mydb;Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM product WHERE pid=" + id, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    x = new Product();
                    x.pid = (int)reader["pid"];
                    x.parea = reader["parea"].ToString();
                    x.pcity = reader["pcity"].ToString();
                    x.pcate = reader["pcate"].ToString();
                    x.ptemp = reader["ptemp"].ToString();
                    x.pname = reader["pname"].ToString();
                    x.pprice = reader["pprice"].ToString();
                    x.pintroduce = reader["pintroduce"].ToString();
                    x.pwebsite = reader["pwebsite"].ToString();
                    x.pdetail = reader["pdetail"].ToString();
                    ViewBag.KK = x;
                }
                con.Close();
            }
            return View(x);
        }

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(int fpid)
        {
            string fUserId = User.Identity.Name;
            var product = db.product.Where(m => m.pid == fpid).FirstOrDefault();
            memberorder order = new memberorder();
            order.odate = Request.Form["odate"];
            order.omid = int.Parse(fUserId);
            order.oproduct = product.pname;
            order.otem = product.ptemp;
            order.ounit = int.Parse(Request.Form["ounit"]);
            order.opayment = int.Parse(Request.Form["opayment"]);
            db.memberorder.Add(order);
            db.SaveChanges();
            return RedirectToAction("pList", "Product");
        }

        public  void ocmember(int id)
        {
            CMember x = null;
            if (id != null)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=.;Initial Catalog=mydb;Integrated Security=True";
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT mid,mname FROM member WHERE mid=" + id, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    x = new CMember();
                    x.mid = (int)reader["mid"];
                    x.mname = reader["mname"].ToString();
                    

                    ViewBag.KK = x;
                }
                con.Close();
            }
            
        }
    }
}