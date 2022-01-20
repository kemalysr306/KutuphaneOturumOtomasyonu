using System.Linq;
using System;
using System.Net.Http;
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

        /* private readonly KullaniciEntities1 db;
         public DefaultController(KullaniciEntities1 db1) {
             db = db1;
         }*/
       

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

       /* [Route("List")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            string json;
            KullaniciEntities1 db = new KullaniciEntities1();
            var result = db.kullanicis.ToList();
            json = JsonConvert.SerializeObject(new { kullanicilar = result });
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return ResponseMessage(response);
        }*/
        // GET: api/OgrenciApi
       // [Route("Post")]
        /*[HttpPost]
       public IActionResult PostK(SimpleAuthorizationServerProvider simple)
        {
            
            string json;
            //SimpleAuthorizationServerProvider Provider = new SimpleAuthorizationServerProvider();
            //Provider.username.

            json = JsonConvert.SerializeObject(simple);
            var response = this.Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri + simple.ToString());// emin değilim
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return (IActionResult)Created("",simple);
            // var response = this.Request.CreateResponse(HttpStatusCode.Created);
        }*/
    }


}
    
        



            
        
