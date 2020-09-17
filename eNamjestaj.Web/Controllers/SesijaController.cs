using System;
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
    
    public class SesijaController : Controller
    {
        private MojContext ctx;

        public SesijaController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index()
        {

            SesijaIndexVM model = new SesijaIndexVM();
            model.Rows = ctx.AutorizacijskiToken.Select(s => new SesijaIndexVM.Row
            {
                VrijemeLogiranja = s.VrijemeEvidentiranja,
                token = s.Vrijednost
            }).ToList();
            model.TrenutniToken = HttpContext.GetTrenutniToken();



            return View(model);
        }

        public IActionResult Obrisi(string token)
        {
            AutorizacijskiToken obrisati = ctx.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == token);
            if (obrisati != null)
            {
                ctx.AutorizacijskiToken.Remove(obrisati);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}