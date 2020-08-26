using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eNamjestaj.Web.Controllers
{
    public class NarudzbeController : Controller
    {
        private MojContext ctx;
        public NarudzbeController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Zakljuci(int narudzbaID, int dostava, string total)
        {
            if (ModelState.IsValid)
            {
                //KupacLoginVM k = null;// HttpContext.GetLogiraniKorisnik();
                //AktivnaNarudzba n = null;// HttpContext.GetAktivnaNarudzba();
                Narudzba n = ctx.Narudzba.Where(x => x.Id == narudzbaID).FirstOrDefault();
                n.NaCekanju = true;
                n.Aktivna = false;
                //ctx.Narudzba.Where(na => na.Id == n.Id).First().Status = false;
                ctx.SaveChanges();

                decimal totalDec = Convert.ToDecimal(total);

                Izlaz i = new Izlaz
                {
                    NarudzbaId = narudzbaID,
                    BrojNarudzbe = n.BrojNarudzbe,
                    Datum = DateTime.Now,
                    Zakljucena = false,
                    IznosSaPDV = totalDec,
                    IznosBezPDV = totalDec - (totalDec / 17),
                    DostavaId = Convert.ToInt32(dostava),
                    SkladisteId = 1
                };
                ctx.Izlaz.Add(i);
                ctx.SaveChanges();

                foreach (var x in ctx.NarudzbaStavka.Where(x => x.NarudzbaId == narudzbaID).Include(q => q.Proizvod).ToList())
                {
                    IzlazStavka ns = new IzlazStavka
                    {
                        Cijena = x.CijenaProizvoda,
                        Popust = x.PopustNaCijenu,
                        Konacnacijena = x.TotalStavke,
                        Kolicina = x.Kolicina,
                        ProizvodId = x.ProizvodId,
                        IzlazId = i.IzlazId
                    };
                    ctx.IzlaziStavka.Add(ns);
                }

                ctx.SaveChanges();
                return PartialView("Zakljuci");
            }
            else
                return RedirectToAction("Index", "NarudzbaStavke");
        }
    }
}