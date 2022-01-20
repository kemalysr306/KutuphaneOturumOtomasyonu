using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetWebAPIOAuth.Controllers
{
    public class AnaSayfaController : Controller
    {
        public class AnaSayfaModel
        {
            public kullanicilar user { get; set; }
            public List<kullanicilar> klist { get; set; }
            public oturumSuresi oturum { get; set; }
            public List<oturumSuresi> olist { get; set; }

        } 
        // GET: AnaSayfa
        public ActionResult AnaSayfa()
        {
            KullaniciEntities1 db = new KullaniciEntities1();
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


            string userName = Session["USERNAME"].ToString();
           

            AnaSayfaModel ajm = new AnaSayfaModel();
            kullanicilar user = db.kullanicilar.Where(w => w.username == userName).FirstOrDefault();                                                                                                                  
            List<oturumSuresi> kullanicilist = db.oturumSuresi.Where(w => w.oturum == true).ToList();
            

            ajm.user = user;
            ajm.olist = kullanicilist;

            return View(ajm);



           
        }
        
    }
}