using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Areas.ModulMenadzer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eNamjestaj.Web.Areas.ModulMenadzer.Controllers
{
    [Audit]
    [Autorizacija(false, false, true, false)]
    [Area("ModulMenadzer")]
    public class AkcijskiKatalogController : Controller
    {
        private MojContext ctx;

        public AkcijskiKatalogController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index()
        {
            List<AkcijskiKatalog> listaKataloga = ctx.AkcijskiKatalog.ToList();

            bool postojiAktivan = false;
            foreach (var lk in listaKataloga)
            {
                if (lk.Aktivan == true)
                    postojiAktivan = true;
            }

            AkcijskiKatalogIndexVM model = new AkcijskiKatalogIndexVM
            {
                daLiJeIjedanKatalogAktivan = postojiAktivan,
                Katalozi = ctx.AkcijskiKatalog.Select(x => new AkcijskiKatalogIndexVM.KatalogInfo
                {
                    Id = x.Id,
                    Opis = x.Opis,
                    DatumPocetka = x.DatumPocetka.Date,
                    DatumZavrsetka = x.DatumZavrsetka.Date,
                    Aktivan = x.Aktivan
                }).ToList()
            };

            return View(model);
        }

        public IActionResult Dodaj()
        {
            AkcijskiKatalogDodajVM model = new AkcijskiKatalogDodajVM();
            return View(model);
        }

        public IActionResult Obrisi(int katalogId)
        {
            AkcijskiKatalog a = ctx.AkcijskiKatalog.Find(katalogId);

            foreach (KatalogStavka x in ctx.KatalogStavka.Where(x => x.AkcijskiKatalogId == katalogId).ToList())
            {
                ctx.KatalogStavka.Remove(x);
                ctx.SaveChanges();
            }

            ctx.AkcijskiKatalog.Remove(a);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Snimi(AkcijskiKatalogDodajVM a)
        {
            if (ModelState.IsValid)
            {
                AkcijskiKatalog ak = new AkcijskiKatalog
                {
                    Opis = a.Opis,
                    DatumPocetka = (DateTime)a.DatumPocetka,
                    DatumZavrsetka = (DateTime)a.DatumZavrsetka,
                    Aktivan = true
                };

                ctx.AkcijskiKatalog.Add(ak);
                ctx.SaveChanges();

                return RedirectToAction("Index", "AkcijskiKatalog");
            }
            else
                return BadRequest(ModelState);
        }
    }
}