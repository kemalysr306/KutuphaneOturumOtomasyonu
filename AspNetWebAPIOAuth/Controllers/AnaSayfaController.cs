using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetWebAPIOAuth.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        public ActionResult AnaSayfa()
        {
            Session["SayfaAdi"] = "AnaSayfa";

            string usertype = null;


            try
            {
                usertype = Session["USER"].ToString();
            }
            catch
            {
                usertype = null;
            }

            if (usertype == null)
            {
                return RedirectToAction("Login", "Index");
            }

         

            string username = Session["USERNAME"].ToString();
            
            
            
            
            return View();
        }
        
    }
}