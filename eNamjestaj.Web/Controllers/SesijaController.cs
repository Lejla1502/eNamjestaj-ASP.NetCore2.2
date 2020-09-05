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
        private MojContext _db;

        public SesijaController(MojContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            SesijaIndexVM model = new SesijaIndexVM();
            model.Rows = _db.AutorizacijskiToken.Select(s => new SesijaIndexVM.Row
            {
                VrijemeLogiranja = s.VrijemeEvidentiranja,
                token = s.Vrijednost,
                IpAdresa = s.IpAdresa
            }).ToList();
            model.TrenutniToken = HttpContext.GetTrenutniToken();



            return View(model);
        }

        public IActionResult Obrisi(string token)
        {
            AutorizacijskiToken obrisati = _db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == token);
            if (obrisati != null)
            {
                _db.AutorizacijskiToken.Remove(obrisati);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}