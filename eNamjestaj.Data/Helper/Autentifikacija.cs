using eNamjestaj.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        
     

        public static Korisnik GetLogiraniKorisnik(this HttpContext context)
        {
            Korisnik korisnik = context.Session.Get<Korisnik>(LogiraniKorisnik);
            if (korisnik == null)
            {
                context.Request.GetCookieJson<Korisnik>(LogiraniKorisnik);
                context.Session.Set(LogiraniKorisnik, korisnik);

            }
            return korisnik;
        }

       

        public static void SetLogiraniKorisnik(this HttpContext context, Korisnik korisnik,bool snimiUCookie=false)
        {
            
            context.Session.Set(LogiraniKorisnik,korisnik);

            context.Response.SetCookieJson(LogiraniKorisnik,snimiUCookie?korisnik:null);
        }



    }
}
