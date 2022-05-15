using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Program_Menber.Controllers
{
    public class HomeController : Controller
    {
        mydbEntities db = new mydbEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        //你要改~~
        [HttpPost]
        public ActionResult Login(string memail, string mpw)
        {
            var member = db.member.Where(m => m.memail == memail && m.mpw == mpw).FirstOrDefault();
            if (member == null)
            {
                ViewBag.Message = "帳密錯誤,登入失敗";
                return View();
            }
            else if(memail == "kfidjen@gmail.com"&& mpw== "38r@yfhnA")
            {
                Session["Welcome"] = member.mname + "歡迎光臨";
                FormsAuthentication.RedirectFromLoginPage(memail, true);
                return RedirectToAction("orderList", "Order");
            }
            else
            Session["Welcome"] = member.mname + "歡迎光臨";
            FormsAuthentication.RedirectFromLoginPage(memail, true);
            return RedirectToAction("pList", "Product");
        }
        //你要改~~
        public ActionResult Register()
        {
            return View();
        }
        //Post:Home/Register
        [HttpPost]
        //你要改~~
        public ActionResult Register(member pMember)
        {
            //若模型沒有通過驗證則顯示目前的View
            if (ModelState.IsValid == false)
            {
                return View();
            }
            // 依帳號取得會員並指定給member
            var member = db.member
                .Where(m => m.memail == pMember.memail)
                .FirstOrDefault();
            //若member為null，表示會員未註冊
            if (member == null)
            {
                //將會員記錄新增到tMember資料表
                db.member.Add(pMember);
                db.SaveChanges();
                //執行Home控制器的Login動作方法
                return RedirectToAction("Login");
            }
            ViewBag.Message = "此帳號己有人使用，註冊失敗";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Welcome"] = null;
            return RedirectToAction("Login", "Home");
        }
    }
}