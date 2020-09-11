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
    public class AkcijskiKatalogStavkeController : Controller
    {
        private MojContext ctx;

        public AkcijskiKatalogStavkeController(MojContext _ctx)
        {
            ctx = _ctx;
        }

        public IActionResult Index(int katalogId)
        {
            AkcijskiKatalog ak = ctx.AkcijskiKatalog.Find(katalogId);
            AkcijskiKatalogStavkeIndexVM model = new AkcijskiKatalogStavkeIndexVM
            {
                KatalogId = katalogId,
                KatalogProizvodi = ctx.KatalogStavka.Where(y => y.AkcijskiKatalogId == ak.Id).Select(x => new AkcijskiKatalogStavkeIndexVM.ProizvodiInfo
                {
                    Id = x.Id,
                    Proizvod = x.Proizvod.Naziv,
                    Cijena = x.Proizvod.Cijena,
                    Procenat = x.PopustProcent,
                    KonacnaCijena = Convert.ToDecimal(x.Proizvod.Cijena - (x.Proizvod.Cijena * x.PopustProcent / 100))
                }).ToList()
            };
            return PartialView(model);
        }

        public IActionResult Dodaj(int katalogId)
        {
            AkcijskiKatalogStavkeDodajVM model = new AkcijskiKatalogStavkeDodajVM
            {
                Proizvodi = ctx.Proizvod.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }).ToList(),
                KatalogID = katalogId
            };

            return PartialView(model);
        }

        public IActionResult Obrisi(int katalogId, int stavkaId)
        {
            KatalogStavka ks = ctx.KatalogStavka.Find(stavkaId);
            ctx.KatalogStavka.Remove(ks);
            ctx.SaveChanges();

            return RedirectToAction("Index", new { @katalogId = katalogId });
        }


        public IActionResult Snimi(AkcijskiKatalogStavkeDodajVM a)
        {
            if (ModelState.IsValid)
            {
                KatalogStavka ks = new KatalogStavka
                {
                    PopustProcent = a.Procenat,
                    ProizvodId = a.ProizvodID,
                    AkcijskiKatalogId = a.KatalogID
                };

                ctx.KatalogStavka.Add(ks);
                ctx.SaveChanges();

                int katalogId = a.KatalogID;
                AkcijskiKatalog ak = ctx.AkcijskiKatalog.Find(a.KatalogID);
                AkcijskiKatalogStavkeIndexVM model = new AkcijskiKatalogStavkeIndexVM
                {
                    KatalogId = katalogId,
                    KatalogProizvodi = ctx.KatalogStavka.Where(y => y.AkcijskiKatalogId == ak.Id).Select(x => new AkcijskiKatalogStavkeIndexVM.ProizvodiInfo
                    {
                        Id = x.Id,
                        Proizvod = x.Proizvod.Naziv,
                        Cijena = x.Proizvod.Cijena,
                        Procenat = x.PopustProcent,
                        KonacnaCijena = x.Proizvod.Cijena * x.PopustProcent / 100
                    }).ToList()
                };
                return PartialView("Index", model);
            }
            else
            {
                int katalogId = a.KatalogID;
                AkcijskiKatalog ak = ctx.AkcijskiKatalog.Find(a.KatalogID);
                AkcijskiKatalogStavkeIndexVM model = new AkcijskiKatalogStavkeIndexVM
                {
                    KatalogId = katalogId,
                    KatalogProizvodi = ctx.KatalogStavka.Where(y => y.AkcijskiKatalogId == ak.Id).Select(x => new AkcijskiKatalogStavkeIndexVM.ProizvodiInfo
                    {
                        Id = x.Id,
                        Proizvod = x.Proizvod.Naziv,
                        Cijena = x.Proizvod.Cijena,
                        Procenat = x.PopustProcent,
                        KonacnaCijena = x.Proizvod.Cijena - Convert.ToDecimal(x.Proizvod.Cijena / x.PopustProcent)
                    }).ToList()
                };

                return PartialView("Index", model);
            }
        }

    }
}