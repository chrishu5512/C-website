using Program_Menber.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Program_Menber.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        mydbEntities db = new mydbEntities();
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        public string testingInsert()
        {
            CMember x = new CMember()
            {
                mname = "李享",
                mbirth = "1997/10/03",
                mgender = "男生",
                memail = "kfidjen@gmail.com",
                mphone = "0958736123",
                mpw = "38r@yfhnA",
                mcity = "台北市",
                mpic = "2.jpg"
            };
            (new CCustomer()).create(x);
            return "新增資料成功";
        }

        
       

        public ActionResult display()
        {
            string id = User.Identity.Name;
            var mmm = db.member.Where(m => m.memail == id).ToList();
            
            return View(mmm);
        }
        public ActionResult Edit(int? id)
        {
            CMember x = null;
            if (id != null)
                x = (new CCustomer()).queryByFid((int)id);
            return View(x);
        }
        [HttpPost]
        public ActionResult Edit(CMember p)
        {
            string mpic = "";
            if (p.mphoto != null)
            {

                if (p.mphoto.ContentLength > 0)
                {
                    mpic = Path.GetFileName(p.mphoto.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), mpic);
                    p.mphoto.SaveAs(path);
                    string sql = "UPDATE member SET ";
                    sql += "mname='" + p.mname + "',";
                    sql += "mbirth='" + p.mbirth + "',";
                    sql += "mgender='" + p.mgender + "',";
                    sql += "memail='" + p.memail + "',";
                    sql += "mpw='" + p.mpw + "',";
                    sql += "mcity='" + p.mcity + "',";
                    sql += "mpic='" + mpic + "',";
                    sql += "mphone='" + p.mphone + "'";
                    sql += " WHERE mid=" + p.mid.ToString();

                    executeSql(sql);
                }

            }

            return RedirectToAction("display");
        }

        public ActionResult mpCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult mpCreate(HttpPostedFileBase photo)
        {
            CMember x = null;
            string filename = "";
            if (photo != null)
            {

                if (photo.ContentLength > 0)
                {
                    filename = Path.GetFileName(photo.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), filename);
                    photo.SaveAs(path);
                    string sql = "UPDATE member SET ";
                    sql += "mpic='" + filename + "'";
                    sql += " WHERE mid=" + x.mid.ToString();
                    executeSql(sql);
                }

            }
            return View();

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

        public ActionResult displayorderById(int id)
        {

            List<CMorder> list = null;
            if (id != null)
                list = (new CCustomer()).orderqueryByFid(id);

            return View(list);
        }

        public ActionResult OEdit(int? id)
        {
            CMorder x = null;
            if (id != null)
                x = (new CCustomer()).orderqueryByFid1((int)id);
            return View(x);
        }
        [HttpPost]
        public ActionResult OEdit(CMorder x)
        {
            (new CCustomer()).orderupdate(x);
            return RedirectToAction("display");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
                (new CCustomer()).delete((int)id);
            return RedirectToAction("display");
        }


        //Get:Member/AddCar
        public ActionResult AddCar(int fPId)
        {
            //取得會員帳號並指定給fUserId
            string fUserId = User.Identity.Name;
         
            //找出目前選購的產品並指定給product
            var product = db.product.Where(m => m.pid == fPId).FirstOrDefault();
            var mmm = db.member.Where(z => z.memail == fUserId).FirstOrDefault();
            memberorder order = new memberorder();
            order.odate = DateTime.Now.ToShortDateString().ToString();
            order.omemail = fUserId;
            order.oproduct = product.pname;
            order.otem = product.ptemp;
            order.ounit = 1;
            order.opayment = product.pprice;
            order.omid =mmm.mid;
            order.odetail = "";
            order.ofin = "";
            order.oname = mmm.mname;
            order.opic = "0.jpg";
            

            db.memberorder.Add(order);
            db.SaveChanges();
            return RedirectToAction("pList","Product");
        }


    }
}