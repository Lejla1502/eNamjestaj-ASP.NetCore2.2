using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eNamjestaj.Web.Controllers
{
    public class NarudzbaStavkeController : Controller
    {
        MojContext ctx = new MojContext();

        private readonly IUserSession _userSession;

        public NarudzbaStavkeController(IUserSession userSession)
        {
            _userSession = userSession;
        }
        public IActionResult Index()
        {
        //KupacLoginVM k = null; //HttpContext.GetLogiraniKorisnik();
                //AktivnaNarudzba n = HttpContext.GetAktivnaNarudzba();
                
            //Korisnik k = HttpContext.GetLogiraniKorisnik();
            User user = _userSession.User;
            //Kupac kupac = ctx.Kupac.Where(x => x.KorisnikId == k.Id).FirstOrDefault();
            Kupac kupac = ctx.Kupac.Where(x => x.Korisnik.KorisnickoIme == user.Username).FirstOrDefault();

            int brojAktivnihNarudzbi = ctx.Narudzba.Where(x => x.KupacId == kupac.Id && x.Aktivna == true).Count();

                if (brojAktivnihNarudzbi > 0)
                {
                    Narudzba n = ctx.Narudzba.Where(x => x.KupacId == kupac.Id && x.Aktivna == true).First();
                    NarudzbaStavkeIndexVM model = new NarudzbaStavkeIndexVM
                    {
                        NarudzbaID = n.Id,
                        proizvodiNarudzbe = ctx.NarudzbaStavka.Where(y => y.NarudzbaId == n.Id).Select(x => new NarudzbaStavkeIndexVM.NarudzbaInfo
                        {
                            NarudzbastavkaID = x.Id,
                            Proizvod = x.Proizvod.Naziv,
                            VrstaProizvoda = x.Proizvod.VrstaProizvoda.Naziv,
                            Boja = x.Boja.Naziv,
                            Cijena = x.CijenaProizvoda.ToString("0.00"),
                            Popust = x.PopustNaCijenu.ToString("0.00"),
                            KonacnaCijena = ((x.CijenaProizvoda - (x.CijenaProizvoda * x.PopustNaCijenu / 100))).ToString("0.00"),
                            Kolicina = x.Kolicina,
                            Total = x.TotalStavke.ToString("0.00")
                        }).ToList(),
                        SumTotal = Convert.ToDecimal(ctx.NarudzbaStavka.Where(y => y.NarudzbaId == n.Id).Sum(y => y.TotalStavke)).ToString("0.00", new CultureInfo("en-US", false))// System.Globalization.CultureInfo.InvariantCulture)
                    };
                    return View(model);
                }
                else
                    return View(null);
            }

        
    }
}