using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Web.Http;
using System.Linq;
using System.Collections.Generic;
using System;

namespace AspNetWebAPIOAuth.OAuth.Providers
{
    
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        
        KullaniciEntities1 db = new KullaniciEntities1();
        public string username;
        public string password;
        // OAuthAuthorizationServerProvider sınıfının client erişimine izin verebilmek için ilgili ValidateClientAuthentication metotunu override ediyoruz.
        
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
    
        [HttpPost]
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
          
            // CORS ayarlarını set ediyoruz.

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            kullanicilar yeni = new kullanicilar();
            try
            {
                yeni = db.kullanicis.Where(w => w.username == context.UserName && w.pass == context.Password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                yeni = null;
            }
            

            List<kullanicilar> asamlist = new List<kullanicilar>();
            asamlist = db.kullanicis.ToList();
            foreach (var item in asamlist)
            {

                username = item.username;
                password = item.pass;

            }
            db.SaveChanges();

            // Kullanıcının access_token alabilmesi için gerekli validation işlemlerini yapıyoruz.
            if (context.UserName == yeni.username && context.Password == yeni.pass)
            {

              

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));

                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Kullanıcı adı veya şifre yanlış.");
            }
           
           
        }
    }
}