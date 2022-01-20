using System.Linq;
using System;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetWebAPIOAuth.OAuth.Providers;
using System.Data.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Http.Cors;

namespace AspNetWebAPIOAuth.Controllers
{

    public class DefaultController : ApiController
    {

        [HttpGet]
        [Authorize]
       
        public List<kullanicilar> List()
        {
            KullaniciEntities1 a = new KullaniciEntities1();
            var degerler = a.kullanicis.ToList();

            foreach (var item in degerler)
            {
                item.username = "";


                a.SaveChanges();
            }
            return degerler;
        }

      
    }


}
    
        



            
        
