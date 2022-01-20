using AspNetWebAPIOAuth.Classes;
using AspNetWebAPIOAuth.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetWebAPIOAuth.Controllers
{
    [Audit]
    public class LoginController : Controller
    {
        // GET: Login
        KullaniciEntities1 db = new KullaniciEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Index");
        }
       
        [HttpPost]
        public ActionResult GirisAction(string usernamea, string password)
        {
            if (usernamea.Length > 12 || password.Length > 20)
            {
                Session["Uyari"] = "Kullanıcı adı veya şifreniz hatalı. Lütfen tekrar deneyin.";
            }

            var pss = Hash.md5(password);

            kullanicilar giris = new kullanicilar();

            try
            {
                giris = db.kullanicis.Where(w => w.username == usernamea && w.pass == password).FirstOrDefault();
            }
            catch(Exception ex)
            {
                giris = null;
            }




            if (giris != null) 
            {
                Session["UserName"] = giris.username;
                Session["Password"] = giris.pass;
                Session["USER"] = "Kullanıcı";

                return RedirectToAction("AnaSayfa", "AnaSayfa");
               
              
            }

           
            else
            {
                Session["Uyari"] = "Kullanıcı adı veya şifreniz hatalı. Lütfen tekrar deneyin.";
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Login", "Index");
        }
    }
}