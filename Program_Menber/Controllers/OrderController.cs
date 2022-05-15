using Program_Menber.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Program_Menber.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Welcome"] = null;
            return RedirectToAction("Login", "Home");
        }
        //GET: Order
        mydbEntities db = new mydbEntities();
        public ActionResult orderList()
        {
            IEnumerable<memberorder> products = null;
            string keyword = Request.Form["txtKeyword"];
            if (string.IsNullOrEmpty(keyword))
                products = from p in (new mydbEntities()).memberorder
                           select p;
            else
                products = from p in (new mydbEntities()).memberorder
                           where p.oname.Contains(keyword)
                           select p;
            return View(products);
        }
        public ActionResult orderDelete(int id)
        {
            mydbEntities db = new mydbEntities();
            memberorder prod = db.memberorder.FirstOrDefault(p => p.oid == id);
            if (prod != null)
            {
                db.memberorder.Remove(prod);
                db.SaveChanges();
            }
            return RedirectToAction("orderList");
        }
        //public ActionResult orderCreate()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult orderCreate(memberorder p)
        //{
        //    mydbEntities db = new mydbEntities();
        //    if (p.photo != null)
        //    {
        //        //string photoName = Guid.NewGuid().ToString() + ".jpg";
        //        string photoName = Path.GetFileName(p.photo.FileName);
        //        p.photo.SaveAs(Server.MapPath("~/images/" + photoName));
        //        p.opic = photoName;

        //    }
        //    db.memberorder.Add(p);
        //    db.SaveChanges();
        //    return RedirectToAction("orderList");
        //}
        public ActionResult orderEdit(int id)
        {
            CMorder x = null;
            if (id != null)
                x = (new CMorderfactory()).queryByFid((int)id);
            return View(x);
        }
        [HttpPost]
        public ActionResult orderEdit(CMorder p)
        {

            string mpic = "";
            if (p.photo != null)
            {

                if (p.photo.ContentLength > 0)
                {
                    mpic = Path.GetFileName(p.photo.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), mpic);
                    p.photo.SaveAs(path);
                    string sql = "UPDATE memberorder SET ";
                    sql += "odate='" + p.odate + "',";
                    sql += "oname='" + p.oname + "',";
                    sql += "omid='" + p.omid + "',";
                    sql += "oproduct='" + p.oproduct + "',";
                    sql += "otem='" + p.otem + "',";
                    sql += "ounit='" + p.ounit + "',";
                    sql += "opayment='" + p.opayment + "',";
                    sql += "ofin='" + p.ofin + "',";
                    sql += "opic='" + mpic + "',";
                    sql += "odetail='" + p.odetail + "',";
                    sql += "omemail='" + p.omemail + "'";
                    sql += " WHERE oid=" + p.oid.ToString();

                    executeSql(sql);
                }
                
            }
            return RedirectToAction("orderList");

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

    }
}