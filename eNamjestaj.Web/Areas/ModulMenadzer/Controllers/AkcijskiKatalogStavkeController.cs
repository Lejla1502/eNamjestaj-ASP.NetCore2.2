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
    }
}